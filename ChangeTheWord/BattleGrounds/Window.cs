using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleGrounds
{
    public partial class Window : Form
    {
        Program Program = new Program();
        Analysis a = new Analysis();
        public Window()
        {
            InitializeComponent();
            Program.CreateDataRecoClient();
            Program.SendAudioHelper(@"C:\Source\batman.wav");
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            a.Input = Program.text;
            rtb_output.Text = Program.text;
            var wordCount = a.WordCount().OrderByDescending(w => w.Value);
            rtb_top10.Text = "Here are some of the most common sentimental and non-sentimental words:\n\n";
            foreach (var i in wordCount)
            {
                rtb_top10.Text += $"{i.Key}: {i.Value}\n";
            }

            var replace = a.ReplaceWords().OrderByDescending(w => w.Value);
            rtb_replaced.Text = "Here are some of the most common sentimental words:\n\n";
            foreach (var i in replace)
            {
                rtb_replaced.Text += $"{i.Key}: {i.Value}\n";
            }

            rtb_th.Text = "Try some of thease replacement words to imporve your vocabulary!\n\n";
            var re = replace.Select(r => r.Key).Take(10);
            foreach (var keyValuePair in re)
            {
                rtb_th.Text += $"{keyValuePair}:\n";
                var th = a.getThesaurus(keyValuePair);
                if(th.noun != null) { 
                foreach (var n in th.noun.syn)
                {
                    rtb_th.Text += $"{n}, ";
                }
                }
                rtb_th.Text += "\n";
            }
        }
    }
}
