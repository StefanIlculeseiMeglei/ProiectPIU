namespace Animale_Form
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUtilizator = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnAdaugaUser = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioOptiune3 = new System.Windows.Forms.RadioButton();
            this.radioOptiune2 = new System.Windows.Forms.RadioButton();
            this.radioOptiune1 = new System.Windows.Forms.RadioButton();
            this.btnSunet1 = new System.Windows.Forms.Button();
            this.btnSunet2 = new System.Windows.Forms.Button();
            this.btnSunet3 = new System.Windows.Forms.Button();
            this.lblRunda = new System.Windows.Forms.Label();
            this.btnRundaUrm = new System.Windows.Forms.Button();
            this.btnFinalizare = new System.Windows.Forms.Button();
            this.lblConcluzie = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblPunctaj = new System.Windows.Forms.Label();
            this.btnCauta = new System.Windows.Forms.Button();
            this.lblCauta = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUtilizator
            // 
            this.lblUtilizator.Location = new System.Drawing.Point(12, 16);
            this.lblUtilizator.Name = "lblUtilizator";
            this.lblUtilizator.Size = new System.Drawing.Size(101, 27);
            this.lblUtilizator.TabIndex = 0;
            this.lblUtilizator.Text = "Utilizator";
            this.lblUtilizator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUtilizator.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BtnAdaugaUser
            // 
            this.BtnAdaugaUser.Location = new System.Drawing.Point(16, 79);
            this.BtnAdaugaUser.Name = "BtnAdaugaUser";
            this.BtnAdaugaUser.Size = new System.Drawing.Size(88, 28);
            this.BtnAdaugaUser.TabIndex = 2;
            this.BtnAdaugaUser.Text = "Validati";
            this.BtnAdaugaUser.UseVisualStyleBackColor = true;
            this.BtnAdaugaUser.Click += new System.EventHandler(this.BtnAdaugaUser_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(16, 13);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(88, 32);
            this.BtnStart.TabIndex = 3;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(175, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioOptiune3);
            this.groupBox1.Controls.Add(this.radioOptiune2);
            this.groupBox1.Controls.Add(this.radioOptiune1);
            this.groupBox1.Location = new System.Drawing.Point(149, 334);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 46);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // radioOptiune3
            // 
            this.radioOptiune3.AutoSize = true;
            this.radioOptiune3.Location = new System.Drawing.Point(238, 12);
            this.radioOptiune3.Name = "radioOptiune3";
            this.radioOptiune3.Size = new System.Drawing.Size(81, 20);
            this.radioOptiune3.TabIndex = 2;
            this.radioOptiune3.TabStop = true;
            this.radioOptiune3.Text = "Optiune3";
            this.radioOptiune3.UseVisualStyleBackColor = true;
            this.radioOptiune3.CheckedChanged += new System.EventHandler(this.radioOptiune3_CheckedChanged);
            // 
            // radioOptiune2
            // 
            this.radioOptiune2.AutoSize = true;
            this.radioOptiune2.Location = new System.Drawing.Point(122, 12);
            this.radioOptiune2.Name = "radioOptiune2";
            this.radioOptiune2.Size = new System.Drawing.Size(81, 20);
            this.radioOptiune2.TabIndex = 1;
            this.radioOptiune2.TabStop = true;
            this.radioOptiune2.Text = "Optiune2";
            this.radioOptiune2.UseVisualStyleBackColor = true;
            this.radioOptiune2.CheckedChanged += new System.EventHandler(this.radioOptiune2_CheckedChanged);
            // 
            // radioOptiune1
            // 
            this.radioOptiune1.AutoSize = true;
            this.radioOptiune1.Location = new System.Drawing.Point(6, 12);
            this.radioOptiune1.Name = "radioOptiune1";
            this.radioOptiune1.Size = new System.Drawing.Size(81, 20);
            this.radioOptiune1.TabIndex = 0;
            this.radioOptiune1.TabStop = true;
            this.radioOptiune1.Text = "Optiune1";
            this.radioOptiune1.UseVisualStyleBackColor = true;
            this.radioOptiune1.CheckedChanged += new System.EventHandler(this.radioOptiune1_CheckedChanged);
            // 
            // btnSunet1
            // 
            this.btnSunet1.Location = new System.Drawing.Point(149, 305);
            this.btnSunet1.Name = "btnSunet1";
            this.btnSunet1.Size = new System.Drawing.Size(75, 23);
            this.btnSunet1.TabIndex = 6;
            this.btnSunet1.Text = "Sunet1";
            this.btnSunet1.UseVisualStyleBackColor = true;
            this.btnSunet1.Click += new System.EventHandler(this.btnSunet1_Click);
            // 
            // btnSunet2
            // 
            this.btnSunet2.Location = new System.Drawing.Point(271, 305);
            this.btnSunet2.Name = "btnSunet2";
            this.btnSunet2.Size = new System.Drawing.Size(75, 23);
            this.btnSunet2.TabIndex = 7;
            this.btnSunet2.Text = "Sunet2";
            this.btnSunet2.UseVisualStyleBackColor = true;
            this.btnSunet2.Click += new System.EventHandler(this.btnSunet2_Click);
            // 
            // btnSunet3
            // 
            this.btnSunet3.Location = new System.Drawing.Point(400, 305);
            this.btnSunet3.Name = "btnSunet3";
            this.btnSunet3.Size = new System.Drawing.Size(75, 23);
            this.btnSunet3.TabIndex = 8;
            this.btnSunet3.Text = "Sunet3";
            this.btnSunet3.UseVisualStyleBackColor = true;
            this.btnSunet3.Click += new System.EventHandler(this.btnSunet3_Click);
            // 
            // lblRunda
            // 
            this.lblRunda.Location = new System.Drawing.Point(221, 31);
            this.lblRunda.Name = "lblRunda";
            this.lblRunda.Size = new System.Drawing.Size(200, 23);
            this.lblRunda.TabIndex = 9;
            this.lblRunda.Text = "label2";
            this.lblRunda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRunda.Click += new System.EventHandler(this.lblRunda_Click);
            // 
            // btnRundaUrm
            // 
            this.btnRundaUrm.Location = new System.Drawing.Point(16, 13);
            this.btnRundaUrm.Name = "btnRundaUrm";
            this.btnRundaUrm.Size = new System.Drawing.Size(88, 32);
            this.btnRundaUrm.TabIndex = 10;
            this.btnRundaUrm.Text = "Next";
            this.btnRundaUrm.UseVisualStyleBackColor = true;
            this.btnRundaUrm.Click += new System.EventHandler(this.btnRundaUrm_Click);
            // 
            // btnFinalizare
            // 
            this.btnFinalizare.Location = new System.Drawing.Point(15, 11);
            this.btnFinalizare.Name = "btnFinalizare";
            this.btnFinalizare.Size = new System.Drawing.Size(88, 32);
            this.btnFinalizare.TabIndex = 11;
            this.btnFinalizare.Text = "Finalizare";
            this.btnFinalizare.UseVisualStyleBackColor = true;
            this.btnFinalizare.Click += new System.EventHandler(this.btnFinalizare_Click);
            // 
            // lblConcluzie
            // 
            this.lblConcluzie.AutoSize = true;
            this.lblConcluzie.Location = new System.Drawing.Point(12, 19);
            this.lblConcluzie.Name = "lblConcluzie";
            this.lblConcluzie.Size = new System.Drawing.Size(42, 16);
            this.lblConcluzie.TabIndex = 12;
            this.lblConcluzie.Text = "TEXT";
            this.lblConcluzie.Click += new System.EventHandler(this.lblConcluzie_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(515, 11);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 20);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Punctaj";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblPunctaj
            // 
            this.lblPunctaj.Location = new System.Drawing.Point(481, 34);
            this.lblPunctaj.Name = "lblPunctaj";
            this.lblPunctaj.Size = new System.Drawing.Size(121, 59);
            this.lblPunctaj.TabIndex = 14;
       
            // 
            // btnCauta
            // 
            this.btnCauta.Location = new System.Drawing.Point(16, 113);
            this.btnCauta.Name = "btnCauta";
            this.btnCauta.Size = new System.Drawing.Size(88, 28);
            this.btnCauta.TabIndex = 15;
            this.btnCauta.Text = "Cauta";
            this.btnCauta.UseVisualStyleBackColor = true;
            this.btnCauta.Click += new System.EventHandler(this.btnCauta_Click);
            // 
            // lblCauta
            // 
            this.lblCauta.AutoSize = true;
            this.lblCauta.BackColor = System.Drawing.Color.Transparent;
            this.lblCauta.Location = new System.Drawing.Point(13, 157);
            this.lblCauta.Name = "lblCauta";
            this.lblCauta.Size = new System.Drawing.Size(42, 16);
            this.lblCauta.TabIndex = 16;
            this.lblCauta.Text = "TEXT";
            this.lblCauta.Click += new System.EventHandler(this.lblCauta_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(16, 406);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(88, 28);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.Back_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 455);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblCauta);
            this.Controls.Add(this.btnCauta);
            this.Controls.Add(this.lblPunctaj);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lblConcluzie);
            this.Controls.Add(this.btnFinalizare);
            this.Controls.Add(this.btnRundaUrm);
            this.Controls.Add(this.lblRunda);
            this.Controls.Add(this.btnSunet3);
            this.Controls.Add(this.btnSunet2);
            this.Controls.Add(this.btnSunet1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnAdaugaUser);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblUtilizator);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUtilizator;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnAdaugaUser;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSunet1;
        private System.Windows.Forms.Button btnSunet2;
        private System.Windows.Forms.Button btnSunet3;
        private System.Windows.Forms.RadioButton radioOptiune3;
        private System.Windows.Forms.RadioButton radioOptiune2;
        private System.Windows.Forms.RadioButton radioOptiune1;
        private System.Windows.Forms.Label lblRunda;
        private System.Windows.Forms.Button btnRundaUrm;
        private System.Windows.Forms.Button btnFinalizare;
        private System.Windows.Forms.Label lblConcluzie;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblPunctaj;
        private System.Windows.Forms.Button btnCauta;
        private System.Windows.Forms.Label lblCauta;
        private System.Windows.Forms.Button btnBack;
    }
}

