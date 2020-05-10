using KerdoivKitolto.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerdoivKitolto.DAO
{
    public class DaoAdo : IDAO
    {
        private static readonly string connectionString = @"Data Source=C:\\Users\\barat\\Kerdoiv-BSG\\data\\kerdoiv.db";

        public bool addKitoltes(string answers, string name, int kerdoivID)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = conn.CreateCommand())
            {
                conn.Open();
                SQLiteTransaction transaction = conn.BeginTransaction();
                command.CommandText = "INSERT INTO Kitoltes(kerdoivID, kitolto, valaszok) VALUES (@kerdoivID, @kitolto, @valaszok)";
                SQLiteParameter kerdoivParam = new SQLiteParameter("@kerdoivID", kerdoivID);
                SQLiteParameter kitoltoParam = new SQLiteParameter("@kitolto", name);
                SQLiteParameter valaszokParam = new SQLiteParameter("@valaszok", answers);
                command.Parameters.Add(kerdoivParam);
                command.Parameters.Add(kitoltoParam);
                command.Parameters.Add(valaszokParam);

                command.Prepare();
                if (command.ExecuteNonQuery()==1)
                {
                    transaction.Commit();
                    return true;
                }
                else
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public List<Kerdes> getKerdesek(int kerdoivID)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = "SELECT id, kerdoivID, szoveg, sorszam, kep, tipus FROM Kerdes WHERE kerdoivID="+kerdoivID;
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    List<Kerdes> kerdesek = new List<Kerdes>();
                    while (reader.Read())
                    {
                        Console.WriteLine("Daoban: " + String.Format("id={0}", reader.GetInt32(reader.GetOrdinal("id"))));
                        Console.WriteLine("Daoban: " + String.Format("kerdoivID={0}",  reader.GetInt32(reader.GetOrdinal("kerdoivID"))));
                        Console.WriteLine("Daoban: " + String.Format("sorszam={0}", reader.GetInt32(reader.GetOrdinal("sorszam"))));
                        Console.WriteLine("Daoban: " + String.Format("tipus={0}", reader.GetInt32(reader.GetOrdinal("tipus"))));
                        Console.WriteLine("Daoban: " + String.Format("szoveg={0}",reader.GetString(reader.GetOrdinal("szoveg"))));
                        Console.WriteLine("Daoban: " + String.Format("kep={0}",
                            reader.GetString(reader.GetOrdinal("kep"))
                            )
                            );
                        Kerdes k = new Kerdes(
                            reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetInt32(reader.GetOrdinal("kerdoivID")),
                            reader.GetInt32(reader.GetOrdinal("sorszam")),
                            reader.GetInt32(reader.GetOrdinal("tipus")),
                            reader.GetString(reader.GetOrdinal("szoveg")),
                            reader.GetString(reader.GetOrdinal("kep"))
                            );
                        Console.WriteLine(k.ToString());
                        kerdesek.Add(k);
                    }
                    if (kerdesek.Count > 0)
                    {
                        return kerdesek;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public int GetKerdoivIdByName(string nev)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = conn.CreateCommand())
            {
                //Console.WriteLine("Conn="+conn.ToString());
                conn.Open();
                command.CommandText = "SELECT id FROM Kerdoiv WHERE nev='"+nev+"';";
                Console.WriteLine(command.CommandText);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    List<Kerdoiv> kerdoivek = new List<Kerdoiv>();
                    while (reader.Read())
                    {
                        return reader.GetInt32(reader.GetOrdinal("id"));
                    }
                    return -1;
                }
            }
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
                        Console.WriteLine("Daoban: "+String.Format("id={0}, nev={1}, kezdet={2}, vege={3}, kitoltesiIdo={4}, letrehozoID={5}, kerdesekSzama={6}",
                            reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("nev")),
                            reader.GetDateTime(reader.GetOrdinal("kezdesiIdo")),
                            reader.GetDateTime(reader.GetOrdinal("befejezesiIdo")),
                            reader.GetInt32(reader.GetOrdinal("kitoltesiIdo")),
                            reader.GetInt32(reader.GetOrdinal("letrehozoID")),
                            reader.GetInt32(reader.GetOrdinal("kerdesek"))));
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

        public Dictionary<string, int> getValaszok(int kerdesID)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = "SELECT szoveg, id FROM Valasz WHERE kerdesID=" + kerdesID+" ORDER BY sorszam";
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    Dictionary<string, int> valaszok = new Dictionary<string, int>();
                    while(reader.Read()){
                        valaszok.Add(reader.GetString(reader.GetOrdinal("szoveg")), reader.GetInt32(reader.GetOrdinal("id")));
                    }
                    if (valaszok.Count > 0)
                    {
                        return valaszok;
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
