using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using KerdoivKitolto.Model;

namespace KerdoivKitolto.KerdesTipusok
{
    public partial class SzovegesKerdes : UserControl, KerdesTipusKozos
    {
        int kerdesID;
        public SzovegesKerdes(Kerdes k)
        {
            InitializeComponent();
            label1.Text = k.szoveg;
            kerdesID = k.id;
            if(k.kep != "")
            {
                pictureBox1.Image = Program.ResizeImage(new Bitmap(k.kep), new Size(762, 384));
            }
        }


        public List<string> getAnswers()
        {
            List<string> s = new List<string>();
            string str = kerdesID.ToString();
            str += "~\"" + textBox1.Text + "\"";
            s.Add(str);
            return s;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("\"") || textBox1.Text.Contains("~") || textBox1.Text.Contains("|"))
            {
                MessageBox.Show("A szöveges beviteli mező nem tartalmazhatja a |, ~ és \" karakereket.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
