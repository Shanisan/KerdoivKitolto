using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KerdoivKitolto.Model;
using KerdoivKitolto.ControllerNS;

namespace KerdoivKitolto.KerdesTipusok
{
    public partial class EgyszeresValaszto : UserControl, KerdesTipusKozos
    {
        Controller c;
        Dictionary<RadioButton, int> values = new Dictionary<RadioButton, int>();
        int kerdesID;
        public EgyszeresValaszto(Controller c, Kerdes kerdes)
        {
            InitializeComponent();
            this.c = c;
            Dictionary<string, int> list = c.getValaszok(kerdes.id);
            label1.Text = kerdes.szoveg;
            kerdesID = kerdes.id;
            if (kerdes.kep != "")
            {
                pictureBox1.Image = Program.ResizeImage(new Bitmap(kerdes.kep), new Size(762, 384));
            }
            else
            {
                pictureBox1.Dispose();
                this.AutoSize = true;
            }
            if (list == null)
            {
                flowLayoutPanel1.Dispose();
            }
            else
            {
                foreach(KeyValuePair<string, int> s in list)
                {
                    KeyValuePair<int, RadioButton> kvp = new KeyValuePair<int, RadioButton>(s.Value, new RadioButton());
                    kvp.Value.Name = "kerdes.id";
                    kvp.Value.Text = s.Key;
                    kvp.Value.Name = s.Value.ToString();
                    kvp.Value.Width = 400;
                    flowLayoutPanel1.Controls.Add(kvp.Value);
                    values.Add(kvp.Value, kvp.Key);
                }
            }
        }

        public List<string> getAnswers()
        {
            List<string> result = new List<String>();
            foreach (RadioButton cb in flowLayoutPanel1.Controls)
            {
                if (cb.Checked)
                {
                    result.Add(kerdesID + "~" + values[cb].ToString());
                }
            }
            return result;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
