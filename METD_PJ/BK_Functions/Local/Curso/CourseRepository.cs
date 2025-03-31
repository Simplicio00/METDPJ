using BK_Functions.Database;
using BK_Functions.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK_Functions.Local.Curso
{
    public class CourseRepository : ICourseRepository
    {
        public List<CourseModel> Get()
        {
            var list = new List<CourseModel>();

            using (SQLiteConnection conn = new SQLiteConnection(DbCreate.dbPath))
            {
                conn.Open();

                string query = "SELECT Id, Name FROM Course";
                var coursedb_reader = new SQLiteCommand(query, conn).ExecuteReader();

                while (coursedb_reader.Read())
                {
                    var disciplines = new List<DisciplineModel>();
                    var biggerQuery = new StringBuilder();

                    biggerQuery.Append(
                            "SELECT " +
                           " Discipline.Id AS DisciplineId, " +
                           " Discipline.Name AS DisciplineName " +
                           " FROM " +
                           " Discipline_Course " +

                           " INNER JOIN " +
                           "Discipline ON Discipline_Course.Discipline_Id = Discipline.Id " +
                           
                           " INNER JOIN " +
                           "Course ON Discipline_Course.Course_Id = Course.Id " +

                           "WHERE Discipline_Course.Course_Id = " + coursedb_reader.GetInt32(0));


                    var reader = new SQLiteCommand(biggerQuery.ToString(), conn).ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            disciplines.Add(new DisciplineModel
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                            });
                        }
                    }

                    list.Add(new CourseModel
                    {
                        Id = coursedb_reader.GetInt32(0),
                        Name = coursedb_reader.GetString(1),
                        Disciplines = disciplines
                    });
                }


                conn.Close();
            }

            return list;
        }
    }
}
