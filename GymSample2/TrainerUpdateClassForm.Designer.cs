namespace GymSample2
{
    partial class TrainerUpdateClassForm
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
            this.updateclassbtn = new System.Windows.Forms.Button();
            this.txtmaxparticipants = new System.Windows.Forms.NumericUpDown();
            this.txtdate = new System.Windows.Forms.DateTimePicker();
            this.txtclassdescription = new System.Windows.Forms.RichTextBox();
            this.txtclassname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtmaxparticipants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // updateclassbtn
            // 
            this.updateclassbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.updateclassbtn.Font = new System.Drawing.Font("Algerian", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateclassbtn.Location = new System.Drawing.Point(314, 381);
            this.updateclassbtn.Name = "updateclassbtn";
            this.updateclassbtn.Size = new System.Drawing.Size(121, 41);
            this.updateclassbtn.TabIndex = 56;
            this.updateclassbtn.Text = "Update";
            this.updateclassbtn.UseVisualStyleBackColor = false;
            this.updateclassbtn.Click += new System.EventHandler(this.updateclassbtn_Click);
            // 
            // txtmaxparticipants
            // 
            this.txtmaxparticipants.Location = new System.Drawing.Point(340, 311);
            this.txtmaxparticipants.Name = "txtmaxparticipants";
            this.txtmaxparticipants.Size = new System.Drawing.Size(120, 22);
            this.txtmaxparticipants.TabIndex = 55;
            // 
            // txtdate
            // 
            this.txtdate.Location = new System.Drawing.Point(340, 260);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(191, 22);
            this.txtdate.TabIndex = 53;
            // 
            // txtclassdescription
            // 
            this.txtclassdescription.Location = new System.Drawing.Point(340, 170);
            this.txtclassdescription.Name = "txtclassdescription";
            this.txtclassdescription.Size = new System.Drawing.Size(191, 51);
            this.txtclassdescription.TabIndex = 51;
            this.txtclassdescription.Text = "";
            // 
            // txtclassname
            // 
            this.txtclassname.Location = new System.Drawing.Point(340, 123);
            this.txtclassname.Name = "txtclassname";
            this.txtclassname.Size = new System.Drawing.Size(191, 22);
            this.txtclassname.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(323, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 37);
            this.label6.TabIndex = 81;
            this.label6.Text = "Update Class";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(132, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 20);
            this.label5.TabIndex = 79;
            this.label5.Text = "Max Participants : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(164, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 23);
            this.label4.TabIndex = 78;
            this.label4.Text = "Sheduled Date : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(144, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 23);
            this.label3.TabIndex = 77;
            this.label3.Text = "Class Description :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(186, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 23);
            this.label2.TabIndex = 76;
            this.label2.Text = "Class Name : ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(214)))), ((int)(((byte)(172)))));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::GymSample2.Properties.Resources.GYMlogo2;
            this.pictureBox2.Location = new System.Drawing.Point(198, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(102, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 80;
            this.pictureBox2.TabStop = false;
            // 
            // TrainerUpdateClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(214)))), ((int)(((byte)(172)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.updateclassbtn);
            this.Controls.Add(this.txtmaxparticipants);
            this.Controls.Add(this.txtdate);
            this.Controls.Add(this.txtclassdescription);
            this.Controls.Add(this.txtclassname);
            this.Name = "TrainerUpdateClassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrainerUpdateClassForm";
            this.Load += new System.EventHandler(this.TrainerUpdateClassForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtmaxparticipants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateclassbtn;
        private System.Windows.Forms.NumericUpDown txtmaxparticipants;
        private System.Windows.Forms.DateTimePicker txtdate;
        private System.Windows.Forms.RichTextBox txtclassdescription;
        private System.Windows.Forms.TextBox txtclassname;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}