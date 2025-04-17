using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK_Functions.Database
{
    public class DbCreate
    {
        public static string dbPath = "Data Source=METD_PJ.db;Version=3;";

        public void ExecuteDB()
        {
            this.CriarBancoDeDados();
            this.CriarMassaDeDados();
        }

        private void CriarBancoDeDados()
        {
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                var pathDB = Directory.GetCurrentDirectory() + "\\Database\\build_db.txt";
                string createTableQuery = File.ReadAllText(pathDB);
                SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        private void CriarMassaDeDados()
        {
            if (IsTableEmpty("Discipline"))
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    StringBuilder @string = new StringBuilder();

                    @string.AppendLine("insert into Discipline (Name) VALUES ('Cálculo 1');");
                    @string.AppendLine("insert into Discipline (Name) VALUES ('Álgebra 1');");
                    @string.AppendLine("insert into Discipline (Name) VALUES ('Introdução ao UML');");


                    SQLiteCommand cmd = new SQLiteCommand(@string.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            
            if (IsTableEmpty("Course"))
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    StringBuilder @string = new StringBuilder();

                    @string.AppendLine("insert into Course (Name) VALUES ('Administração');");
                    @string.AppendLine("insert into Course (Name) VALUES ('Arquitetura e Urbanismo');");
                    @string.AppendLine("insert into Course (Name) VALUES ('Biomedicina');");
                    @string.AppendLine("insert into Course (Name) VALUES ('Direito');");
                    @string.AppendLine("insert into Course (Name) VALUES ('Sociologia');");


                    SQLiteCommand cmd = new SQLiteCommand(@string.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            
            if (IsTableEmpty("Discipline_Course"))
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    StringBuilder @string = new StringBuilder();

                    @string.AppendLine("insert into Discipline_Course (Discipline_Id, Course_Id, Rg_DT) VALUES (1,1,'2025-03-24');");
                    @string.AppendLine("insert into Discipline_Course (Discipline_Id, Course_Id, Rg_DT) VALUES (1,2,'2025-03-24');");
                    @string.AppendLine("insert into Discipline_Course (Discipline_Id, Course_Id, Rg_DT) VALUES (1,3,'2025-03-24');");
                    @string.AppendLine("insert into Discipline_Course (Discipline_Id, Course_Id, Rg_DT) VALUES (2,1,'2025-03-24');");
                    @string.AppendLine("insert into Discipline_Course (Discipline_Id, Course_Id, Rg_DT) VALUES (3,1,'2025-03-24');");
                    @string.AppendLine("insert into Discipline_Course (Discipline_Id, Course_Id, Rg_DT) VALUES (4,1,'2025-03-24');");
                    @string.AppendLine("insert into Discipline_Course (Discipline_Id, Course_Id, Rg_DT) VALUES (5,1,'2025-03-24');");
                    

                    SQLiteCommand cmd = new SQLiteCommand(@string.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }


        }

        // Método para verificar se a tabela está vazia
        private bool IsTableEmpty(string tableName)
        {
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                string query = $"SELECT COUNT(*) FROM {tableName}";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                return count == 0;
            }
        }

        
    }
}
