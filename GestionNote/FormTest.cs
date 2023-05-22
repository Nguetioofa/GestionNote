using GestionNote.ClassesGlobales;

namespace GestionNote
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GesConSqLite.OpenConn();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
