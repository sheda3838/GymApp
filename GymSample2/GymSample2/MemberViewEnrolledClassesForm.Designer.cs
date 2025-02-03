namespace GymSample2
{
    partial class MemberViewEnrolledClassesForm
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
            this.leavebtn = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // previousbtn
            // 
            this.previousbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.previousbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.previousbtn.Location = new System.Drawing.Point(238, 407);
            this.previousbtn.Name = "previousbtn";
            this.previousbtn.Size = new System.Drawing.Size(102, 31);
            this.previousbtn.TabIndex = 45;
            this.previousbtn.Text = "Previous";
            this.previousbtn.UseVisualStyleBackColor = false;
            this.previousbtn.Click += new System.EventHandler(this.previousbtn_Click);
            // 
            // nextbtn
            // 
            this.nextbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.nextbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.nextbtn.Location = new System.Drawing.Point(430, 407);
            this.nextbtn.Name = "nextbtn";
            this.nextbtn.Size = new System.Drawing.Size(98, 31);
            this.nextbtn.TabIndex = 44;
            this.nextbtn.Text = "Next";
            this.nextbtn.UseVisualStyleBackColor = false;
            this.nextbtn.Click += new System.EventHandler(this.nextbtn_Click);
            // 
            // lblclassID
            // 
            this.lblclassID.AutoSize = true;
            this.lblclassID.Font = new System.Drawing.Font("Palatino Linotype", 7.8F);
            this.lblclassID.Location = new System.Drawing.Point(242, 125);
            this.lblclassID.Name = "lblclassID";
            this.lblclassID.Size = new System.Drawing.Size(109, 18);
            this.lblclassID.TabIndex = 43;
            this.lblclassID.Text = "Trainer Classes...";
            // 
            // leavebtn
            // 
            this.leavebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.leavebtn.Font = new System.Drawing.Font("Algerian", 7.8F, System.Drawing.FontStyle.Bold);
            this.leavebtn.Location = new System.Drawing.Point(649, 227);
            this.leavebtn.Name = "leavebtn";
            this.leavebtn.Size = new System.Drawing.Size(113, 35);
            this.leavebtn.TabIndex = 46;
            this.leavebtn.Text = "Leave";
            this.leavebtn.UseVisualStyleBackColor = false;
            this.leavebtn.Click += new System.EventHandler(this.leavebtn_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(214)))), ((int)(((byte)(160)))));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox5.Image = global::GymSample2.Properties.Resources.GoBakcBtnIcon_removebg_preview;
            this.pictureBox5.Location = new System.Drawing.Point(663, 386);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(131, 61);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 64;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(214)))), ((int)(((byte)(160)))));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::GymSample2.Properties.Resources.GYMlogo2;
            this.pictureBox2.Location = new System.Drawing.Point(207, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(102, 85);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 62;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(321, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 37);
            this.label4.TabIndex = 63;
            this.label4.Text = "Enrolled Classes";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ViewMemberClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(214)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(800, 466);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.leavebtn);
            this.Controls.Add(this.previousbtn);
            this.Controls.Add(this.nextbtn);
            this.Controls.Add(this.lblclassID);
            this.Name = "ViewMemberClassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewMemberClassForm";
            this.Load += new System.EventHandler(this.ViewMemberClassForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button previousbtn;
        private System.Windows.Forms.Button nextbtn;
        private System.Windows.Forms.Label lblclassID;
        private System.Windows.Forms.Button leavebtn;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
    }
}