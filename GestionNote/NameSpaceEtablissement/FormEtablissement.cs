namespace GestionNote.NameSpaceEtablissement
{
    public partial class FormEtablissement : Form
    {
        public FormEtablissement()
        {
            InitializeComponent();
            Etablissement etablissement = new Etablissement();
            etablissement.AfficherEtablissement(dataGridView1, "select * from etablissement");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormAjoutEtablissement etablissement = new FormAjoutEtablissement();
            etablissement.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            Etablissement etablissement = new Etablissement();
            etablissement.AfficherEtablissement(dataGridView1, "select * from etablissement");

        }
    }
}
