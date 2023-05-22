using GestionNote.ClassesGlobales;
using GestionNote.NameSpaceEtudiant;

namespace GestionNote.NameSpaceNote
{
    public partial class FormAjouterNote : Form
    {
        public FormAjouterNote()
        {
            InitializeComponent();
            DiversRequetes.RequeteSelectionCombo(CbEtabli, "SELECT CONCAT(idetablissement , ' - ', NomEtablissement) element FROM `etablissement`;");
            DiversRequetes.RequeteSelectionList(listBox1, "SELECT CONCAT(code_matiere , ' - ', nom_matiere) element FROM `matiere`;");
            listBox1.SelectedIndex = 0;
            Etudiant etudiant = new Etudiant();
            etudiant.AfficherEtudiant(dataGridView1, "SELECT etudiants.id_etudiants, etudiants.nom_etudiants,  etudiants.prenom_etudiants, etudiants.telephone_etudiants, etudiants.filiere_etudiants, etudiants.niveau_etudiants, etudiants.annee_academique, etudiants.date_naiss_etudiants, etudiants.matricule_etudiants, etablissement.NomEtablissement FROM etudiants,etablissement WHERE etudiants.idetablissement = etablissement.idetablissement;");
        }

        private void CbEtabli_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Etudiant etudiant = new Etudiant();

            etudiant.AfficherEtudiant(dataGridView1, $"SELECT etudiants.id_etudiants, etudiants.nom_etudiants,  etudiants.prenom_etudiants, etudiants.telephone_etudiants, etudiants.filiere_etudiants, etudiants.niveau_etudiants, etudiants.annee_academique, etudiants.date_naiss_etudiants, etudiants.matricule_etudiants, etablissement.NomEtablissement FROM etudiants,etablissement WHERE etudiants.idetablissement = etablissement.idetablissement AND etudiants.annee_academique = '{CbAnne.Text}' AND etudiants.idetablissement={CbEtabli.Text.Split(" - ")[0]}");

        }

        private void TbValider_Click(object sender, EventArgs e)
        {
            string requete = $"select id_etudiants from note WHERE code_matiere = {Convert.ToString(listBox1.SelectedItem).Split(" - ")[0]} AND id_etudiants = {Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)};";

            bool verif = DiversRequetes.RequeteDeVerification(requete);
            if (verif)
            {
                if (RbCc.Checked)
                {
                    requete = $"UPDATE `note` SET `cc_note` = '{TbNote.Text}' WHERE `note`.`id_etudiants` = {Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)};";
                }
                else if (RbNormal.Checked)
                {
                    requete = $"UPDATE `note` SET `exam_note` = '{TbNote.Text}' WHERE `note`.`id_etudiants` = {Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)};";

                }
                else if (RbTpe.Checked)
                {
                    requete = $"UPDATE `note` SET `tp_note` = '{TbNote.Text}' WHERE `note`.`id_etudiants` = {Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)};";

                }
                else if (RbRatt.Checked)
                {
                    requete = $"UPDATE `note` SET `ratrapage_note` = '{TbNote.Text}' WHERE `note`.`id_etudiants` = {Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)};";
                }

            }
            else
            {
                if (RbCc.Checked)
                {
                    requete = $"INSERT INTO `note` (`id_note`, `cc_note`, `tp_note`, `exam_note`, `ratrapage_note`, `id_etudiants`, `code_matiere`) VALUES (NULL, {TbNote.Text}, NULL, NULL, NULL, {Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)}, {Convert.ToString(listBox1.SelectedItem).Split(" - ")[0]})";
                }
                else if (RbNormal.Checked)
                {
                    requete = $"INSERT INTO `note` (`id_note`, `cc_note`, `tp_note`, `exam_note`, `ratrapage_note`, `id_etudiants`, `code_matiere`) VALUES (NULL, NULL, NULL, {TbNote.Text}, NULL, {Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)}, {Convert.ToString(listBox1.SelectedItem).Split(" - ")[0]})";

                }
                else if (RbTpe.Checked)
                {
                    requete = $"INSERT INTO `note` (`id_note`, `cc_note`, `tp_note`, `exam_note`, `ratrapage_note`, `id_etudiants`, `code_matiere`) VALUES (NULL, NULL, {TbNote.Text}, NULL, NULL, {Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)}, {Convert.ToString(listBox1.SelectedItem).Split(" - ")[0]})";

                }
                else if (RbRatt.Checked)
                {
                    requete = $"INSERT INTO `note` (`id_note`, `cc_note`, `tp_note`, `exam_note`, `ratrapage_note`, `id_etudiants`, `code_matiere`) VALUES (NULL, NULL, NULL, NULL,{TbNote.Text} , {Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)}, {Convert.ToString(listBox1.SelectedItem).Split(" - ")[0]})";
                }
            }



            string nb = DiversRequetes.RequeteDexecution(requete);

            if (string.IsNullOrEmpty(nb))
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Error";
            }
            else
            {
                label4.ForeColor = Color.Green;
                label4.Text = "Success";

            }
        }
    }
}
