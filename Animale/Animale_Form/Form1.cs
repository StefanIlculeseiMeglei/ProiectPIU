﻿using LibrarieModele;
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
namespace Animale_Form
{
    public partial class Form1 : Form
    {
        private Label lblHeaderImagine;
        private Label lblHeaderSunet1;
        private Label lblHeaderSunet2;
        private Label lblHeaderSunet3;
        private Label lblHeaderOptiuni;
        private Label[] NumeImagine;
        private Label[] NumeSunete;
        private Button BtnCastig;
        private RadioButton[][] Optiuni;
        private GroupBox[] grupOptiuni;
        private int corect;
        string user;
        string numeFisierImg = ConfigurationManager.AppSettings["NumeFisierImg"];
        string numeFisierSnd = ConfigurationManager.AppSettings["NumeFisierSnd"];
        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 38;
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

        }
        private void AfiseazaIntrebari(dataQuiz quiz)
        {
            int i = 0;
            int j = 0;

            new System.Drawing.Size(800, 600);
            int nrIntrebari = quiz.RUNDAMAX;
            NumeImagine = new Label[nrIntrebari];
            NumeSunete= new Label[3*nrIntrebari];
            Optiuni = new RadioButton[nrIntrebari][];
            for (i = 0; i < nrIntrebari; i++)
                Optiuni[i] = new RadioButton[3];
            grupOptiuni = new GroupBox[nrIntrebari];
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

            lblHeaderOptiuni= new Label();
            lblHeaderOptiuni.Width = LATIME_CONTROL;
            lblHeaderOptiuni.Text = "Optiuni";
            lblHeaderOptiuni.Left = OFFSET_X + DIMENSIUNE_PAS_X * 4;
            lblHeaderOptiuni.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblHeaderOptiuni);

            BtnCastig = new Button();
            BtnCastig.Left = 16;
            BtnCastig.Top = 32;
            BtnCastig.Size = new System.Drawing.Size(75, 22);
            BtnCastig.Text = "Finalizare";
            BtnCastig.Click += BtnCastig_Click;
            this.Controls.Add(BtnCastig);

            for (i=0;i<nrIntrebari;i++)
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

        private void BtnCastig_Click(object sender, EventArgs e)
        {
            this.verificaCastig();
            BtnCastig.Hide();
            if (corect >= this.quiz.RUNDAMAX * 0.6) 
            {
                Label mesaj=new Label();
                mesaj.Left = 16;
                mesaj.Top = 32;
                mesaj.Size = new System.Drawing.Size(150, 100);
                mesaj.Text = string.Concat("Ai castigat ", user, "!");
                this.Controls.Add(mesaj);
            }
            else
            {
                Label mesaj = new Label();
                mesaj.Left = 16;
                mesaj.Top = 32;
                mesaj.Size = new System.Drawing.Size(150, 100);
                mesaj.Text = string.Concat("Ai pierdut ", user, "!");
                this.Controls.Add(mesaj);

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
        private void verificaCastig()
        {

            corect = 0;
            int i = 0;
            if (quiz.getRapunsRunda(i) == 0)
                if (this.radioButton1.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 1)
                if (this.radioButton2.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 2)
                if (this.radioButton3.Checked == true)
                    corect++;


            i++;
            if (quiz.getRapunsRunda(i) == 0)
                if (this.radioButton4.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 1)
                if (this.radioButton5.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 2)
                if (this.radioButton6.Checked == true)
                    corect++;


            i++;
            if (quiz.getRapunsRunda(i) == 0)
                if (this.radioButton7.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 1)
                if (this.radioButton8.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 2)
                if (this.radioButton9.Checked == true)
                    corect++;



            i++;
            if (quiz.getRapunsRunda(i) == 0)
                if (this.radioButton10.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 1)
                if (this.radioButton11.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 2)
                if (this.radioButton12.Checked == true)
                    corect++;



            i++;
            if (quiz.getRapunsRunda(i) == 0)
                if (this.radioButton13.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 1)
                if (this.radioButton14.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 2)
                if (this.radioButton15.Checked == true)
                    corect++;



            i++;
            if (quiz.getRapunsRunda(i) == 0)
                if (this.radioButton16.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 1)
                if (this.radioButton17.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 2)
                if (this.radioButton18.Checked == true)
                    corect++;



            i++;
            if (quiz.getRapunsRunda(i) == 0)
                if (this.radioButton19.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 1)
                if (this.radioButton20.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 2)
                if (this.radioButton21.Checked == true)
                    corect++;




            i++;
            if (quiz.getRapunsRunda(i) == 0)
                if (this.radioButton22.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 1)
                if (this.radioButton23.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 2)
                if (this.radioButton24.Checked == true)
                    corect++;




            i++;
            if (quiz.getRapunsRunda(i) == 0)
                if (this.radioButton25.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 1)
                if (this.radioButton26.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 2)
                if (this.radioButton27.Checked == true)
                    corect++;




            i++;
            if (quiz.getRapunsRunda(i) == 0)
                if (this.radioButton28.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 1)
                if (this.radioButton29.Checked == true)
                    corect++;
            if (quiz.getRapunsRunda(i) == 2)
                if (this.radioButton30.Checked == true)
                    corect++;
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
                this.BtnStart.Show();
            }
            else
                this.textBox1.BackColor = Color.Red;

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            this.BtnStart.Hide();
            this.groupBox1.Show();
            this.groupBox2.Show();
            this.groupBox3.Show();
            this.groupBox4.Show();
            this.groupBox5.Show();
            this.groupBox6.Show();
            this.groupBox7.Show();
            this.groupBox8.Show();
            this.groupBox9.Show();
            this.groupBox10.Show();
            this.AfiseazaIntrebari(quiz);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
