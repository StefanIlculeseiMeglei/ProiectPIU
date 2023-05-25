using LibrarieModele;
using LibrarieModele;

using NivelStocareData;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
namespace Animale_Form
{
    public partial class Form1 : Form
    {
        private Label lblHeaderImagine;
        private Label lblHeaderSunet1;
        private Label lblHeaderSunet2;
        private Label lblHeaderSunet3;
        private Label[] NumeImagine;
        private Label[] NumeSunete;


        string user;
        string numeFisierImg = ConfigurationManager.AppSettings["NumeFisierImg"];
        string numeFisierSnd = ConfigurationManager.AppSettings["NumeFisierSnd"];
        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;
        private const int OFFSET_X = 200;
        imagine img = new imagine();
        sunet snd = new sunet();
        imagini vimg = new imagini();
        sunete vsnd = new sunete();
        dataQuiz quiz = new dataQuiz(20, 10);
        AdministrareQuiz_FisierText admin;

        public Form1()
        {

            admin = new AdministrareQuiz_FisierText(vimg, vsnd, numeFisierImg, numeFisierSnd);
            InitializeComponent();
            //setare proprietati
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.Black;
            this.Text = "Animale";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            user = string.Empty;
            admin.imaginiCitire(vimg, numeFisierImg);
            admin.suneteCitire(vsnd, numeFisierSnd);
            quiz.incarcaData(vimg, vsnd);
            AfiseazaIntrebari(quiz);

        }
        private void AfiseazaIntrebari(dataQuiz quiz)
        {
            
            int nrIntrebari = quiz.RUNDAMAX;
            NumeImagine = new Label[nrIntrebari];
            NumeSunete= new Label[3*nrIntrebari];
            lblHeaderImagine = new Label();
            lblHeaderImagine.Width = LATIME_CONTROL;
            lblHeaderImagine.Text = "Imagine";
            lblHeaderImagine.Left = OFFSET_X +0;
            lblHeaderImagine.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblHeaderImagine);

            lblHeaderSunet1 = new Label();
            lblHeaderSunet1.Width = LATIME_CONTROL;
            lblHeaderSunet1.Text = "Sunet1";
            lblHeaderSunet1.Left = OFFSET_X + DIMENSIUNE_PAS_X;
            lblHeaderSunet1.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblHeaderSunet1);


            lblHeaderSunet2 = new Label();
            lblHeaderSunet2.Width = LATIME_CONTROL;
            lblHeaderSunet2.Text = "Sunet2";
            lblHeaderSunet2.Left = OFFSET_X + DIMENSIUNE_PAS_X*2;
            lblHeaderSunet2.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblHeaderSunet2);

            lblHeaderSunet3 = new Label();
            lblHeaderSunet3.Width = LATIME_CONTROL;
            lblHeaderSunet3.Text = "Sunet3";
            lblHeaderSunet3.Left = OFFSET_X + DIMENSIUNE_PAS_X*3;
            lblHeaderSunet3.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblHeaderSunet3);




            int i = 0;
            int j = 0;
            for(i=0;i<nrIntrebari;i++)
            {
                //adaugare control de tip Label pentru numele studentilor;
                NumeImagine[i] = new Label();
                NumeImagine[i].Width = LATIME_CONTROL;
                NumeImagine[i].Text = quiz.getImagineRunda(i);
                NumeImagine[i].Left = OFFSET_X + 0;
                NumeImagine[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(NumeImagine[i]);

                //adaugare control de tip Label pentru prenumele studentilor
                NumeSunete[j] = new Label();
                NumeSunete[j].Width = LATIME_CONTROL;
                NumeSunete[j].Text = quiz.getSuneteRunda(i)[0];
                NumeSunete[j].Left = OFFSET_X +DIMENSIUNE_PAS_X;
                NumeSunete[j].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(NumeSunete[j]);
                j++;
                //adaugare control de tip Label pentru notele studentilor
                NumeSunete[j] = new Label();
                NumeSunete[j].Width = LATIME_CONTROL;
                NumeSunete[j].Text = quiz.getSuneteRunda(i)[1];
                NumeSunete[j].Left = OFFSET_X+DIMENSIUNE_PAS_X*2 ;
                NumeSunete[j].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(NumeSunete[j]);
                j++;
                NumeSunete[j] = new Label();
                NumeSunete[j].Width = LATIME_CONTROL;
                NumeSunete[j].Text = quiz.getSuneteRunda(i)[2];
                NumeSunete[j].Left = OFFSET_X + DIMENSIUNE_PAS_X*3; 
                NumeSunete[j].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(NumeSunete[j]);
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAdaugaUser_Click(object sender, EventArgs e)
        {
            if (this.verificaUser(this.textBox1.Text) == true)
            {
                this.user = string.Copy(this.textBox1.Text);
                this.textBox1.Hide();
                this.label1.Hide();
                this.BtnAdaugaUser.Hide();
            }
            else
                this.textBox1.BackColor = Color.Red;

        }
    }
}
