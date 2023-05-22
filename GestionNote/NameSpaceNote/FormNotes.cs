using GestionNote.ClassesGlobales;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GestionNote.NameSpaceNote
{
    public partial class FormNotes : Form
    {
        public FormNotes()
        {
            InitializeComponent();
            DiversRequetes.RequeteSelectionCombo(CbEtabli, "SELECT CONCAT(idetablissement , ' - ', NomEtablissement) element FROM `etablissement`;");
            DiversRequetes.RequeteSelectionCombo(CbMatiere, "SELECT CONCAT(code_matiere , ' - ', nom_matiere) element FROM `matiere`;");

            init();
        }

        private void TbValider_Click(object sender, EventArgs e)
        {

            init();
        }

        private void init()
        {

            CbEtabli.SelectedIndex = 0;
            CbAnnee.SelectedIndex = 0;
            CbMatiere.SelectedIndex = 0;
            RbExam.Checked = true;
            RbRattrap.Checked = false;

            string requeteInit = "SELECT DISTINCT etudiants.matricule_etudiants, CONCAT( etudiants.nom_etudiants , ' ' , prenom_etudiants) nom, note.cc_note, note.exam_note, note.ratrapage_note, note.tp_note FROM note, etudiants, matiere, etablissement WHERE etudiants.idetablissement = etablissement.idetablissement AND etudiants.id_etudiants = note.id_etudiants AND note.code_matiere = matiere.code_matiere;";
            Affiche(requeteInit);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (CbEtabli.SelectedIndex == 0 || CbAnnee.SelectedIndex == 0 || CbMatiere.SelectedIndex == 0)
            {
                MessageBox.Show("Remplissez tout les champs", MessageAI.ProjetName);


            }
            else
            {
                string requeteInit = $"SELECT DISTINCT etudiants.matricule_etudiants, CONCAT( etudiants.nom_etudiants , ' ' , prenom_etudiants) nom, note.cc_note, note.exam_note, note.ratrapage_note, note.tp_note FROM note, etudiants, matiere, etablissement WHERE etudiants.idetablissement = etablissement.idetablissement AND etudiants.id_etudiants = note.id_etudiants AND note.code_matiere = matiere.code_matiere AND etudiants.annee_academique = '{CbAnnee.Text}' AND etablissement.idetablissement = {CbEtabli.Text.Split(" - ")[0]} AND matiere.code_matiere = {CbMatiere.Text.Split(" - ")[0]};";
                Affiche(requeteInit);
            }
        }

        private void CbMatiere_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbMatiere.SelectedIndex != 0)
            {
                string requeteInit = $"SELECT DISTINCT etudiants.matricule_etudiants, CONCAT( etudiants.nom_etudiants , ' ' , prenom_etudiants) nom, note.cc_note, note.exam_note, note.ratrapage_note, note.tp_note FROM note, etudiants, matiere, etablissement WHERE etudiants.idetablissement = etablissement.idetablissement AND etudiants.id_etudiants = note.id_etudiants AND note.code_matiere = matiere.code_matiere AND matiere.code_matiere = {CbMatiere.Text.Split(" - ")[0]};";
                Affiche(requeteInit);

            }


        }

        private void Affiche(string req)
        {
            string requeteInit = req;
            string session = string.Empty;
            if (RbExam.Checked)
            {
                session = RbExam.Text;
            }
            else if (RbRattrap.Checked)
            {
                session = RbRattrap.Text;
            }

            Note note = new Note();
            dataGridView1.Rows.Clear();
            note.AfficherNote(dataGridView1, requeteInit, session);
        }

        private void CbEtabli_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbEtabli.SelectedIndex != 0)
            {
                string requeteInit = $"SELECT DISTINCT etudiants.matricule_etudiants, CONCAT( etudiants.nom_etudiants , ' ' , prenom_etudiants) nom, note.cc_note, note.exam_note, note.ratrapage_note, note.tp_note FROM note, etudiants, matiere, etablissement WHERE etudiants.idetablissement = etablissement.idetablissement AND etudiants.id_etudiants = note.id_etudiants AND note.code_matiere = matiere.code_matiere AND etablissement.idetablissement = {CbEtabli.Text.Split(" - ")[0]};";
                Affiche(requeteInit);
            }



        }

        private void CbAnnee_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbAnnee.SelectedIndex != 0)
            {
                string requeteInit = $"SELECT DISTINCT etudiants.matricule_etudiants, CONCAT( etudiants.nom_etudiants , ' ' , prenom_etudiants) nom, note.cc_note, note.exam_note, note.ratrapage_note, note.tp_note FROM note, etudiants, matiere, etablissement WHERE etudiants.idetablissement = etablissement.idetablissement AND etudiants.id_etudiants = note.id_etudiants AND note.code_matiere = matiere.code_matiere AND etudiants.annee_academique = '{CbAnnee.Text}';";
                Affiche(requeteInit);
            }


        }

        private void generatePdf()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                Random random = new Random();
                string nom = random.NextInt64().ToString();
                save.FileName = $"{nom}.pdf";

                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show(ex.Message, MessageAI.ProjetName);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in dataGridView1.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {

                                    pTable.AddCell(Convert.ToString(dcell.Value));



                                }
                            }
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();

                                /////////////////////////
                                BaseColor bleu = new BaseColor(SystemColors.Highlight);
                                BaseColor bleuN = new BaseColor(Color.SkyBlue);


                                iTextSharp.text.Font fontTitre = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20f, iTextSharp.text.Font.BOLD, bleuN);
                                iTextSharp.text.Font fontacc = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 30f, iTextSharp.text.Font.BOLDITALIC, bleu);
                                //////////////////////
                                ///

                                PdfPTable tableau1 = new PdfPTable(2);
                                tableau1.WidthPercentage = 100;
                                PdfPCell cell3 = new PdfPCell(new Phrase(CbEtabli.Text + "\n" + "\n" + CbAnnee.Text));
                                cell3.Border = 0;
                                cell3.HorizontalAlignment = Element.ALIGN_LEFT;
                                tableau1.AddCell(cell3);
                                PdfPCell cell4 = new PdfPCell(new Phrase(CbMatiere.Text));
                                cell4.HorizontalAlignment = Element.ALIGN_RIGHT;
                                cell4.Border = 0;
                                tableau1.AddCell(cell4);
                                document.Add(tableau1);

                                Paragraph p4 = new Paragraph("\n");
                                p4.Alignment = Element.ALIGN_CENTER;
                                document.Add(p4);

                                Paragraph p = new Paragraph("Liste des etudiants", fontacc);
                                p.Alignment = Element.ALIGN_CENTER;
                                p.Alignment = Element.ALIGN_BOTTOM;
                                document.Add(p);

                                Paragraph p3 = new Paragraph("\n");
                                p3.Alignment = Element.ALIGN_CENTER;
                                document.Add(p3);

                                ///////////////////////////
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("Enregistrement reussit", MessageAI.ProjetName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, MessageAI.ProjetName);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucun enregistrement dans le datagridvieuw", MessageAI.ProjetName);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            generatePdf();

        }


    }
}
