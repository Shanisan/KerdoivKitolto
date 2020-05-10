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
using System.Collections;

namespace KerdoivKitolto.KerdesTipusok
{
    public partial class Feleletvalasztos : UserControl, KerdesTipusKozos
    {
        int kerdesID;
        Dictionary<CheckBox, int> values = new Dictionary<CheckBox, int>();

        public Feleletvalasztos(Controller c, Kerdes kerdes)
        {
            InitializeComponent();
            kerdesID = kerdes.id;
            Dictionary<string, int> list = c.getValaszok(kerdes.id);
            label1.Text = kerdes.szoveg;
            if (kerdes.kep != "")
            {
                pictureBox1.Image = Program.ResizeImage(new Bitmap(kerdes.kep), new Size(762, 384));
            }
            if (list == null)
            {
                flowLayoutPanel1.Dispose();
            }
            else
            {
                foreach (KeyValuePair<string, int> s in list)
                {
                    KeyValuePair<int, CheckBox> kvp = new KeyValuePair<int, CheckBox>(s.Value, new CheckBox());
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
            foreach (CheckBox cb in flowLayoutPanel1.Controls)
            {
                if (cb.Checked)
                {
                    result.Add(kerdesID + "~" + values[cb].ToString());
                }
            }
            return result;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
