using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace WpfApp9
{
    public class DatabaseManager
    {
        private string _connectionString;

        public DatabaseManager(string dbFilePath)
        {
            _connectionString = $"Data Source={dbFilePath};Version=3;";
        }

        public List<string> GetEnsembleCompactDiscs(int ensembleId)
        {
            List<string> cdTitles = new List<string>();

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT Title FROM CompactDiscs WHERE EnsembleId = @EnsembleId";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EnsembleId", ensembleId);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["Title"].ToString();
                            cdTitles.Add(title);
                        }
                    }
                }
            }

            return cdTitles;
        }

        public int CountMusicalWorks(int ensembleId)
        {
            int count = 0;

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) AS TotalWorks FROM MusicalWorks WHERE EnsembleId = @EnsembleId";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EnsembleId", ensembleId);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            count = Convert.ToInt32(reader["TotalWorks"]);
                        }
                    }
                }
            }

            return count;
        }

        public List<string> GetBestSellingCompactDiscs(int year)
        {
            List<string> bestSellers = new List<string>();

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT Title FROM CompactDiscs WHERE CopiesSoldCurrentYear = (SELECT MAX(CopiesSoldCurrentYear) FROM CompactDiscs WHERE ReleaseYear <= @Year)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Year", year);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["Title"].ToString();
                            bestSellers.Add(title);
                        }
                    }
                }
            }

            return bestSellers;
        }

        public void UpdateCompactDisc(int cdId, int copiesSoldCurrentYear)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE CompactDiscs SET CopiesSoldCurrentYear = @CopiesSoldCurrentYear WHERE Id = @CdId";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CopiesSoldCurrentYear", copiesSoldCurrentYear);
                    command.Parameters.AddWithValue("@CdId", cdId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertNewEnsemble(string name, string leader, int formationYear, string city, string country)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Ensembles (Name, Leader, FormationYear, City, Country) VALUES (@Name, @Leader, @FormationYear, @City, @Country)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Leader", leader);
                    command.Parameters.AddWithValue("@FormationYear", formationYear);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@Country", country);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
