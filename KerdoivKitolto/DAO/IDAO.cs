using KerdoivKitolto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerdoivKitolto.DAO
{
    public interface IDAO
    {
        int GetKerdoivIdByName(string nev);
        List<Kerdoiv> GetList(int id);
        List<Kerdes> getKerdesek(int kerdoivID);
        Dictionary<string, int> getValaszok(int kerdesID);
        bool addKitoltes(string answers, string name, int kerdoivID);
    }
}
