using GestionNote.NameSpaceEtudiant;

namespace GestionNote
{
    public partial class FormEtudiant : Form
    {
        public FormEtudiant()
        {
            InitializeComponent();
            Etudiant etudiant = new Etudiant();
            etudiant.AfficherEtudiant(dataGridView1, "SELECT etudiants.id_etudiants, etudiants.nom_etudiants,  etudiants.prenom_etudiants, etudiants.telephone_etudiants, etudiants.filiere_etudiants, etudiants.niveau_etudiants, etudiants.annee_academique, etudiants.date_naiss_etudiants, etudiants.matricule_etudiants, etablissement.NomEtablissement FROM etudiants,etablissement WHERE etudiants.idetablissement = etablissement.idetablissement;");

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormAjoutEtudiant etudiantForm = new FormAjoutEtudiant();
            etudiantForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Etudiant etudiant = new Etudiant();
            etudiant.AfficherEtudiant(dataGridView1, "SELECT etudiants.id_etudiants, etudiants.nom_etudiants,  etudiants.prenom_etudiants, etudiants.telephone_etudiants, etudiants.filiere_etudiants, etudiants.niveau_etudiants, etudiants.annee_academique, etudiants.date_naiss_etudiants, etudiants.matricule_etudiants, etablissement.NomEtablissement FROM etudiants,etablissement WHERE etudiants.idetablissement = etablissement.idetablissement;");

        }
    }
}
