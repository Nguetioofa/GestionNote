using GestionNote.ClassesGlobales;

namespace GestionNote
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

            GesConSqLite.OpenConn();
            GesParametre.InitParametre();
        }
        int i = 1;



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string passWord = GesParametre.DicParametres["MotPasse"];
            string userName = GesParametre.DicParametres["NomAdmin"];



            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Mot de passe ou nom d'utilisateur vide", MessageAI.ProjetName, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else if (passWord == "" || passWord != textBox2.Text)
            {
                MessageBox.Show("Mot de passe ou nom d'utilisateur incorrecte", MessageAI.ProjetName, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
            else if (passWord == textBox2.Text)
            {
                FromDashboard Dashboard = new FromDashboard();
                Hide();
                Dashboard.ShowDialog();
                Close();
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            string passWord = GesParametre.DicParametres["MotPasse"];
            string userName = GesParametre.DicParametres["NomAdmin"];


            if (passWord != textBox2.Text)
            {
                if (i > 6)
                {
                    i = 1;
                }

                if (i == 1)
                {
                    button2.Location = new Point(63, 59);
                    i++;

                }
                else if (i == 2)
                {
                    button2.Location = new Point(318, 220);

                    i++;

                }
                else if (i == 3)
                {
                    button2.Location = new Point(12, 405);


                    i++;

                }
                else if (i == 4)
                {
                    button2.Location = new Point(352, 415);

                    i++;

                }
                else if (i == 5)
                {
                    button2.Location = new Point(759, 71);


                    i++;

                }
                else if (i == 6)
                {
                    button2.Location = new Point(746, 432);
                    i++;

                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            string passWord = GesParametre.DicParametres["MotPasse"];
            string userName = GesParametre.DicParametres["NomAdmin"];

            if (passWord == textBox2.Text)
            {
                button2.Location = new Point(637, 389);
            }
        }
    }
}