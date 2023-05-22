using GestionNote.ClassesGlobales;
using GestionNote.NameSpaceEtablissement;
using GestionNote.NameSpaceMatiere;
using GestionNote.NameSpaceNote;

namespace GestionNote
{
    public partial class FromDashboard : Form
    {
        private Form formulaireEncour;
        private Button boutonEncour;

        public FromDashboard()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            label6.Text = DiversRequetes.RequeteDeCompte("select count(*) from etudiants");
            label7.Text = DiversRequetes.RequeteDeCompte("select count(*) from etablissement");
            label9.Text = DiversRequetes.RequeteDeCompte("select count(*) from matiere");

        }

        private void DisableButton()
        {
            foreach (Control previousBtn in guna2GradientPanel2.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.Transparent;
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI Historic", 14.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------///
        //-------------------------------------------------------------------------------------------------------------------------------------------------------///
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (boutonEncour != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SystemColors.Control;
                    boutonEncour = (Button)btnSender;
                    boutonEncour.BackColor = color;
                    boutonEncour.ForeColor = Color.Black;
                    boutonEncour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------///

        public void ouvertureForm(Form formflis)
        {
            if (formulaireEncour != null)
            {
                formulaireEncour.Close();
            }
            formulaireEncour = formflis;
            formflis.TopLevel = false;
            formflis.FormBorderStyle = FormBorderStyle.None;
            formflis.Dock = DockStyle.Fill;
            panel8.Controls.Add(formflis);
            panel8.Tag = formflis;
            formflis.BringToFront();
            formflis.Show();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            ouvertureForm(new FormAjouterNote());
            ActivateButton(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // FormMatiere Matiere = new FormMatiere();
            //  Matiere.Show();
            ouvertureForm(new FormMatiere());
            ActivateButton(sender);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //   FormAjoutEtudiant Etudiant = new FormAjoutEtudiant();
            //Etudiant.Show();
        }

        private void BtEtablissement_Click(object sender, EventArgs e)
        {
            ouvertureForm(new FormEtablissement());
            ActivateButton(sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ouvertureForm(new FormEtudiant());
            ActivateButton(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ouvertureForm(new FormNotes());
            ActivateButton(sender);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("F");
            init();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
              this.Hide();
              GesConSqLite.CloseConn();
              GesParametre.DicParametres.Clear();
              Form1 formConnexion = new Form1();
              formConnexion.ShowDialog();
              this.Close();
        }
    }
}
