using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KerdoivKitolto.ControllerNS;
using KerdoivKitolto.Model;

namespace KerdoivKitolto.KerdesTipusok
{
    public partial class SzamosKerdes : UserControl, KerdesTipusKozos
    {
        int kerdesID;
        public SzamosKerdes(Controller c, Kerdes k)
        {
            InitializeComponent();
            label1.Text = k.szoveg;
            numericUpDown1.Minimum = Int32.MinValue;
            numericUpDown1.Maximum = Int32.MaxValue;
            numericUpDown1.MouseWheel += Ctl_MouseWheel;
            kerdesID = k.id;
            if (k.kep != "")
            {
                pictureBox1.Image = Program.ResizeImage(new Bitmap(k.kep), new Size(762, 384));
            }
            else
            {
                pictureBox1.Dispose();
                this.AutoSize = true;
            }
        }

        public List<string> getAnswers()
        {
            List<string> result = new List<String>();
            result.Add(kerdesID + "~" + numericUpDown1.Value.ToString());
                
            return result;
        }

        private void Ctl_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
