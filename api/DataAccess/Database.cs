using MySql.Data.MySqlClient;

namespace api.DataAccess
{
    public class Database
    {
        private string server {get;set;}
        private string database {get;set;}
        private string username {get;set;}
        private string port {get;set;}
        private string password {get;set;}
        public string cs {get;set;}
        public Database()
        {
            server = "en1ehf30yom7txe7.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            database = "y8vz7g9cwhin7036";
            username = "a8ga061fxb2tk72l";
            port = "3306";
            password = "ylkk1damtkcjzfbb";

            cs= $"server={server};user={username};database={database};port={port};password={password}";
        }
    }
}