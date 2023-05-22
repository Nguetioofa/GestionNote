using GestionNote.ClassesGlobales;
using MySql.Data.MySqlClient;

namespace GestionNote.NameSpaceEtudiant
{
    internal class Etudiant
    {
        private int _IdEtudiant;
        private string _MatriculeEtudiant;
        private string _NameEtudiant;
        private string _PrenomEtudiant;
        private string _TelephoneEtudiant;
        private string _FiliereEtudiant;
        private int _NiveauEtudiant;
        private string _AnnneeAcademique;
        private DateTime _DateNaiss;
        private int _EtablissementEtudiant;

        public Etudiant()
        {
            _IdEtudiant = 0;
            _MatriculeEtudiant = string.Empty;
            _NameEtudiant = string.Empty;
            _PrenomEtudiant = string.Empty;
            _TelephoneEtudiant = string.Empty;
            _FiliereEtudiant = string.Empty;
            _NiveauEtudiant = 0;
            _AnnneeAcademique = string.Empty;
            _DateNaiss = DateTime.Today;
            _EtablissementEtudiant = 0;
        }

        public int IdEtudiant { get => _IdEtudiant; set => _IdEtudiant = value; }
        public string NameEtudiant { get => _NameEtudiant; set => _NameEtudiant = value; }
        public string PrenomEtudiant { get => _PrenomEtudiant; set => _PrenomEtudiant = value; }
        public string TelephoneEtudiant { get => _TelephoneEtudiant; set => _TelephoneEtudiant = value; }
        public string FiliereEtudiant { get => _FiliereEtudiant; set => _FiliereEtudiant = value; }
        public int NiveauEtudiant { get => _NiveauEtudiant; set => _NiveauEtudiant = value; }
        public string AnnneeAcademique { get => _AnnneeAcademique; set => _AnnneeAcademique = value; }
        public DateTime DateNaiss { get => _DateNaiss; set => _DateNaiss = value; }
        public string MatriculeEtudiant { get => _MatriculeEtudiant; set => _MatriculeEtudiant = value; }
        public int EtablissementEtudiant { get => _EtablissementEtudiant; set => _EtablissementEtudiant = value; }

        internal void AfficherEtudiant(DataGridView dataGridView1, string requette)
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
                            Etudiant etudiant = new Etudiant();

                            etudiant._IdEtudiant = (int)lecture["id_etudiants"];
                            etudiant._MatriculeEtudiant = lecture["matricule_etudiants"].ToString();
                            etudiant._NameEtudiant = lecture["nom_etudiants"].ToString();
                            etudiant._PrenomEtudiant = lecture["prenom_etudiants"].ToString();
                            etudiant._FiliereEtudiant = lecture["filiere_etudiants"].ToString();
                            etudiant._NiveauEtudiant = Convert.ToInt32(lecture["niveau_etudiants"]);
                            etudiant._AnnneeAcademique = lecture["annee_academique"].ToString();
                            etudiant._DateNaiss = Convert.ToDateTime(lecture["date_naiss_etudiants"]);

                            dataGridView1.Rows.Add(etudiant._IdEtudiant, etudiant._MatriculeEtudiant, etudiant._NameEtudiant, etudiant._PrenomEtudiant, etudiant._FiliereEtudiant, etudiant._NiveauEtudiant, etudiant._AnnneeAcademique, etudiant._DateNaiss, lecture["NomEtablissement"].ToString());

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

        internal void AfficherEtudiantNotes(DataGridView dataGridView1, string requette)
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
                            Etudiant etudiant = new Etudiant();

                            etudiant._IdEtudiant = (int)lecture["id_etudiants"];
                            etudiant._MatriculeEtudiant = lecture["matricule_etudiants"].ToString();
                            etudiant._NameEtudiant = lecture["nom_etudiants"].ToString();
                            etudiant._PrenomEtudiant = lecture["prenom_etudiants"].ToString();
                            etudiant._FiliereEtudiant = lecture["filiere_etudiants"].ToString();
                            etudiant._NiveauEtudiant = Convert.ToInt32(lecture["niveau_etudiants"]);
                            etudiant._AnnneeAcademique = lecture["annee_academique"].ToString();
                            etudiant._DateNaiss = Convert.ToDateTime(lecture["date_naiss_etudiants"]);

                            dataGridView1.Rows.Add(etudiant._IdEtudiant, etudiant._MatriculeEtudiant, etudiant._NameEtudiant, etudiant._PrenomEtudiant, etudiant._FiliereEtudiant, etudiant._NiveauEtudiant, etudiant._AnnneeAcademique, etudiant._DateNaiss, lecture["NomEtablissement"].ToString());

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

        internal int AjouterEtudiant()
        {
            int NombreLigne = 0;
            if (GesConSqLite.testConnection)
            {
                try
                {

                    string requete = "INSERT INTO etudiants (id_etudiants, nom_etudiants, prenom_etudiants, telephone_etudiants, filiere_etudiants, niveau_etudiants, annee_academique, date_naiss_etudiants, matricule_etudiants, idetablissement) VALUES (NULL, @NameEtudiant, @PrenomEtudiant, @TelephoneEtudiant, @FiliereEtudiant, @NiveauEtudiant, @AnnneeAcademique, @DateNaiss, @MatriculeEtudiant, @EtablissementEtudiant);";
                    MySqlCommand SqlCommand = new MySqlCommand(requete, GesConSqLite.connection);
                    SqlCommand.Parameters.Add("@MatriculeEtudiant", MySqlDbType.VarChar, 45).Value = _MatriculeEtudiant;
                    SqlCommand.Parameters.Add("@NameEtudiant", MySqlDbType.VarChar, 45).Value = _NameEtudiant;
                    SqlCommand.Parameters.Add("@PrenomEtudiant", MySqlDbType.VarChar, 45).Value = _PrenomEtudiant;
                    SqlCommand.Parameters.Add("@TelephoneEtudiant", MySqlDbType.VarChar, 9).Value = _TelephoneEtudiant;
                    SqlCommand.Parameters.Add("@FiliereEtudiant", MySqlDbType.VarChar, 45).Value = _FiliereEtudiant;
                    SqlCommand.Parameters.Add("@NiveauEtudiant", MySqlDbType.Int32, 11).Value = _NiveauEtudiant;
                    SqlCommand.Parameters.Add("@AnnneeAcademique", MySqlDbType.VarChar, 9).Value = _AnnneeAcademique;
                    SqlCommand.Parameters.Add("@DateNaiss", MySqlDbType.Date).Value = _DateNaiss;
                    SqlCommand.Parameters.Add("@EtablissementEtudiant", MySqlDbType.Int32, 11).Value = _EtablissementEtudiant;

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
