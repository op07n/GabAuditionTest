using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace GabAuditionTest
{
    /// <summary>
    /// Possible waves to generate
    /// </summary>
    public enum WaveType
    {
        SineWave = 0,
        SawTooth = 2,
        Square = 3,
        Triangle = 4
    }

    /// <summary>
    /// Wraps a WAV file struture and auto-generates some canned waveforms.
    /// </summary>
    public class WaveGenerator
    {
        // Header, Format, Data chunks
        WaveHeader header;
        WaveFormatChunk format;
        WaveDataChunk data;

        /// <summary>
        /// Initializes the object and generates a wave.
        /// </summary>
        /// <param name="type">The type of wave to generate</param>
        /// <param name="samplerate">The samplerate of the wave in Hz</param>
        /// <param name="amplitude">The amplitude of the wave between 0.0 and 1.0</param>
        /// <param name="frequency">The frequency of the wave in Hz</param>
        /// <param name="channels">The number of channels of the wave (1=mono, 2=stereo)</param>
        /// <param name="duration">The duration of the wave in milliseconds</param>
        /// <param name="balance">The balance left/right between 0.0 and 1.0 (middle is 0.5)</param>
        public WaveGenerator(WaveType type, UInt32 samplerate, double amplitude, double frequency, Int16 channels, UInt32 duration, UInt32 attack, UInt32 release, double balance)
        {
            // Init chunks
            header = new WaveHeader();
            format = new WaveFormatChunk();
            data = new WaveDataChunk();

            format.dwSamplesPerSec = samplerate;
            format.wChannels = channels;

            double amplitudeleft=0;
            double amplituderight=0;
            double channelamplitude=0;
            double t = 0;
            Int16 sample = 0;
            //Int16 sampletest = 0;
            UInt32 i = 0;
            UInt32 j = 0;
            UInt32 numSamplesAttack;
            UInt32 numSamplesAttackTot;
            UInt32 numSamplesSustain;
            UInt32 numSamplesSustainTot;
            UInt32 numSamplesRelease;
            UInt32 numSamplesReleaseTot;
            Int16 channel;
            Int16[] attackData;
            Int16[] sustainData;
            Int16[] releaseData;

            // Number of attack samples = sample rate * channels * bytes per sample
            numSamplesAttack = (UInt32)((format.dwSamplesPerSec * attack) / 1000);
            numSamplesAttackTot = numSamplesAttack * (UInt32)format.wChannels;


            // Number of sustain samples = sample rate * channels * bytes per sample
            numSamplesSustain = (UInt32)((format.dwSamplesPerSec * duration) / 1000);
            numSamplesSustainTot = numSamplesSustain * (UInt32)format.wChannels;

            // Number of sustain samples = sample rate * channels * bytes per sample
            numSamplesRelease = (UInt32)((format.dwSamplesPerSec * release) / 1000);
            numSamplesReleaseTot = numSamplesRelease * (UInt32)format.wChannels;

            // Initialize the 16-bit arrays
            attackData = new Int16[numSamplesAttackTot];
            sustainData = new Int16[numSamplesSustainTot];
            releaseData = new Int16[numSamplesReleaseTot];

            amplitude = amplitude * Int16.MaxValue;  // Max amplitude for 16-bit audio
            amplitudeleft = amplitude;
            amplituderight = amplitude;

            if (channels == 2)
            {
                if (balance > 0.5)
                {
                    amplitudeleft = (amplitude * (1 - balance)) / 0.5;
                }
                else if (balance < 0.5)
                {
                    amplituderight = (amplitude * balance) / 0.5;
                }
            }
            
            // Fill the data array with sample data
            switch (type)
            {

                //generate a Sine wave form
                case WaveType.SineWave:
                    {

                        // The "angle" used in the function, adjusted for the sample rate.
                        // This value is like the period of the wave.
                        t = (Math.PI * 2 * frequency) / format.dwSamplesPerSec;

                        //fill in the attack array
                        for (i = 0; i < numSamplesAttack; i++)
                        {
                            // Fill with a simple sine wave at specified amplitude
                            for (channel = 0; channel < format.wChannels; channel++)
                            {
                                if (channel == 0)
                                {
                                    channelamplitude = amplitudeleft;
                                }
                                else
                                {
                                    channelamplitude = amplituderight;
                                }

                                if (numSamplesAttack > 0)
                                {
                                    channelamplitude = channelamplitude * ((double)(i + 1) / numSamplesAttack);
                                }

                                sample = Convert.ToInt16(channelamplitude * Math.Sin(t * i));
                                attackData[i * format.wChannels + channel] = sample;
                            }
                        }

                        j = i;

                        //fill in the sustain array
                        for (i = j; i < numSamplesSustain + j; i++)
                        {
                            // Fill with a simple sine wave at specified amplitude
                            for (channel = 0; channel < format.wChannels; channel++)
                            {
                                if (channel == 0)
                                {
                                    channelamplitude = amplitudeleft;
                                }
                                else
                                {
                                    channelamplitude = amplituderight;
                                }
                                sample = Convert.ToInt16(channelamplitude * Math.Sin(t * i));
                                sustainData[(i - j) * format.wChannels + channel] = sample;
                            }
                        }

                        j = i;

                        //fill in the release array
                        for (i = j; i < numSamplesRelease + j; i++)
                        {
                            // Fill with a simple sine wave at specified amplitude
                            for (channel = 0; channel < format.wChannels; channel++)
                            {
                                if (channel == 0)
                                {
                                    channelamplitude = amplitudeleft;
                                }
                                else
                                {
                                    channelamplitude = amplituderight;
                                }

                                if (numSamplesRelease > 0)
                                {
                                    channelamplitude = channelamplitude - (channelamplitude * ((double)(i - j + 1) / (numSamplesRelease)));
                                }

                                sample = Convert.ToInt16(channelamplitude * Math.Sin(t * i));
                                releaseData[(i - j) * format.wChannels + channel] = sample;
                            }
                        }
                    }
                    break;

                //generate a Square wave form
                case WaveType.Square:
                    {

                        // The "angle" used in the function, adjusted for the sample rate.
                        // This value is like the period of the wave.
                        t = (Math.PI * 2 * frequency) / format.dwSamplesPerSec;

                        //fill in the attack array
                        for (i = 0; i < numSamplesAttack; i++)
                        {
                            // Fill with a simple square wave at specified amplitude
                            for (channel = 0; channel < format.wChannels; channel++)
                            {
                                if (channel == 0)
                                {
                                    channelamplitude = amplitudeleft;
                                }
                                else
                                {
                                    channelamplitude = amplituderight;
                                }

                                if (numSamplesAttack > 0)
                                {
                                    channelamplitude = channelamplitude * ((double)(i + 1) / numSamplesAttack);
                                }

                                if (Math.Sin(t * i) > 0)
                                {
                                    sample = Convert.ToInt16(channelamplitude);
                                }
                                else
                                {
                                    sample = Convert.ToInt16(channelamplitude * -1);
                                }

                                attackData[i * format.wChannels + channel] = sample;
                            }
                        }

                        j = i;

                        //fill in the sustain array
                        for (i = j; i < numSamplesSustain + j; i++)
                        {
                            // Fill with a simple square wave at specified amplitude
                            for (channel = 0; channel < format.wChannels; channel++)
                            {
                                if (channel == 0)
                                {
                                    channelamplitude = amplitudeleft;
                                }
                                else
                                {
                                    channelamplitude = amplituderight;
                                }

                                if (Math.Sin(t * i) > 0)
                                {
                                    sample = Convert.ToInt16(channelamplitude);
                                }
                                else
                                {
                                    sample = Convert.ToInt16(channelamplitude * -1);
                                }

                                sustainData[(i - j) * format.wChannels + channel] = sample;
                            }
                        }

                        j = i;

                        //fill in the release array
                        for (i = j; i < numSamplesRelease + j; i++)
                        {
                            // Fill with a simple square wave at specified amplitude
                            for (channel = 0; channel < format.wChannels; channel++)
                            {
                                if (channel == 0)
                                {
                                    channelamplitude = amplitudeleft;
                                }
                                else
                                {
                                    channelamplitude = amplituderight;
                                }

                                if (numSamplesRelease > 0)
                                {
                                    channelamplitude = channelamplitude - (channelamplitude * ((double)(i - j + 1) / (numSamplesRelease)));
                                }

                                if (Math.Sin(t * i) > 0)
                                {
                                    sample = Convert.ToInt16(channelamplitude);
                                }
                                else
                                {
                                    sample = Convert.ToInt16(channelamplitude * -1);
                                }

                                releaseData[(i - j) * format.wChannels + channel] = sample;
                            }
                        }
                    }
                    break;
            

                //generate a Sawtooth wave form
                case WaveType.SawTooth:
                    {
                        //fill in the attack array
                        for (i = 0; i < numSamplesAttack; i++)
                        {
                            // The "angle" used in the function, adjusted for the sample rate.
                            // This value is like the period of the wave.
                            t = (frequency / format.dwSamplesPerSec) * i;

                            // Fill with a simple sawtooth wave at specified amplitude
                            for (channel = 0; channel < format.wChannels; channel++)
                            {
                                if (channel == 0)
                                {
                                    channelamplitude = amplitudeleft;
                                }
                                else
                                {
                                    channelamplitude = amplituderight;
                                }

                                if (numSamplesAttack > 0)
                                {
                                    channelamplitude = channelamplitude * ((double)(i + 1) / numSamplesAttack);
                                }

                                sample = Convert.ToInt16( channelamplitude * (2d * (t - (double)Math.Floor(t + 0.5f))) );
                                attackData[i * format.wChannels + channel] = sample;
                            }
                        }
                        
                        j = i;

                        //fill in the sustain array
                        for (i = j; i < numSamplesSustain + j; i++)
                        {
                            // The "angle" used in the function, adjusted for the sample rate.
                            // This value is like the period of the wave.
                            t = (frequency / format.dwSamplesPerSec) * i;

                            // Fill with a simple sawtooth wave at specified amplitude
                            for (channel = 0; channel < format.wChannels; channel++)
                            {
                                if (channel == 0)
                                {
                                    channelamplitude = amplitudeleft;
                                }
                                else
                                {
                                    channelamplitude = amplituderight;
                                }

                                sample = Convert.ToInt16(channelamplitude * (2d * (t - (double)Math.Floor(t + 0.5f))));
                                sustainData[(i - j) * format.wChannels + channel] = sample;
                            }
                        }

                        j = i;

                        //fill in the release array
                        for (i = j; i < numSamplesRelease + j; i++)
                        {
                            // The "angle" used in the function, adjusted for the sample rate.
                            // This value is like the period of the wave.
                            t = (frequency / format.dwSamplesPerSec) * i;

                            // Fill with a simple sawtooth wave at specified amplitude
                            for (channel = 0; channel < format.wChannels; channel++)
                            {
                                if (channel == 0)
                                {
                                    channelamplitude = amplitudeleft;
                                }
                                else
                                {
                                    channelamplitude = amplituderight;
                                }

                                if (numSamplesRelease > 0)
                                {
                                    channelamplitude = channelamplitude - (channelamplitude * ((double)(i - j + 1) / (numSamplesRelease)));
                                }

                                sample = Convert.ToInt16(channelamplitude * (2d * (t - (double)Math.Floor(t + 0.5f))));
                                releaseData[(i - j) * format.wChannels + channel] = sample;
                            }
                        }
                    }
                    break;

                case WaveType.Triangle:
                    {
                        //fill in the attack array
                        for (i = 0; i < numSamplesAttack; i++)
                        {
                            // The "angle" used in the function, adjusted for the sample rate.
                            // This value is like the period of the wave.
                            t = (frequency / format.dwSamplesPerSec) * i;

                            // Fill with a simple triangle wave at specified amplitude
                            for (channel = 0; channel < format.wChannels; channel++)
                            {
                                if (channel == 0)
                                {
                                    channelamplitude = amplitudeleft;
                                }
                                else
                                {
                                    channelamplitude = amplituderight;
                                }

                                if (numSamplesAttack > 0)
                                {
                                    channelamplitude = channelamplitude * ((double)(i + 1) / numSamplesAttack);
                                }

                                sample = Convert.ToInt16(channelamplitude * (1d - 4d * (double)Math.Abs(Math.Round(t - 0.25d) - (t - 0.25d))));
                                attackData[i * format.wChannels + channel] = sample;
                            }
                        }

                        j = i;

                        //fill in the sustain array
                        for (i = j; i < numSamplesSustain + j; i++)
                        {
                            // The "angle" used in the function, adjusted for the sample rate.
                            // This value is like the period of the wave.
                            t = (frequency / format.dwSamplesPerSec) * i;

                            // Fill with a simple triangle wave at specified amplitude
                            for (channel = 0; channel < format.wChannels; channel++)
                            {
                                if (channel == 0)
                                {
                                    channelamplitude = amplitudeleft;
                                }
                                else
                                {
                                    channelamplitude = amplituderight;
                                }

                                sample = Convert.ToInt16(channelamplitude * (1d - 4d * (double)Math.Abs(Math.Round(t - 0.25d) - (t - 0.25d))));
                                sustainData[(i - j) * format.wChannels + channel] = sample;
                            }
                        }

                        j = i;

                        //fill in the release array
                        for (i = j; i < numSamplesRelease + j; i++)
                        {
                            // The "angle" used in the function, adjusted for the sample rate.
                            // This value is like the period of the wave.
                            t = (frequency / format.dwSamplesPerSec) * i;

                            // Fill with a simple triangle wave at specified amplitude
                            for (channel = 0; channel < format.wChannels; channel++)
                            {
                                if (channel == 0)
                                {
                                    channelamplitude = amplitudeleft;
                                }
                                else
                                {
                                    channelamplitude = amplituderight;
                                }

                                if (numSamplesRelease > 0)
                                {
                                    channelamplitude = channelamplitude - (channelamplitude * ((double)(i - j + 1) / (numSamplesRelease)));
                                }

                                sample = Convert.ToInt16(channelamplitude * (1d - 4d * (double)Math.Abs(Math.Round(t - 0.25d) - (t - 0.25d))));
                                releaseData[(i - j) * format.wChannels + channel] = sample;
                            }
                        }
                    }
                    break;
                    
            }

            //copy data to the data.shortArray array
            data.shortArray = new Int16[attackData.Length + sustainData.Length + releaseData.Length];
            Array.Copy(attackData, 0, data.shortArray, 0, attackData.Length);
            Array.Copy(sustainData, 0, data.shortArray, attackData.Length, sustainData.Length);
            Array.Copy(releaseData, 0, data.shortArray, attackData.Length + sustainData.Length, releaseData.Length);

            Array.Clear(attackData, 0, attackData.Length);
            Array.Clear(sustainData, 0, sustainData.Length);
            Array.Clear(releaseData, 0, releaseData.Length);

            // Calculate data chunk size in bytes
            data.dwChunkSize = (UInt32)(data.shortArray.Length * (format.wBitsPerSample / 8));

        }

        /// <summary>
        /// Initializes the object and generates a default sine wave.
        /// </summary>
        /// <param name="type">The type of wave to generate</param>
        public WaveGenerator(WaveType type) : this (type, 44100, 1, 440, 2, 1000, 250, 250, 0.5) { }

        /// <summary>
        /// Saves the current wave data to the specified file.
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveToFile(string filePath)
        {
            // Create a file (it always overwrites)
            FileStream fileStream = new FileStream(filePath, FileMode.Create);

            // Use BinaryWriter to write the bytes to the file
            BinaryWriter writer = new BinaryWriter(fileStream);

            // Write the header
            writer.Write(header.sGroupID.ToCharArray());
            writer.Write(header.dwFileLength);
            writer.Write(header.sRiffType.ToCharArray());

            // Write the format chunk
            writer.Write(format.sChunkID.ToCharArray());
            writer.Write(format.dwChunkSize);
            writer.Write(format.wFormatTag);
            writer.Write(format.wChannels);
            writer.Write(format.dwSamplesPerSec);
            writer.Write(format.dwAvgBytesPerSec);
            writer.Write(format.wBlockAlign);
            writer.Write(format.wBitsPerSample);

            // Write the data chunk
            writer.Write(data.sChunkID.ToCharArray());
            writer.Write(data.dwChunkSize);
            foreach (Int16 dataPoint in data.shortArray)
            {
                writer.Write(dataPoint);
            }

            writer.Seek(4, SeekOrigin.Begin);
            UInt32 filesize = (UInt32)writer.BaseStream.Length;
            writer.Write(filesize - 8);

            // Clean up
            writer.Close();
            fileStream.Close();
        }

        /// <summary>
        /// Saves the current wave data to a stream.
        /// </summary>
        /// <param name="filePath"></param>
        public MemoryStream SaveToStream()
        {
            // Create a file (it always overwrites)
            MemoryStream memStream = new MemoryStream();

            // Use BinaryWriter to write the bytes to the file
            BinaryWriter writer = new BinaryWriter(memStream);

            // Write the header
            writer.Write(header.sGroupID.ToCharArray());
            writer.Write(header.dwFileLength);
            writer.Write(header.sRiffType.ToCharArray());

            // Write the format chunk
            writer.Write(format.sChunkID.ToCharArray());
            writer.Write(format.dwChunkSize);
            writer.Write(format.wFormatTag);
            writer.Write(format.wChannels);
            writer.Write(format.dwSamplesPerSec);
            writer.Write(format.dwAvgBytesPerSec);
            writer.Write(format.wBlockAlign);
            writer.Write(format.wBitsPerSample);

            // Write the data chunk
            writer.Write(data.sChunkID.ToCharArray());
            writer.Write(data.dwChunkSize);
            foreach (Int16 dataPoint in data.shortArray)
            {
                writer.Write(dataPoint);
            }

            writer.Seek(4, SeekOrigin.Begin);
            UInt32 filesize = (UInt32)writer.BaseStream.Length;
            writer.Write(filesize - 8);

            // Clean up
            writer.Close();
            memStream.Close();

            return memStream;
        }



        /// <summary>
        /// Plays data
        /// </summary>
        /// <param name="filePath"></param>
        public void PlaySound()
        {
            // Create a file (it always overwrites)
            MemoryStream memStream = new MemoryStream();
            
            // Use BinaryWriter to write the bytes to the file
            BinaryWriter writer = new BinaryWriter(memStream);

            // Write the header
            writer.Write(header.sGroupID.ToCharArray());
            writer.Write(header.dwFileLength);
            writer.Write(header.sRiffType.ToCharArray());

            // Write the format chunk
            writer.Write(format.sChunkID.ToCharArray());
            writer.Write(format.dwChunkSize);
            writer.Write(format.wFormatTag);
            writer.Write(format.wChannels);
            writer.Write(format.dwSamplesPerSec);
            writer.Write(format.dwAvgBytesPerSec);
            writer.Write(format.wBlockAlign);
            writer.Write(format.wBitsPerSample);

            // Write the data chunk
            writer.Write(data.sChunkID.ToCharArray());
            writer.Write(data.dwChunkSize);
            foreach (Int16 dataPoint in data.shortArray)
            {
                writer.Write(dataPoint);
            }

            writer.Seek(4, SeekOrigin.Begin);
            UInt32 filesize = (UInt32)writer.BaseStream.Length;
            writer.Write(filesize - 8);

            //seek to beginning of stream before reading it
            writer.Seek(0, SeekOrigin.Begin);

            SoundPlayer player = new SoundPlayer(memStream);
            player.Play();

            // Clean up
            writer.Close();
            memStream.Close();
        }
    }
}
