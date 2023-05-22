using GestionNote.ClassesGlobales;

namespace GestionNote.NameSpaceMatiere
{
    public partial class FormAjoutMatiere : Form
    {
        public FormAjoutMatiere()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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
                Matiere matiere = new Matiere();
                matiere.NameMatiere = textBox1.Text;
                matiere.NbCredit = textBox2.Text;
                matiere.AjouterMatiere();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, MessageAI.ProjetName);
            }

        }
    }
}
