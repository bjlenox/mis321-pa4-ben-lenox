using api.DataAccess;
using MySql.Data.MySqlClient;
using api.Models;
using Org.BouncyCastle.Cms;

namespace api
{
    public class WorkoutUtility
    {
        public static List<Workout> GetAllWorkouts() 
        {
            List<Workout> workouts = new List<Workout>();

            Database db = new Database();
            using var con =new MySqlConnection(db.cs);
            con.Open();
            string stm = "Select * from workouts order by date desc;";

            using var cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                workouts.Add(new Workout
                {
                    Id = rdr.GetInt32(0),
                    Type = rdr.GetString(1),
                    Distance = rdr.GetDouble(2),
                    Date = rdr.GetString(3),
                    Pinned = rdr.GetBoolean(4),
                    Deleted = rdr.GetBoolean(5)
                });
            }
            con.Close();
            return workouts;
        }
        public static void AddWorkout(Workout value)
        {
            Console.WriteLine(value.Type);
            Database db = new Database();
            using var con =new MySqlConnection(db.cs);
            
            con.Open();
            string stm = "Insert into workouts(activityType, distance, date, pinned, deleted) values(@activityType, @distance, @date, @pinned, @deleted) ;";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@activityType", value.Type);
            cmd.Parameters.AddWithValue("@distance", value.Distance);
            cmd.Parameters.AddWithValue("@date", value.Date);
            cmd.Parameters.AddWithValue("@pinned", 0);
            cmd.Parameters.AddWithValue("@deleted", 0);
            
            cmd.ExecuteNonQuery();

            string stm1 = "select date from workouts order by convert(DATE, date) DESC;";
            using var cmd1 = new MySqlCommand(stm1, con);
            cmd1.ExecuteNonQuery();

            con.Close();

            

        }
        public static void PinWorkout(Workout value)
        {
            Database db = new Database();
            using var con =new MySqlConnection(db.cs);
            
            con.Open();
            string stm = "Update workouts set pinned = @pinned where id=@id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@pinned", value.Pinned);
            cmd.Parameters.AddWithValue("@id", value.Id);

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public static void DeleteWorkout(Workout value)
        {
            Database db = new Database();
            using var con =new MySqlConnection(db.cs);
            
            con.Open();
            string stm = "Update workouts set deleted = @deleted where id=@id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@deleted", true);
            cmd.Parameters.AddWithValue("@id", value.Id);
            
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}