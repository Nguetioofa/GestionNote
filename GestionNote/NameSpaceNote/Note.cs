using GestionNote.ClassesGlobales;
using MySql.Data.MySqlClient;

namespace GestionNote.NameSpaceNote
{
    internal class Note
    {
        private int _IdNote;
        private decimal _CcNote;
        private decimal _TpNote;
        private decimal _ExamNote;
        private decimal _RatrappageNote;
        private int _IdEtudiant;
        private int _CodeMatiere;

        public Note()
        {
            _IdNote = 0;
            _CcNote = 0;
            _TpNote = 0;
            _ExamNote = 0;
            _RatrappageNote = 0;
            _IdEtudiant = 0;
            _CodeMatiere = 0;
        }

        public int IdNote { get => _IdNote; set => _IdNote = value; }
        public decimal CcNote { get => _CcNote; set => _CcNote = value; }
        public decimal TpNote { get => _TpNote; set => _TpNote = value; }
        public decimal ExamNote { get => _ExamNote; set => _ExamNote = value; }
        public decimal RatrappageNote { get => _RatrappageNote; set => _RatrappageNote = value; }
        public int IdEtudiant { get => _IdEtudiant; set => _IdEtudiant = value; }
        public int CodeMatiere { get => _CodeMatiere; set => _CodeMatiere = value; }


        public void AfficherNote(DataGridView dataGridView, string requette, string session)
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
                            double notecc = 0;
                            double notetp = 0;
                            string decision = string.Empty;
                            double notefinal = 0;
                            if (session.ToUpper() == "RATTRAPAGE")
                            {
                                if (string.IsNullOrEmpty(lecture["cc_note"].ToString()) || string.IsNullOrEmpty(lecture["tp_note"].ToString()) || string.IsNullOrEmpty(lecture["ratrapage_note"].ToString()))
                                {

                                    decision = "REFUSE";
                                    dataGridView.Rows.Add(lecture["matricule_etudiants"].ToString(), lecture["nom"].ToString(), lecture["cc_note"].ToString(), lecture["ratrapage_note"].ToString(), lecture["tp_note"].ToString(), string.Empty, decision, session);

                                }
                                else
                                {
                                    notecc = Convert.ToDouble(lecture["cc_note"]);
                                    notetp = Convert.ToDouble(lecture["tp_note"]);
                                    double notetRatt = Convert.ToDouble(lecture["ratrapage_note"]);

                                    notefinal = notecc * 0.2 + notetp * 0.1 + notetRatt * 0.7;
                                    if (notefinal >= 10)
                                    {
                                        decision = "VALIDE";
                                    }
                                    else
                                    {
                                        decision = "REFUSE";
                                    }
                                    dataGridView.Rows.Add(lecture["matricule_etudiants"].ToString(), lecture["nom"].ToString(), lecture["cc_note"].ToString(), lecture["ratrapage_note"].ToString(), lecture["tp_note"].ToString(), notefinal, decision, session);

                                }

                            }
                            else if (session.ToUpper() == "EXAMEN")
                            {
                                if (string.IsNullOrEmpty(lecture["cc_note"].ToString()) || string.IsNullOrEmpty(lecture["tp_note"].ToString()) || string.IsNullOrEmpty(lecture["exam_note"].ToString()))
                                {

                                    decision = "REFUSE";
                                    dataGridView.Rows.Add(lecture["matricule_etudiants"].ToString(), lecture["nom"].ToString(), lecture["cc_note"].ToString(), lecture["exam_note"].ToString(), lecture["tp_note"].ToString(), string.Empty, decision, session);

                                }
                                else
                                {
                                    notecc = Convert.ToDouble(lecture["cc_note"]);
                                    notetp = Convert.ToDouble(lecture["tp_note"]);
                                    double noteNormal = Convert.ToDouble(lecture["exam_note"]);

                                    notefinal = notecc * 0.2 + notetp * 0.1 + noteNormal * 0.7;

                                    if (notefinal >= 10)
                                    {
                                        decision = "VALIDE";
                                    }
                                    else
                                    {
                                        decision = "REFUSE";
                                    }
                                    dataGridView.Rows.Add(lecture["matricule_etudiants"].ToString(), lecture["nom"].ToString(), lecture["cc_note"].ToString(), lecture["exam_note"].ToString(), lecture["tp_note"].ToString(), notefinal, decision, session);

                                }


                            }
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
