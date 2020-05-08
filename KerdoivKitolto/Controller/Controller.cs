using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KerdoivKitolto.DAO;

namespace KerdoivKitolto.Controller
{
    class Controller
    {
        private readonly IDAO dao;
        public Controller(IDAO dao)
        {
            this.dao = dao;
        }
        T Get<T>(int id)
        {
            return dao.Get<T>(id);
        }
        List<T> GetList<T>(int id)
        {
            return dao.GetList<T>(id);
        }
    }
}
