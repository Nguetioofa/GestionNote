namespace GestionNote.NameSpaceMatiere
{
    public partial class FormMatiere : Form
    {
        public FormMatiere()
        {
            InitializeComponent();
            Matiere matiere = new Matiere();
            matiere.AfficherMatiere(dataGridView2, "select * from matiere");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormAjoutMatiere matiere = new FormAjoutMatiere();
            matiere.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();

            Matiere matiere = new Matiere();
            matiere.AfficherMatiere(dataGridView2, "select * from matiere");

        }
    }
}
