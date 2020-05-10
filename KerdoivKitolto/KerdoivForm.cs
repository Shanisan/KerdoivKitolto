using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using KerdoivKitolto.ControllerNS;
using KerdoivKitolto.KerdesTipusok;
using KerdoivKitolto.Model;

namespace KerdoivKitolto
{
    public partial class KerdoivForm : Form
    {
        ControllerNS.Controller c;
        int kerdoivID;
        Button ok = new Button();
        TextBox nev = new TextBox();
        KerdoivLezaro lezaro = new KerdoivLezaro();
        int perc;
        int masodperc;
        int osszido;
        string kerdoivNev;
        string kitoltoNeve = "Anonymous";

        public KerdoivForm(ControllerNS.Controller c, string kerdoivNev, int timer, string kitoltoNeve)
        {
            this.c = c;
            this.kerdoivID = c.GetKerdoivIdByName(kerdoivNev);
            osszido = timer*60;
            this.kerdoivNev = kerdoivNev;
            if (kitoltoNeve != "")
            {
                this.kitoltoNeve = kitoltoNeve;
            }
            //Console.WriteLine(kerdoivID);
            if (kerdoivID == -1)
            {
                MessageBox.Show("Hiba történt!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                this.Text = "Kérdőív: " + kerdoivNev;
                InitializeComponent();
                flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
                flowLayoutPanel2.WrapContents = false;
                flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
                flowLayoutPanel2.AutoScroll = true;
                this.Show();
            }

        }

        private void KerdoivForm_Load(object sender, EventArgs e)
        {
            List<Kerdes> kerdesek = c.getKerdesek(kerdoivID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new System.Drawing.Size(813, 600);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            int kerdesekSzama = 0;
            foreach (Kerdes k in kerdesek)
            {
                string imgpath = k.kep;
                imgpath = imgpath.Replace('/', '\\');
                Control kerdes = new Control();
                //Console.WriteLine("Tipus= "+k.tipus);
                switch (k.tipus)
                {
                    case 0:
                        kerdes = new SzovegesKerdes(k);
                        break;
                    case 1:
                        kerdes = new EgyszeresValaszto(c, k);
                        break;
                    case 2:
                        kerdes = new Feleletvalasztos(c, k);
                        break;
                    case 3:
                        kerdes = new DatumValaszto(c, k);
                        break;
                    case 4:
                        kerdes = new SzamosKerdes(c, k);
                        break;
                    default:
                        break;
                }
                kerdesekSzama++;
                kerdes.Name = "Kerdes" + kerdesekSzama;
                flowLayoutPanel2.Controls.Add(kerdes);
            }
            /*Label l = new Label();
            flowLayoutPanel1.Controls.Add(l);
            flowLayoutPanel1.Controls.Add(nev);
            flowLayoutPanel1.Controls.Add(ok);
            ok.Text = "Kitöltés befejezése";
            l.Text = "Kérlek írd be a neved:";
            l.Width = 500;
            nev.Width = 500;*/
            Button b = new Button();
            b.Text = "Kitöltés befejezése";
            flowLayoutPanel2.Controls.Add(b);
            b.Click += new EventHandler(button1_Click);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            bekuld();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bekuld()
        {
            List<string> answers = new List<string>();
            foreach (Control c in flowLayoutPanel2.Controls)
            {
                if (c.Name.StartsWith("Kerdes"))
                {
                    List<string> s = ((KerdesTipusKozos)c).getAnswers();
                    if (s == null)
                    {
                        MessageBox.Show("Kérlek válaszolj minden kérdésre!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        answers.AddRange(s);
                    }
                }
            }
            if (c.addKitoltes(answers, kitoltoNeve, kerdoivID))
            {
                MessageBox.Show("Sikeresen kitöltötted a kérdőívet", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Hiba történt a kérés feldolgozása során", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*foreach(string st in answers)
            {
                Console.WriteLine(st);
            }*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            osszido--;
            perc = osszido / 60;
            masodperc = osszido % 60;
            this.Text = kerdoivNev+", megmaradt idő: "+perc+":"+masodperc;
            if (osszido == 0)
            {
                MessageBox.Show("Lejárt az idő.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bekuld();
            }
        }
    }
}
