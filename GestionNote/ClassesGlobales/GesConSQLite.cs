using MySql.Data.MySqlClient;

namespace GestionNote.ClassesGlobales
{
    public static class GesConSqLite
    {
        static string connectionString = new MySqlConnectionStringBuilder()
        { //warrior
            Server = "Localhost",
            Port = 3309,
            Database = "gestionnote",
            UserID = "root",
            Password = "1234"
        }.ToString();
        /*   static string connectionString = new MySqlConnectionStringBuilder()
           {//Alex 
               Server = "Localhost",
               Port = 3308,
               Database = "gestionnote",
               UserID = "root",
               Password = "2227"
           }.ToString();*/
        /*        static string connectionString = new MySqlConnectionStringBuilder()
                {//kinra
                    Server = "Localhost",
                    Port = 3306,
                    Database = "gestionnote",
                    UserID = "root",
                    Password = "root"
                }.ToString();*/

        //static string connectionString = new MySqlConnectionStringBuilder()
        //{//universel Wamp
        //    Server = "Localhost",
        //    Port = 3306,
        //    Database = "gestionnote",
        //    UserID = "root",
        //    Password = ""
        //}.ToString();
        public static MySqlConnection connection = null;
        public static bool testConnection;



        public static void OpenConn()
        {


            connection = new MySqlConnection(connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                testConnection = true;

            }
        }

        public static void CloseConn()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Close();
                testConnection = false;
            }
        }





    }
}
