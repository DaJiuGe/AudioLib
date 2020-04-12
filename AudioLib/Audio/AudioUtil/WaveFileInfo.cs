using System.IO;
using System.Windows.Documents;
using NAudio.Wave;

namespace AudioLib.Audio.AudioUtil
{
    public class WaveFileInfo
    {
        public string FileName { get; }
        public string FilePath { get; }
        public long FileSampleLength { get; }
        public long FileSampleStartPosition { get; }
        public long FileTimeLength { get; }
        public long FileTimeStartPosition { get; }
        public int SampleRate { get; }
        public int BitsPerSample { get; }
        public int Channels { get; }
        public int AverageBytesPerSecond { get; }
        public int BlockAlign { get; }
        public int ExtraSize { get; }

        public WaveFileInfo(string waveFilePath)
        {
            using (AudioFileReader reader = new AudioFileReader(waveFilePath))
            {
                FileName = System.IO.Path.GetFileName(waveFilePath);
                FilePath = waveFilePath;
                FileSampleLength = reader.Length;
                FileSampleStartPosition = reader.Position;
                FileTimeLength = (long)reader.TotalTime.TotalMilliseconds;
                FileTimeStartPosition = (long) ((reader.Position * 1.0 / reader.Length) * FileTimeLength);
                WaveFormat format = reader.WaveFormat;
                SampleRate = format.SampleRate;
                BitsPerSample = format.BitsPerSample;
                Channels = format.Channels;
                AverageBytesPerSecond = format.AverageBytesPerSecond;
                BlockAlign = format.BlockAlign;
                ExtraSize = format.ExtraSize;
            }
        }

        public override string ToString()
        {
            return $"FileName: {FileName}\r\n" +
                   $"FilePath: {FilePath}\r\n" +
                   $"FileSampleLength: {FileSampleLength}\r\n" +
                   $"FileSmapleStartPosition: {FileSampleStartPosition}\r\n" +
                   $"FileTimeLength: {FileTimeLength}\r\n" +
                   $"FileTimeStartPosition: {FileTimeStartPosition}\r\n" +
                   $"SampleRate: {SampleRate}\r\n" +
                   $"BitsPerSamle: {BitsPerSample}\r\n" +
                   $"Channels: {Channels}\r\n" +
                   $"AverageBytesPerSecond: {AverageBytesPerSecond}\r\n" +
                   $"BlockAlign: {BlockAlign}\r\n" +
                   $"ExtraSize: {ExtraSize}";
        }
    }
}
