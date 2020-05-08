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
        T Get<T>(int id);
        List<Kerdoiv> GetList(int id);
    }
}
