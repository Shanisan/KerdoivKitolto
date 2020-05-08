using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerdoivKitolto.Model
{
    public class Kerdoiv
    {
        private int id { get; set; }
        private string nev { get; set; }
        private DateTime kezdet { get; set; }
        private DateTime vege { get; set; }
        private int kitoltesiIdo { get; set; }
        private int letrehozoID { get; set; }

        public Kerdoiv(string nev, DateTime keztet, DateTime vege, int kitoltes)
        {
            this.nev = nev;
            this.kezdet = kezdet;
            this.vege = vege;
            this.kitoltesiIdo = kitoltes;
        }
    }
}
