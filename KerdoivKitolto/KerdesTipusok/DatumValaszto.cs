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
    public partial class DatumValaszto : UserControl, KerdesTipusKozos
    {
        int kerdesID;
        public DatumValaszto(Controller c, Kerdes k)
        {
            InitializeComponent();
            kerdesID = k.id;
            label1.Text = k.szoveg;
            if (k.kep != "")
            {
                pictureBox1.Image = Program.ResizeImage(new Bitmap(k.kep), new Size(762, 384));
            }
        }

        public List<string> getAnswers()
        {
            List<string> s = new List<string>();
            string str = kerdesID.ToString();
            str+="~"+ dateTimePicker1.Value.Date.ToString();
            s.Add(str);
            return s;
        }
    }
}
