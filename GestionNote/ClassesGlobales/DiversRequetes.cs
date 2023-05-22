using MySql.Data.MySqlClient;

namespace GestionNote.ClassesGlobales
{
    public static class DiversRequetes
    {
        public static string RequeteDexecution(string requete)
        {
            string nombreLigne = string.Empty;
            if (GesConSqLite.testConnection)
            {
                string requette = requete;
                MySqlCommand sQLiteCommand = new MySqlCommand(requette, GesConSqLite.connection);

                try
                {
                    nombreLigne = sQLiteCommand.ExecuteNonQuery().ToString();
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message, MessageAI.ProjetName);
                }
            }
            else MessageBox.Show(MessageAI.Connper, MessageAI.ProjetName);

            return nombreLigne;
        }

        public static void RequeteSelectionCombo(ComboBox comboBox, string requete)
        {
            if (GesConSqLite.testConnection)
            {
                MySqlCommand sqLiteCommand = new MySqlCommand(requete, GesConSqLite.connection);
                using (MySqlDataReader lecture = sqLiteCommand.ExecuteReader())
                {
                    try
                    {
                        comboBox.Items.Clear();

                        comboBox.Items.Add(string.Empty);

                        while (lecture.Read())
                        {
                            comboBox.Items.Add(lecture.GetString(0));
                        }
                        lecture.Close();

                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message, MessageAI.ProjetName);
                    }

                }

            }
            else MessageBox.Show(MessageAI.Connper, MessageAI.ProjetName);
        }

        public static void RequeteSelectionList(ListBox comboBox, string requete)
        {
            if (GesConSqLite.testConnection)
            {
                MySqlCommand sqLiteCommand = new MySqlCommand(requete, GesConSqLite.connection);
                using (MySqlDataReader lecture = sqLiteCommand.ExecuteReader())
                {
                    try
                    {
                        comboBox.Items.Clear();


                        while (lecture.Read())
                        {
                            comboBox.Items.Add(lecture.GetString(0));
                        }
                        lecture.Close();

                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message, MessageAI.ProjetName);
                    }

                }

            }
            else MessageBox.Show(MessageAI.Connper, MessageAI.ProjetName);
        }


        public static string RequeteDeCompte(string requete)
        {
            string count = "0";

            if (GesConSqLite.testConnection)
            {

                MySqlCommand sQLiteCommand = new MySqlCommand(requete, GesConSqLite.connection);

                try
                {
                    count = sQLiteCommand.ExecuteScalar().ToString();
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message, MessageAI.ProjetName);
                }

            }
            else MessageBox.Show(MessageAI.Connper, MessageAI.ProjetName);

            if (string.IsNullOrEmpty(count))
            {
                count = "0";
            }

            return count;
        }

        public static bool RequeteDeVerification(string requette)
        {
            bool verif = true;
            string Value = string.Empty;

            if (GesConSqLite.testConnection)
            {
                string requete = requette;
                MySqlCommand mySqlCommand = new MySqlCommand(requete, GesConSqLite.connection);
                using (MySqlDataReader lecture = mySqlCommand.ExecuteReader())
                {
                    try
                    {
                        while (lecture.Read())
                        {
                            Value = lecture.GetString(0);

                        }
                        lecture.Close();
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message, MessageAI.ProjetName);
                    }
                }
            }
            else MessageBox.Show(MessageAI.Connper, MessageAI.ProjetName);

            if (string.IsNullOrEmpty(Value))
            {
                verif = false;
            }

            return verif;
        }
    }
}
