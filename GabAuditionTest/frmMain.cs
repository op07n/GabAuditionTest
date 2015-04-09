using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace GabAuditionTest
{
    public partial class frmMain : Form
    {
        Dictionary<string, float> notes = new Dictionary<string,float>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Music_Note_Double;

            notes.Add("Do (C)", 16.3515625f);
            notes.Add("Do♯/Ré♭ (C♯/D♭)", 17.32421875f);
            notes.Add("Ré (D)", 18.3515625f);
            notes.Add("Ré♯/Mi♭ (D♯/E♭)", 19.4453125f);
            notes.Add("Mi (E)", 20.603515625f);
            notes.Add("Fa (F)", 21.828125f);
            notes.Add("Fa♯/Sol♭ (F♯/G♭)", 23.125f);
            notes.Add("Sol (G)", 24.5f);
            notes.Add("Sol♯/La♭ (G♯/A♭)", 25.95703125f);
            notes.Add("La (A)", 27.5f);
            notes.Add("La♯/Si♭ (A♯/B♭)", 29.13671875f);
            notes.Add("Si (B)", 30.8671875f);

            updateLbl();

        }

        private void updateLbl()
        {
            lblFrom.Text = Convert.ToString(Math.Pow(2, Convert.ToDouble(nudMin.Value)) * notes["Do (C)"]) + " Hz";
            lblTo.Text = Convert.ToString(Math.Pow(2, Convert.ToDouble(nudMax.Value)) * notes["Si (B)"]) + " Hz";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            double realval;
            double mul;
            double amp = Convert.ToDouble(tbAmp.Value) / 100d;
            double[] bal;
            UInt32 attack;
            UInt32 sustain;
            UInt32 release;
            UInt32 samplerate;
            string channel;
            DialogResult dr;
            WaveType wt = WaveType.SineWave;

            if (!UInt32.TryParse(txtAttack.Text.Split(" ".ToCharArray())[0], out attack))
            {
                attack = 250;
            }

            if (!UInt32.TryParse(txtSustain.Text.Split(" ".ToCharArray())[0], out sustain))
            {
                sustain = 2000;
            }

            if (!UInt32.TryParse(txtRelease.Text.Split(" ".ToCharArray())[0], out release))
            {
                release = 250;
            }

            if (!UInt32.TryParse(cbSamplerate.Text, out samplerate))
            {
                samplerate = 44100;
            }

            if (nudMin.Value > nudMax.Value)
            {
                MessageBox.Show("Min cannot be superior to max !");
                return;
            }

            switch (cbWaveType.SelectedIndex)
            {
                case 0:
                    wt = WaveType.SineWave;
                    break;
                case 1:
                    wt = WaveType.Square;
                    break;
                case 2:
                    wt = WaveType.SawTooth;
                    break;
                case 3:
                    wt = WaveType.Triangle;
                    break;
            }

            for (int i = Convert.ToInt32(nudMin.Value); i <= nudMax.Value; i++)
            {
                mul = Math.Pow(2, i);
                
                foreach (KeyValuePair<string, float> kvp in notes)
                {
                    realval = kvp.Value * mul;
     
                    if (rbBoth.Checked)
                    {
                        bal = new double[] { 0.5d };
                    }
                    else if (rbLeft.Checked)
                    {
                        bal = new double[] { 0.0d };
                    }
                    else if (rbRight.Checked)
                    {
                        bal = new double[] { 1.0d };
                    }
                    else
                    {
                        bal = new double[] { 0.0d, 1.0d };
                    }

retry:

                    foreach (double b in bal)
                    {
                        WaveGenerator wave = new WaveGenerator(wt, samplerate, amp, realval, 2, sustain, attack, release, b);
                        wave.PlaySound();
                        if (chkSave.Checked)
                        {
                            wave.SaveToFile("output_" + samplerate.ToString() + "_" + Math.Round(realval, 2).ToString() + " Hz.wav");
                        }

                        if (b == 0.0d)
                        {
                            channel = "left";
                        }
                        else if (b == 1.0d)
                        {
                            channel = "right";
                        }
                        else
                        {
                            channel = "both (stereo)";
                        }


                        dr = MessageBox.Show(
                            "You are now listening to the note : " + kvp.Key.ToString() + " " + i.ToString() + "\nFrequency : " + realval + " Hz\nChannels : " + channel + "\n\n" +
                            "Click Yes for next note, No to retry, Cancel to quit the test.\n\n",
                            kvp.Key.ToString() + " " + i.ToString(),
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.None,
                            MessageBoxDefaultButton.Button1
                        );

                        switch (dr)
                        {
                            case System.Windows.Forms.DialogResult.Yes:
                                break;

                            case System.Windows.Forms.DialogResult.No:
                                goto retry;

                            case System.Windows.Forms.DialogResult.Cancel:
                                return;

                            default:
                                return;
                        }    
                    }


                        
                    //}
                }
            }            
        }

        private void nudMin_ValueChanged(object sender, EventArgs e)
        {
            updateLbl();
        }

        private void nudMax_ValueChanged(object sender, EventArgs e)
        {
            updateLbl();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
