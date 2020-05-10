using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KerdoivKitolto
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static string pathToData = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+"Kerdoiv-BSG\\";
        public static Image ResizeImage(Image image, Size newSize)
        {
            Image img = new Bitmap(newSize.Width, newSize.Height);
            using (Graphics GFX = Graphics.FromImage((Bitmap)img))
            {
                GFX.DrawImage(image, new Rectangle(Point.Empty, newSize));
            }
            return img;
        }
    }
}
