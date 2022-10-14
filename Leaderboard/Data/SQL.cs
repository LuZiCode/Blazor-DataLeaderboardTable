using System.Data;
using System.Data.SqlClient;

namespace Leaderboard.Data
{
    public class SQL
    {
        SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Leaderboard;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public List<HighscoreItem> ReadLeaderboard()
        {
            conn.Open();
            List<HighscoreItem> list = new List<HighscoreItem>();
            SqlCommand command = new SqlCommand("Select * from [Leaderboard]", conn);
            //command.Parameters.AddWithValue("@zip", "india");
            //// int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    HighscoreItem f = new()
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        Playername = reader["Playername"].ToString(),
                        Highscore = double.Parse(reader["Highscore"].ToString())
                    };
                    list.Add(f);

                    Console.WriteLine(String.Format("{0}", reader["id"]));
                }
            }

            conn.Close();
            return list;
        }

        public bool CreatePlayer(HighscoreItem h)
        {
            using (conn)
            {
                var cmd = new SqlCommand(
                    "INSERT INTO [Leaderboard] " +
                    "VALUES (@playername, @highscore)", conn);
                cmd.Parameters.Add("@playername", SqlDbType.NVarChar).Value = h.Playername;
                cmd.Parameters.Add("@highscore", SqlDbType.Int).Value = h.Highscore;
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1) return true; else return false;
            }
        }

        public void DeletePlayer()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("Delete Leaderboard where Id='" + DTO.Id + "'", conn);
            cmd.Parameters.AddWithValue("@Id", DTO.Id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
