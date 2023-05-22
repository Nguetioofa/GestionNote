namespace GestionNote.NameSpaceEtablissement
{
    public partial class FormAjoutEtablissement : Form
    {
        public FormAjoutEtablissement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Etablissement etablissement = new Etablissement();
            etablissement.NomEtablissement = textBox1.Text;
            etablissement.VilleEtablissements = textBox2.Text;
            etablissement.Telephone = System.Convert.ToInt32(textBox3.Text);
            etablissement.AjouterEtablissement();
        }
    }
}
