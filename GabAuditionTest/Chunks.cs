using System;
using System.Collections.Generic;
using System.Text;

namespace GabAuditionTest
{

    /// <summary>
    /// Wraps the header portion of a WAVE file.
    /// </summary>
    public class WaveHeader
    {
        public string sGroupID; // RIFF
        public UInt32 dwFileLength; // total file length minus 8, which is taken up by RIFF
        public string sRiffType; // always WAVE

        /// <summary>
        /// Initializes a WaveHeader object with the default values.
        /// </summary>
        public WaveHeader()
        {
            dwFileLength = 0;
            sGroupID = "RIFF";
            sRiffType = "WAVE";
        }
    }

    /// <summary>
    /// Wraps the Format chunk of a wave file.
    /// </summary>
    public class WaveFormatChunk
    {
        public string sChunkID;           // Four bytes: "fmt "
        public UInt32 dwChunkSize;        // Length of header in bytes
        public UInt16 wFormatTag;         // 1 (MS PCM)
        public Int16  wChannels;          // Number of channels
        public UInt32 dwSamplesPerSec;    // Frequency of the audio in Hz... 44100
        public UInt32 dwAvgBytesPerSec;   // for estimating RAM allocation
        public Int16 wBlockAlign;         // sample frame size, in bytes
        public UInt16 wBitsPerSample;     // bits per sample

        /// <summary>
        /// Initializes a format chunk with the following properties:
        /// Sample rate: 44100 Hz
        /// Channels: Stereo
        /// Bit depth: 16-bit
        /// </summary>
        public WaveFormatChunk()
        {
            sChunkID = "fmt ";
            dwChunkSize = 16;
            wFormatTag = 1;
            wChannels = 2;
            dwSamplesPerSec = 44100;
            wBitsPerSample = 16;
            wBlockAlign = (Int16)(wChannels * (wBitsPerSample / 8));
            dwAvgBytesPerSec = (UInt32)(dwSamplesPerSec * wBlockAlign);
        }
    }

    /// <summary>
    /// Wraps the Data chunk of a wave file.
    /// </summary>
    public class WaveDataChunk
    {
        public string sChunkID;     // "data"
        public UInt32 dwChunkSize;  // Length of header in bytes
        public Int16[] shortArray;  // 8-bit audio

        /// <summary>
        /// Initializes a new data chunk with default values.
        /// </summary>
        public WaveDataChunk()
        {
            shortArray = new Int16[0];
            dwChunkSize = 0;
            sChunkID = "data";
        }
    }
}
