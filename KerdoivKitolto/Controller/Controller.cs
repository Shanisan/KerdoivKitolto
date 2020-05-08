using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KerdoivKitolto.DAO;
using KerdoivKitolto.Model;

namespace KerdoivKitolto.Controller
{
    public class Controller
    {
        private readonly IDAO dao;
        public Controller(IDAO dao)
        {
            this.dao = dao;
        }
        public T Get<T>(int id)
        {
            return dao.Get<T>(id);
        }
        public List<Kerdoiv> GetList(int id)
        {
            return dao.GetList(id);
        }
    }
}
