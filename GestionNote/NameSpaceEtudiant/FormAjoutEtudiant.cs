using GestionNote.ClassesGlobales;

namespace GestionNote.NameSpaceEtudiant
{
    public partial class FormAjoutEtudiant : Form
    {
        public FormAjoutEtudiant()
        {
            InitializeComponent();
            DiversRequetes.RequeteSelectionCombo(CbEtabli, "SELECT CONCAT(idetablissement , ' - ', NomEtablissement) element FROM `etablissement`;");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Etudiant etudiant = new Etudiant();
                etudiant.NiveauEtudiant = Convert.ToInt32(CbNiveau.Text);
                etudiant.MatriculeEtudiant = TbMat.Text;
                etudiant.TelephoneEtudiant = TbPhone.Text;
                etudiant.AnnneeAcademique = CbAnnee.Text;
                etudiant.DateNaiss = Convert.ToDateTime(dateTimePicker1.Text);
                etudiant.EtablissementEtudiant = Convert.ToInt32(CbEtabli.Text.Split(" - ")[0]);
                etudiant.NameEtudiant = TbNom.Text;
                etudiant.PrenomEtudiant = TbPrenom.Text;
                etudiant.FiliereEtudiant = CbFiliere.Text;
                etudiant.AjouterEtudiant();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, MessageAI.ProjetName);
            }

        }
    }
}
