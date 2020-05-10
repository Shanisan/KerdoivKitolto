using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KerdoivKitolto.DAO;
using KerdoivKitolto.Model;

namespace KerdoivKitolto.ControllerNS
{
    public class Controller
    {
        private readonly IDAO dao;
        public Controller(IDAO dao)
        {
            this.dao = dao;
        }
        public int GetKerdoivIdByName(string nev)
        {
            return dao.GetKerdoivIdByName(nev);
        }
        public List<Kerdoiv> GetList(int id)
        {
            return dao.GetList(id);
        }
        public List<Kerdes> getKerdesek(int kerdoivID)
        {
            return dao.getKerdesek(kerdoivID);
        }

        public Dictionary<string, int> getValaszok(int kerdesID)
        {
            return dao.getValaszok(kerdesID);
        }

        internal bool addKitoltes(List<string> answers, string name, int kerdoivID)
        {

            string finalAnswer = "";
            foreach (string s in answers)
            {
                finalAnswer += s;
                finalAnswer += "|";
            }
            finalAnswer=finalAnswer.Remove(finalAnswer.Length - 1, 1);
            Console.WriteLine(finalAnswer);
            return dao.addKitoltes(finalAnswer, name, kerdoivID);
        }
    }
}
