using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using KerdoivKitolto.ControllerNS;
using KerdoivKitolto.DAO;
using KerdoivKitolto.Model;

namespace KerdoivKitolto
{
    public partial class Form1 : Form
    {
        DataTable kerdoivekTablazat = new DataTable("Kitölthető kérdőívek");
        public static KerdoivKitolto.ControllerNS.Controller cont = new KerdoivKitolto.ControllerNS.Controller(new DaoAdo());

        private string kerdoivNev = "";
        private int kerdoivIdo = 0;
        public Form1()
        {
            InitializeComponent();
            kerdoivekTablazat.Columns.Add("Név");
            kerdoivekTablazat.Columns.Add("Kitöltés kezdete");
            kerdoivekTablazat.Columns.Add("Kitöltés vége");
            kerdoivekTablazat.Columns.Add("Kitöltési idő");
            kerdoivekTablazat.Columns.Add("Kérdések száma");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            if (!showKerdoivek())
            {
                MessageBox.Show("Nincsenek adatok az adatbázisban vagy az nem létezik. Kérem futtasssa az adminisztrácis alkalmazást először", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            
            Text = "A kitölthető kérdőívek";
        }

        private bool showKerdoivek()
        {
            List<Kerdoiv> list = cont.GetList(-1);
            if (list == null)
            {
                //Console.WriteLine("List is null");
                return false;
            }
            else
            {
                foreach (var item in list)
                {
                    if (item.kezdet < DateTime.Now && item.vege > DateTime.Now)
                    {
                        //Console.WriteLine(item.ToString());
                        kerdoivekTablazat.Rows.Add(new object[] { item.nev, item.kezdet, item.vege, item.kitoltesiIdo, item.kerdesekSzama });
                    }
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = kerdoivekTablazat;
                dataGridView1.Visible = true;
                return true;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            kerdoivNev = (string) ((DataGridView)sender).SelectedRows[0].Cells["Név"].Value;
            DataGridView dgv = (DataGridView)sender;
            kerdoivIdo = Int32.Parse((string) dgv.SelectedRows[0].Cells["Kitöltési idő"].Value);
            //Console.WriteLine(kerdoivNev);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kerdoivNev == "")
            {
                MessageBox.Show("Nincs kijelölve elem!\nKattintson valamelyik oszlopra!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                KerdoivForm kf = new KerdoivForm(cont, kerdoivNev, kerdoivIdo, textBox1.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
