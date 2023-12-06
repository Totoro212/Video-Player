using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.settings.volume = 20;
            trackBar1.Value = 20;
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            label1.ForeColor = Color.White;

        }
        string[] Path, files;
        int x = 0, y = 0;
        int mx = 0, my = 0;
        ListBox ls = new ListBox();
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                files = ofp.FileNames;
                Path = ofp.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    listBox1.Items.Add(files[i].Substring(files[i].LastIndexOf('\\') + 1));
                    ls.Items.Add(files[i]);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex -1);

        }

        /*private void button3_Click(object sender, EventArgs e) {listBox1.Items.Add(files[listBox1.SelectedIndex].Substring(files[listBox1.SelectedIndex].LastIndexOf('\\') +1));}*/
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = ls.Items[listBox1.SelectedIndex].ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();
            timer1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                ++listBox1.SelectedIndex;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
                axWindowsMediaPlayer1.Ctlcontrols.play();
            else
                axWindowsMediaPlayer1.Ctlcontrols.pause();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0) --listBox1.SelectedIndex;

        }

        private void progressBar1_MouseDown(object sender, MouseEventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = 
                axWindowsMediaPlayer1.currentMedia.duration * e.X / progressBar1.Width;

        }



        //всплывающие окна
        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox1.Visible == false)
            {
                listBox1.Visible = true;
                button6.Visible = true;
                button4.Visible = true;
            }
            else
            {

                button6.Visible = false;
                button4.Visible = false;
                listBox1.Visible = false;
            }
        }
        private void button7_Click(object sender, EventArgs e){}
        private void listBox1_MouseLeave(object sender, EventArgs e)
        {
        }
        int T=0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            T++;

            if (x == mx && y == my && T >= 7)
            {

                label1.Visible = false;
                label2.Visible = false;
                listBox1.Visible = false;
                button6.Visible = false;
                button4.Visible = false;

                progressBar1.Visible = false;
                button7.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button5.Visible = false;
                trackBar1.Visible = false;
                button8.Visible = false;
                timer2.Stop();
            }

            mx = x; my = y;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
           // timer2.Enabled = false;

        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
           // timer2.Enabled = true;

        }
        private void button6_MouseLeave(object sender, EventArgs e)
        {
           // timer2.Enabled = true;
        }
        private void button6_MouseEnter(object sender, EventArgs e)
        {
           // timer2.Enabled = false;

        }


        private void trackBar1_MouseLeave(object sender, EventArgs e)
        {
            trackBar1.Visible = false;

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;

        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {

            if (trackBar1.Visible == false)
            {
                trackBar1.Visible = true;
            }
            else
            {
                trackBar1.Visible = false;
            }
        }

      

        private void axWindowsMediaPlayer1_MouseMoveEvent(object sender, AxWMPLib._WMPOCXEvents_MouseMoveEvent e)
        {
            x = e.fX;
            y = e.fY;

            timer2.Enabled = true;
            timer2.Start();
            if(x!=mx && y!=my)
            {
                label1.Visible = true;
                label2.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button5.Visible = true;
                progressBar1.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                Cursor.Show();

            }


        }



        //
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar1.Maximum = (int)axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
                progressBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            }
            try
            {
                label1.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
                label2.Text = axWindowsMediaPlayer1.Ctlcontrols.currentItem.durationString.ToString();
            }
            catch { }

        }
        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void progressBar1_MouseEnter(object sender, EventArgs e)
        {
        }

        private void progressBar1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Move(object sender, EventArgs e)
        {
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
        }
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
        }



    }
}
