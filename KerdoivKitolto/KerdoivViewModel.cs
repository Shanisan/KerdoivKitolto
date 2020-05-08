using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerdoivKitolto
{
    public class KerdoivViewModel
    {
        public string nev { get; set; }
        public DateTime kezdet { get; set; }
        public DateTime vege { get; set; }
        public int kitoltesiIdo { get; set; }
        public int kerdesekSzama { get; set; }

        public KerdoivViewModel(string nev, DateTime keztet, DateTime vege, int kitoltes, int kerdesekSzama)
        {
            this.nev = nev;
            this.kezdet = kezdet;
            this.vege = vege;
            this.kitoltesiIdo = kitoltes;
            this.kerdesekSzama = kerdesekSzama;
        }

        public override string ToString()
        {
            return String.Format("nev={0}, kezdet={1}, vege={2}, kitoltesiIdo={3}, kerdesekszama={4}", nev, kezdet, vege, kitoltesiIdo, kerdesekSzama);
        }
    }

}
