using KerdoivKitolto.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerdoivKitolto.DAO
{
    public class DaoAdo : IDAO
    {
        private static readonly string connectionString = @"Data Source=C:\\Users\\barat\\Kerdoiv-BSG\\data\\kerdoiv.db";
        public T Get<T>(int id)
        {
            throw new NotImplementedException();
        }

        public List<Kerdoiv> GetList(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = conn.CreateCommand())
            {
                //Console.WriteLine("Conn="+conn.ToString());
                conn.Open();
                command.CommandText = "SELECT Kerdoiv.id, Kerdoiv.nev, COUNT(Kerdes.id) AS kerdesek, kezdesiIdo, befejezesiIdo, kitoltesiIdo, letrehozoID" +
                    " FROM Kerdoiv LEFT JOIN Kerdes ON Kerdoiv.id=Kerdes.kerdoivID GROUP BY Kerdoiv.id;";
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    List<Kerdoiv> kerdoivek = new List<Kerdoiv>();
                    while (reader.Read())
                    {
                        /*Console.WriteLine("Daoban: "+String.Format("id={0}, nev={1}, kezdet={2}, vege={3}, kitoltesiIdo={4}, letrehozoID={5}, kerdesekSzama={6}",
                            reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("nev")),
                            reader.GetDateTime(reader.GetOrdinal("kezdesiIdo")),
                            reader.GetDateTime(reader.GetOrdinal("befejezesiIdo")),
                            reader.GetInt32(reader.GetOrdinal("kitoltesiIdo")),
                            reader.GetInt32(reader.GetOrdinal("letrehozoID")),
                            reader.GetInt32(reader.GetOrdinal("kerdesek"))));*/
                        kerdoivek.Add(new Kerdoiv(
                            reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("nev")),
                            reader.GetDateTime(reader.GetOrdinal("kezdesiIdo")),
                            reader.GetDateTime(reader.GetOrdinal("befejezesiIdo")),
                            reader.GetInt32(reader.GetOrdinal("kitoltesiIdo")),
                            reader.GetInt32(reader.GetOrdinal("letrehozoID")),
                            reader.GetInt32(reader.GetOrdinal("kerdesek"))
                            ));
                    }
                    if (kerdoivek.Count > 0)
                    {
                        return kerdoivek;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
