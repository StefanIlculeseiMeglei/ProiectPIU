using LibrarieModele;
using NivelStocareData;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Media;
using System.CodeDom;

namespace Animale_Form
{
    public partial class Form1 : Form
    {
        private Label lblHeaderImagine;
        private Label lblHeaderOptiuni;
        private Button BtnCastig;
        private int punctaj;
        private int rundaCurenta;

        string user;
        string numeFisierImg = ConfigurationManager.AppSettings["NumeFisierImg"];
        string numeFisierSnd = ConfigurationManager.AppSettings["NumeFisierSnd"];
        string numeFisierCastig = ConfigurationManager.AppSettings["NumeFisierCastig"];
        string numeFisierPierdere = ConfigurationManager.AppSettings["NumeFisierPierdere"];
        string numeFisierStart = ConfigurationManager.AppSettings["NumeFisierStart"];
        private const float PROCENTAJ_CASTIG = 0.8f;
        private const int DIMENSIUNE_1 = 200;
        private const int DIMENSIUNE_2 = 350;
        private const int DIMENSIUNE_3 = 175;
        private const int DIMENSIUNE_4 = 68;
        private const int ZERO = 0;
        imagine img = new imagine();
        sunet snd = new sunet();
        imagini vimg = new imagini();
        sunete vsnd = new sunete();
        dataQuiz quiz = new dataQuiz(20, 10);
        AdministrareQuiz_FisierText admin;
        SoundPlayer soundManager = new SoundPlayer();
        internal enum POZITII
        {
            POZITIE1, POZITIE2, POZITIE3
        }

        public Form1()
        {

            admin = new AdministrareQuiz_FisierText(vimg, vsnd, numeFisierImg, numeFisierSnd);
            InitializeComponent();
            //setare proprietati
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.Black;
            this.BackColor = Color.FromArgb(0, 191, 255);
            this.Text = "Animale";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            user = string.Empty;
            punctaj = ZERO;
            rundaCurenta = ZERO;
            admin.imaginiCitire(vimg);
            admin.suneteCitire(vsnd);
            quiz.incarcaData(vimg, vsnd);
            ascundeElemente();
            this.pictureBox1.Show();
            this.resizePictureBox(DIMENSIUNE_2);
            updatePictureBox(numeFisierStart);

        }
        private void ascundeElemente()
        {
            this.lblCauta.Hide();
            this.lblPunctaj.Hide();
            this.lblConcluzie.Hide();
            this.lblRunda.Hide();
            this.pictureBox1.Hide();
            this.btnSunet1.Hide();
            this.btnSunet2.Hide();
            this.btnSunet3.Hide();
            this.groupBox1.Hide();
            this.BtnStart.Hide();
            this.btnRundaUrm.Hide();
            this.btnFinalizare.Hide();
            this.checkBox1.Hide();
            this.lblPunctaj.Hide();
            this.btnBack.Hide();    
        }
        private void arataElemente()
        {
            this.lblUtilizator.Hide();
            this.textBox1.Hide();
            this.BtnAdaugaUser.Hide();
            this.lblRunda.Show();
            this.pictureBox1.Show();
            this.btnSunet1.Show();  
            this.btnSunet2.Show();
            this.btnSunet3.Show();
            this.groupBox1.Show();
            this.BtnStart.Show();
            this.checkBox1.Show();

        }
        private void resizePictureBox(int x)
        {
            this.pictureBox1.Height = x;
            this.pictureBox1.Width = x;
            this.pictureBox1.Left = DIMENSIUNE_3;
            this.pictureBox1.Top = DIMENSIUNE_4;
        }
        private void updatelblRunda()
        {
            this.lblRunda.Text = "Runda " + (this.rundaCurenta+1) + "/" + this.quiz.RUNDAMAX;
        }

        private bool verificaUser(string s)
        {
            if (string.IsNullOrEmpty(s)) { return false; }
            else
                return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool verificaCastig()
        {
            if (punctaj >=(int) (this.quiz.RUNDAMAX * this.quiz.valoareRaspuns * PROCENTAJ_CASTIG)) return true;
            else return false;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAdaugaUser_Click(object sender, EventArgs e)
        {
            if (this.verificaUser(this.textBox1.Text) == true)
            {
                this.user = string.Copy(this.textBox1.Text);
                this.textBox1.Hide();
                this.lblUtilizator.Hide();
                this.BtnAdaugaUser.Hide();
                this.btnCauta.Hide();
                this.lblCauta.Hide();
                this.BtnStart.Show();
                this.textBox1.BackColor = Color.White;
            }
            else
                this.textBox1.BackColor = Color.Red;

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            
            this.arataElemente();
            this.BtnStart.Hide();
            this.btnRundaUrm.Show();
            this.admin.AddUser(this.user);
            this.resizePictureBox(DIMENSIUNE_1);
            updatelblRunda();
            updatePictureBox();
            updateRadioButtons();

        }

        private void btnSunet1_Click(object sender, EventArgs e)
        {
            soundManager.SoundLocation = this.admin.caleFisierSunete + quiz.getSuneteRunda(this.rundaCurenta)[0];
            soundManager.Play();

        }

        private void btnSunet2_Click(object sender, EventArgs e)
        {
            soundManager.SoundLocation = this.admin.caleFisierSunete + quiz.getSuneteRunda(this.rundaCurenta)[1];
            soundManager.Play();

        }

        private void btnSunet3_Click(object sender, EventArgs e)
        {
            soundManager.SoundLocation = this.admin.caleFisierSunete + quiz.getSuneteRunda(this.rundaCurenta)[2];
            soundManager.Play();

        }

        private void lblRunda_Click(object sender, EventArgs e)
        {

        }

        private void radioOptiune1_CheckedChanged(object sender, EventArgs e)
        {
            this.btnRundaUrm.BackColor = Color.White;
        }

        private void radioOptiune2_CheckedChanged(object sender, EventArgs e)
        {
           this.btnRundaUrm.BackColor = Color.White;
        }

        private void radioOptiune3_CheckedChanged(object sender, EventArgs e)
        {
            this.btnRundaUrm.BackColor = Color.White;
        }
        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void btnRundaUrm_Click(object sender, EventArgs e)
        {
            if (this.rundaCurenta >= quiz.RUNDAMAX-1)
            {
                this.ascundeElemente();
                this.btnFinalizare.Show();
            }
            else if(this.validareAlegere() )
            {
                this.btnRundaUrm.BackColor = Color.White;
                verificaRaspuns();

                this.rundaCurenta++;
                this.updatelblRunda();
                this.updatePictureBox();
                this.updateRadioButtons();
                this.updateLblPunctaj();
            }
            else this.btnRundaUrm.BackColor = Color.Red; 
        }
        private bool validareAlegere()
        {
            if (this.radioOptiune1.Checked == true || this.radioOptiune2.Checked == true || this.radioOptiune3.Checked == true)
                return true;
            else return false;
        }
        private void verificaRaspuns()
        {
            if (radioOptiune1.Checked == true && this.quiz.getRapunsRunda(rundaCurenta) == (int)POZITII.POZITIE1) punctaj += this.quiz.valoareRaspuns;
            else if (radioOptiune2.Checked == true && this.quiz.getRapunsRunda(rundaCurenta) == (int)POZITII.POZITIE2) punctaj += this.quiz.valoareRaspuns;
            else if (radioOptiune3.Checked == true && this.quiz.getRapunsRunda(rundaCurenta) == (int)POZITII.POZITIE3) punctaj += this.quiz.valoareRaspuns;

        }
        private void updatePictureBox()
        {
            FileStream fs = new System.IO.FileStream(admin.caleFisierImagini + quiz.getImagineRunda(this.rundaCurenta), FileMode.Open, FileAccess.Read);
            pictureBox1.Image = Image.FromStream(fs);
            fs.Close();

        }
        private void updatePictureBox(string name)
        {
            FileStream fs = new System.IO.FileStream(admin.caleFisierImagini + name, FileMode.Open, FileAccess.Read);
            pictureBox1.Image = Image.FromStream(fs);
            fs.Close();

        }
        private void updateRadioButtons()
        {
            this.radioOptiune1.Checked = false;
            this.radioOptiune2.Checked = false;
            this.radioOptiune3.Checked = false;
        }
        private void btnFinalizare_Click(object sender, EventArgs e)
        {
            this.lblConcluzie.Show();
            this.pictureBox1.Show();
            this.resizePictureBox(DIMENSIUNE_2);

            if (this.verificaCastig())
            {
                this.updatePictureBox(numeFisierCastig);
                lblConcluzie.Text = string.Concat("Ai castigat ", user, "!");
            }
            else
            {
                this.updatePictureBox(numeFisierPierdere);
                lblConcluzie.Text = string.Concat("Ai pierdut ", user, "!");
            }
            this.btnFinalizare.Hide();
            this.btnBack.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblConcluzie_Click(object sender, EventArgs e)
        {

        }
        private void updateLblPunctaj()
        {
            this.lblPunctaj.Text = "Punctaj: " + this.punctaj + "p" +
                "\nNecesar: "+ this.quiz.RUNDAMAX * this.quiz.valoareRaspuns * PROCENTAJ_CASTIG+"p";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                updateLblPunctaj();
                this.lblPunctaj.Show();
            }
            else
                this.lblPunctaj.Hide();

        }

        private void btnCauta_Click(object sender, EventArgs e)
        {
            if (this.verificaUser(this.textBox1.Text) == true)
            {
                this.textBox1.BackColor = Color.White;
                this.lblCauta.Show();
                this.lblCauta.Text="Numele: " + this.textBox1.Text + "\na fost folosit de " + this.admin.cautaAparatiiUser(textBox1.Text)+ " ori.";
                
            }
            else
                this.textBox1.BackColor = Color.Red;

        }

        private void lblCauta_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            img = new imagine();
            snd = new sunet();
            vimg = new imagini();
            vsnd = new sunete();
            this.lblUtilizator.Show();
            this.lblCauta.Hide();
            this.textBox1.Show();
            this.BtnAdaugaUser.Show();
            this.btnCauta.Show();
            this.checkBox1.Checked = false;

            user = string.Empty;
            punctaj = ZERO;
            rundaCurenta = ZERO;
            admin.imaginiCitire(vimg);
            admin.suneteCitire(vsnd);
            quiz.incarcaData(vimg, vsnd);
            ascundeElemente();
            this.pictureBox1.Show();
            this.resizePictureBox(DIMENSIUNE_2);
            updatePictureBox(numeFisierStart);

        }

       
    }
}
