using GestionNote.ClassesGlobales;
using MySql.Data.MySqlClient;

namespace GestionNote.NameSpaceMatiere
{
    internal class Matiere
    {
        private int _CodeMatiere;
        private string _NameMatiere;
        private string _NbCredit;

        public Matiere()
        {
            _CodeMatiere = 0;
            _NameMatiere = string.Empty;
            _NbCredit = string.Empty;
        }

        public int CodeMatiere { get => _CodeMatiere; set => _CodeMatiere = value; }
        public string NameMatiere { get => _NameMatiere; set => _NameMatiere = value; }
        public string NbCredit { get => _NbCredit; set => _NbCredit = value; }

        internal int AjouterMatiere()
        {
            int NombreLigne = 0;
            if (GesConSqLite.testConnection)
            {
                try
                {

                    string requete = "INSERT INTO matiere (code_matiere, nom_matiere, nbr_credit_matiere) VALUES (NULL, @NameMatiere, @NbCredit);";
                    MySqlCommand SqlCommand = new MySqlCommand(requete, GesConSqLite.connection);
                    SqlCommand.Parameters.Add("@NameMatiere", MySqlDbType.VarString, 45).Value = _NameMatiere;
                    SqlCommand.Parameters.Add("@NbCredit", MySqlDbType.VarString, 2).Value = _NbCredit;

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

        public void AfficherMatiere(DataGridView dataGridView, string requette)
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
                            Matiere matiere = new Matiere();

                            matiere._CodeMatiere = (int)lecture["code_matiere"];
                            matiere._NameMatiere = lecture["nom_matiere"].ToString();
                            matiere._NbCredit = lecture["nbr_credit_matiere"].ToString();

                            dataGridView.Rows.Add(matiere._CodeMatiere, matiere._NameMatiere, matiere._NbCredit);

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
    }
}
