using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AudioLib.Audio.AudioUtil;
using NAudio.Wave;

namespace AudioLib.Audio
{
    public enum Waveform
    {
        Sine,
        Sine_Dual,
        Sine_VarPhase,
        Square,
        File
    }

    public class AudioGenerator
    {
        private static AudioGenerator _instance;
        public static AudioGenerator Instance => GetInstance();

        private static AudioGenerator GetInstance()
        {
            if (_instance == null)
            {
                return new AudioGenerator();
            }

            return _instance;
        }

        private AudioGenerator()
        {
        }
        
        public Waveform WorkMode { get; private set; }

        public void SwitchWorkMode(Waveform wavefrom)
        {
            WorkMode = wavefrom;
        }

        public WaveFileInfo WaveFile { get; private set; }

        public void LoadWaveFile(string waveFilePath)
        {
            WaveFile = new WaveFileInfo(waveFilePath);
            Console.WriteLine(WaveFile.ToString());
        }

        public void TurnOn()
        {
            switch (WorkMode)
            {
                case Waveform.Sine:
                    break;
                case Waveform.Sine_Dual:
                    break;
                case Waveform.Sine_VarPhase:
                    break;
                case Waveform.Square:
                    break;
                case Waveform.File:
                    using (var rdr = new AudioFileReader(WaveFile.FilePath))
                    using (var wavStream = WaveFormatConversionStream.CreatePcmStream(rdr))
                    using (var baStream = new BlockAlignReductionStream(wavStream))
                    using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(baStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(100);
                        }
                    }
                    break;
            }
        }

        public void TurnOff()
        {

        }
    }
}
