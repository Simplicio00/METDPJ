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

        public void PostDisciplineIntoCourse(int disciplinaid, int cursoid)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DbCreate.dbPath))
            {
                conn.Open();

                string query = "insert into Discipline_Course (Discipline_Id, Course_Id, Rg_DT) values (" + disciplinaid + "," + cursoid + "," + $"'{DateTime.Now.Date.ToString("yyyy-MM-dd")}'" +")";
                new SQLiteCommand(query, conn).ExecuteNonQuery();

                conn.Close();
            }
        }


        public void DeleteDisciplineFromCourse(int disciplinaid, int cursoid)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DbCreate.dbPath))
            {
                conn.Open();

                string query = "delete from Discipline_Course where Discipline_Id = " + disciplinaid + " and " + "Course_Id = " + cursoid;
                new SQLiteCommand(query, conn).ExecuteNonQuery();

                conn.Close();
            }
        }

    }
}
