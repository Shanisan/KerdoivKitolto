using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KerdoivKitolto.Controller;
using KerdoivKitolto.DAO;
using KerdoivKitolto.Model;

namespace KerdoivKitolto
{
    public partial class Form1 : Form
    {
        DataTable kerdoivekTablazat = new DataTable("Kitölthető kérdőívek");
        public static KerdoivKitolto.Controller.Controller cont = new KerdoivKitolto.Controller.Controller(new DaoAdo());
        public Form1()
        {
            InitializeComponent();
            kerdoivekTablazat.Columns.Add("Név");
            kerdoivekTablazat.Columns.Add("Kitöltés kezdete");
            kerdoivekTablazat.Columns.Add("Kitöltés vége");
            kerdoivekTablazat.Columns.Add("Kitöltési idő");
            kerdoivekTablazat.Columns.Add("Kérdések száma");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            showKerdoivek();
            Text = "A kitölthető kérdőívek";
        }

        private void showKerdoivek()
        {
            List<Kerdoiv> list = cont.GetList(-1);
            foreach (var item in list)
            {
                KerdoivViewModel kvm = item.ToViewModel();
                if(kvm.kezdet<DateTime.Now && kvm.vege > DateTime.Now)
                {
                    //Console.WriteLine(item.ToString());
                    kerdoivekTablazat.Rows.Add(new object[] { kvm.nev, kvm.kezdet, kvm.vege, kvm.kitoltesiIdo, kvm.kerdesekSzama });
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = kerdoivekTablazat;
            dataGridView1.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(sender.ToString());
        }

        private void kérdőívekToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
