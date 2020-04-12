using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioLib.Audio
{
    public enum eDevice
    {
        APx,
        TPx,
        SoundCard
    }

    public class AudioManager
    {

        public static AudioGenerator Generator = AudioGenerator.Instance;
        public static AudioAnalyzer Analyzer = AudioAnalyzer.Instance;
    }
}
