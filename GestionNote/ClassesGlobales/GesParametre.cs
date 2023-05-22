using MySql.Data.MySqlClient;

namespace GestionNote.ClassesGlobales
{
    public static class GesParametre
    {
        internal static Dictionary<string, string> DicParametres = new Dictionary<string, string>();
        //internal static List<Parametre> ListParametres1 { get => ListParametres; set => ListParametres = value; }

        public static void InitParametre()
        {
            if (GesConSqLite.testConnection)
            {
                try
                {
                    string requete = "select * from Parametre;";
                    MySqlCommand sQLiteCommand = new MySqlCommand(requete, GesConSqLite.connection);

                    using (MySqlDataReader lecture = sQLiteCommand.ExecuteReader())
                    {
                        while (lecture.Read())
                        {
                            DicParametres.Add(lecture["NomParametre"].ToString(), lecture["ValeurParametre"].ToString());
                        }


                    }
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message, MessageAI.ProjetName);
                }

            }
            else
                MessageBox.Show(MessageAI.Connper, MessageAI.ProjetName);

        }
    }
}
