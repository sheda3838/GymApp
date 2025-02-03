namespace GymSample2
{
    partial class MemberAttendanceForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.AttendanceList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceList)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(157, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 37);
            this.label4.TabIndex = 64;
            this.label4.Text = "Member Attendance";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(185)))), ((int)(((byte)(171)))));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::GymSample2.Properties.Resources.GYMlogo2;
            this.pictureBox2.Location = new System.Drawing.Point(49, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(102, 85);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 63;
            this.pictureBox2.TabStop = false;
            // 
            // AttendanceList
            // 
            this.AttendanceList.AllowUserToAddRows = false;
            this.AttendanceList.AllowUserToDeleteRows = false;
            this.AttendanceList.AllowUserToResizeColumns = false;
            this.AttendanceList.AllowUserToResizeRows = false;
            this.AttendanceList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(185)))), ((int)(((byte)(171)))));
            this.AttendanceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AttendanceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttendanceList.Location = new System.Drawing.Point(49, 134);
            this.AttendanceList.Name = "AttendanceList";
            this.AttendanceList.ReadOnly = true;
            this.AttendanceList.RowHeadersWidth = 51;
            this.AttendanceList.RowTemplate.Height = 24;
            this.AttendanceList.Size = new System.Drawing.Size(479, 242);
            this.AttendanceList.TabIndex = 65;
            this.AttendanceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // MemberAttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(185)))), ((int)(((byte)(171)))));
            this.ClientSize = new System.Drawing.Size(599, 444);
            this.Controls.Add(this.AttendanceList);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label4);
            this.Name = "MemberAttendanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MemberAttendanceForm";
            this.Load += new System.EventHandler(this.MemberAttendanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView AttendanceList;
    }
}