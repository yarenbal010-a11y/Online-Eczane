using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OnlineEczane
{
    public partial class SplashForm : Form
    {
        private System.Windows.Forms.Timer timer;

        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Shown(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 2;
            }
            else
            {
                timer.Stop();

                this.Hide();

                GirisFormu giris = new GirisFormu();
                giris.FormClosed += (s, args) => this.Close();
                giris.Show();
            }
        }
    }
}
