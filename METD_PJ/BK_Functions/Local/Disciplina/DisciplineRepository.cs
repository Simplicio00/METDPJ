using BK_Functions.Database;
using BK_Functions.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK_Functions.Local.Disciplina
{
    public class DisciplineRepository : IDisciplineRepository
    {
        public List<DisciplineModel> Get()
        {
            var list = new List<DisciplineModel>();

            using (SQLiteConnection conn = new SQLiteConnection(DbCreate.dbPath))
            {
                conn.Open();

                string query = "SELECT * FROM Discipline";
                var reader = new SQLiteCommand(query, conn).ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new DisciplineModel
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                    });
                }

                conn.Close();
            }

            return list;
        }

    }
}
