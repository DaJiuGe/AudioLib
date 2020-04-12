using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioLib.Audio
{
    public class AudioAnalyzer
    {
        private static AudioAnalyzer _instance;
        public static AudioAnalyzer Instance => GetInstance();

        private static AudioAnalyzer GetInstance()
        {
            if (_instance == null)
            {
                return new AudioAnalyzer();
            }

            return _instance;
        }

        private AudioAnalyzer()
        {
        }
    }
}
