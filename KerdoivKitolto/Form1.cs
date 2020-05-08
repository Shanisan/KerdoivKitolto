using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KerdoivKitolto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListazasGombAction(object sender, EventArgs e)
        {

        }

        private void KitoltesGombAction(object sender, EventArgs e)
        {
            Console.WriteLine("Kitoltes");
        }
    }
}
