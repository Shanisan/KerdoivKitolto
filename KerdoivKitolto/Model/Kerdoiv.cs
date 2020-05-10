using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerdoivKitolto.Model
{
    public class Kerdoiv
    {
        public int id { get; set; }
        public string nev { get; set; }
        public DateTime kezdet { get; set; }
        public DateTime vege { get; set; }
        public int kitoltesiIdo { get; set; }
        public int letrehozoID { get; set; }
        public int kerdesekSzama { get; set; }

        public Kerdoiv(int id, string nev, DateTime keztet, DateTime vege, int kitoltes, int letrehozo, int kerdesekSzama)
        {
            this.id = id;
            this.nev = nev;
            this.kezdet = kezdet;
            this.vege = vege;
            this.kitoltesiIdo = kitoltes;
            letrehozoID = letrehozo;
            this.kerdesekSzama = kerdesekSzama;
        }

        public override string ToString()
        {
            return "Kerdoiv: "+String.Format("id={0}, nev={1}, kezdet={2}, vege={3}, kitoltesiIdo={4}, letrehozoID={5}, kerdesekSzama={6}",
                id, nev, kezdet, vege, kitoltesiIdo, letrehozoID, kerdesekSzama);
        }

        public KerdoivViewModel ToViewModel()
        {
            return new KerdoivViewModel(nev, kezdet, vege, kitoltesiIdo, kerdesekSzama);
        }

    }
}
