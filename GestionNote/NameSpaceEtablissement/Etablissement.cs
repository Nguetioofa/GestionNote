using GestionNote.ClassesGlobales;
using MySql.Data.MySqlClient;

namespace GestionNote.NameSpaceEtablissement
{
    internal class Etablissement
    {
        private int _IdEtablissement;
        private string _NomEtablissement;
        private string _VilleEtablissements;
        private int _Telephone;

        public Etablissement()
        {
            _IdEtablissement = 0;
            _NomEtablissement = string.Empty;
            _VilleEtablissements = string.Empty;
            _Telephone = 0;
        }

        public int IdEtablissement { get => _IdEtablissement; set => _IdEtablissement = value; }
        public string NomEtablissement { get => _NomEtablissement; set => _NomEtablissement = value; }
        public string VilleEtablissements { get => _VilleEtablissements; set => _VilleEtablissements = value; }
        public int Telephone { get => _Telephone; set => _Telephone = value; }

        public void AfficherEtablissement(DataGridView dataGridView, string requette)
        {
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
                            Etablissement etablissement = new Etablissement();

                            etablissement._IdEtablissement = (int)lecture["idetablissement"];
                            etablissement._NomEtablissement = lecture["NomEtablissement"].ToString();
                            etablissement._VilleEtablissements = lecture["VilleEtablissement"].ToString();
                            etablissement._Telephone = (int)lecture["Telephone"];

                            dataGridView.Rows.Add(etablissement._IdEtablissement, etablissement._NomEtablissement, etablissement._VilleEtablissements, etablissement._Telephone);

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

        public int AjouterEtablissement()
        {
            int NombreLigne = 0;
            if (GesConSqLite.testConnection)
            {
                try
                {

                    string requete = "INSERT INTO etablissement (NomEtablissement,VilleEtablissement,Telephone) values (@NomEtablissement,@VilleEtablissements,@Telephone);";
                    MySqlCommand SqlCommand = new MySqlCommand(requete, GesConSqLite.connection);
                    SqlCommand.Parameters.Add("@NomEtablissement", MySqlDbType.VarString, 45).Value = _NomEtablissement;
                    SqlCommand.Parameters.Add("@VilleEtablissements", MySqlDbType.VarString, 45).Value = _VilleEtablissements;
                    SqlCommand.Parameters.Add("@Telephone", MySqlDbType.Int32, 9).Value = _Telephone;

                    int nombreLigne = SqlCommand.ExecuteNonQuery();
                    if (nombreLigne > 0)
                    {
                        MessageBox.Show(MessageAI.Ajouter, MessageAI.ProjetName);
                    }
                    SqlCommand.Parameters.Clear();


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, MessageAI.ProjetName);
                }


            }
            else MessageBox.Show(MessageAI.Connper, MessageAI.ProjetName);
            return NombreLigne;
        }
    }
}
