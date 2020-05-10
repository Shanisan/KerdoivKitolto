using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerdoivKitolto.Model
{
    public class Kerdes
    {
        public int id { get; set; }
        public int kerdoivID { get; set; }
        public int sorszam { get; set; }
        public int tipus { get; set; }
        public string szoveg { get; set; }
        public string kep { get; set; }

    public Kerdes(int id, int kerdoivID, int sorszam, int tipus, string szoveg, string kep)
        {
            this.id = id;
            this.kerdoivID = kerdoivID;
            this.sorszam = sorszam;
            this.tipus = tipus;
            this.szoveg = szoveg;
            this.kep = kep;
        }

        public override string ToString()
        {
            return "Kerdes: "+String.Format("id={0}, kerdoivID={1}, sorszam={2}, tipus={3}, szoveg={4}, kep={5}",  id, kerdoivID, sorszam, tipus, szoveg, kep);
        }
    }
}
