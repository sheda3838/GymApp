namespace GymSample2
{
    partial class MemberJoinClassesForm
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
            this.previousbtn = new System.Windows.Forms.Button();
            this.nextbtn = new System.Windows.Forms.Button();
            this.lblclassID = new System.Windows.Forms.Label();
            this.txtTrainerID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.joinclsbtn = new System.Windows.Forms.Button();
            this.leaveclsbtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.submitbtn = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // previousbtn
            // 
            this.previousbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.previousbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousbtn.Location = new System.Drawing.Point(265, 481);
            this.previousbtn.Name = "previousbtn";
            this.previousbtn.Size = new System.Drawing.Size(86, 31);
            this.previousbtn.TabIndex = 43;
            this.previousbtn.Text = "Previous";
            this.previousbtn.UseVisualStyleBackColor = false;
            this.previousbtn.Click += new System.EventHandler(this.previousbtn_Click);
            // 
            // nextbtn
            // 
            this.nextbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.nextbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextbtn.Location = new System.Drawing.Point(457, 481);
            this.nextbtn.Name = "nextbtn";
            this.nextbtn.Size = new System.Drawing.Size(86, 31);
            this.nextbtn.TabIndex = 42;
            this.nextbtn.Text = "Next";
            this.nextbtn.UseVisualStyleBackColor = false;
            this.nextbtn.Click += new System.EventHandler(this.nextbtn_Click_1);
            // 
            // lblclassID
            // 
            this.lblclassID.AutoSize = true;
            this.lblclassID.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclassID.Location = new System.Drawing.Point(262, 181);
            this.lblclassID.Name = "lblclassID";
            this.lblclassID.Size = new System.Drawing.Size(64, 18);
            this.lblclassID.TabIndex = 41;
            this.lblclassID.Text = "Classes....";
            // 
            // txtTrainerID
            // 
            this.txtTrainerID.Location = new System.Drawing.Point(410, 131);
            this.txtTrainerID.Name = "txtTrainerID";
            this.txtTrainerID.Size = new System.Drawing.Size(160, 22);
            this.txtTrainerID.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(169, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(235, 24);
            this.label6.TabIndex = 50;
            this.label6.Text = "Search Class by TrainerID :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(361, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 37);
            this.label4.TabIndex = 58;
            this.label4.Text = "Available Classes";
            // 
            // joinclsbtn
            // 
            this.joinclsbtn.BackColor = System.Drawing.Color.SpringGreen;
            this.joinclsbtn.Font = new System.Drawing.Font("Algerian", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joinclsbtn.Location = new System.Drawing.Point(699, 214);
            this.joinclsbtn.Name = "joinclsbtn";
            this.joinclsbtn.Size = new System.Drawing.Size(132, 39);
            this.joinclsbtn.TabIndex = 59;
            this.joinclsbtn.Text = "Join Class";
            this.joinclsbtn.UseVisualStyleBackColor = false;
            this.joinclsbtn.Click += new System.EventHandler(this.joinclsbtn_Click_1);
            // 
            // leaveclsbtn
            // 
            this.leaveclsbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.leaveclsbtn.Font = new System.Drawing.Font("Algerian", 7.8F, System.Drawing.FontStyle.Bold);
            this.leaveclsbtn.Location = new System.Drawing.Point(699, 277);
            this.leaveclsbtn.Name = "leaveclsbtn";
            this.leaveclsbtn.Size = new System.Drawing.Size(132, 40);
            this.leaveclsbtn.TabIndex = 60;
            this.leaveclsbtn.Text = "Leave Class";
            this.leaveclsbtn.UseVisualStyleBackColor = false;
            this.leaveclsbtn.Click += new System.EventHandler(this.leaveclsbtn_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(214)))), ((int)(((byte)(160)))));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::GymSample2.Properties.Resources.GYMlogo2;
            this.pictureBox2.Location = new System.Drawing.Point(247, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(102, 85);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 57;
            this.pictureBox2.TabStop = false;
            // 
            // submitbtn
            // 
            this.submitbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.submitbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitbtn.Location = new System.Drawing.Point(588, 127);
            this.submitbtn.Name = "submitbtn";
            this.submitbtn.Size = new System.Drawing.Size(74, 31);
            this.submitbtn.TabIndex = 52;
            this.submitbtn.Text = "Search";
            this.submitbtn.UseVisualStyleBackColor = false;
            this.submitbtn.Click += new System.EventHandler(this.submitbtn_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(214)))), ((int)(((byte)(160)))));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox5.Image = global::GymSample2.Properties.Resources.GoBakcBtnIcon_removebg_preview;
            this.pictureBox5.Location = new System.Drawing.Point(746, 472);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(131, 61);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 61;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // MemberClassesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(214)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(880, 538);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.leaveclsbtn);
            this.Controls.Add(this.joinclsbtn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.submitbtn);
            this.Controls.Add(this.txtTrainerID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.previousbtn);
            this.Controls.Add(this.nextbtn);
            this.Controls.Add(this.lblclassID);
            this.Name = "MemberClassesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MemberViewAllClassesForm";
            this.Load += new System.EventHandler(this.MemberViewAllClassesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button previousbtn;
        private System.Windows.Forms.Button nextbtn;
        private System.Windows.Forms.Label lblclassID;
        private System.Windows.Forms.TextBox txtTrainerID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button joinclsbtn;
        private System.Windows.Forms.Button leaveclsbtn;
        private System.Windows.Forms.Button submitbtn;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}