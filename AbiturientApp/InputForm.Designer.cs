namespace AbiturientApp
{
    partial class InputForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.Label lblBirthYear;
        private System.Windows.Forms.TextBox tbBirthYear;
        private System.Windows.Forms.Label lblSchool;
        private System.Windows.Forms.TextBox tbSchool;
        private System.Windows.Forms.Label lblAverageScore;
        private System.Windows.Forms.TextBox tbAverageScore;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblFullName = new System.Windows.Forms.Label();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.lblBirthYear = new System.Windows.Forms.Label();
            this.tbBirthYear = new System.Windows.Forms.TextBox();
            this.lblSchool = new System.Windows.Forms.Label();
            this.tbSchool = new System.Windows.Forms.TextBox();
            this.lblAverageScore = new System.Windows.Forms.Label();
            this.tbAverageScore = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(12, 15);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(34, 13);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "ФИО";
            // 
            // tbFullName
            // 
            this.tbFullName.Location = new System.Drawing.Point(111, 12);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(247, 20);
            this.tbFullName.TabIndex = 1;
            // 
            // lblBirthYear
            // 
            this.lblBirthYear.AutoSize = true;
            this.lblBirthYear.Location = new System.Drawing.Point(12, 46);
            this.lblBirthYear.Name = "lblBirthYear";
            this.lblBirthYear.Size = new System.Drawing.Size(79, 13);
            this.lblBirthYear.TabIndex = 2;
            this.lblBirthYear.Text = "Год рождения";
            // 
            // tbBirthYear
            // 
            this.tbBirthYear.Location = new System.Drawing.Point(111, 43);
            this.tbBirthYear.Name = "tbBirthYear";
            this.tbBirthYear.Size = new System.Drawing.Size(247, 20);
            this.tbBirthYear.TabIndex = 3;
            // 
            // lblSchool
            // 
            this.lblSchool.AutoSize = true;
            this.lblSchool.Location = new System.Drawing.Point(12, 77);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(44, 13);
            this.lblSchool.TabIndex = 4;
            this.lblSchool.Text = "Школа";
            // 
            // tbSchool
            // 
            this.tbSchool.Location = new System.Drawing.Point(111, 74);
            this.tbSchool.Name = "tbSchool";
            this.tbSchool.Size = new System.Drawing.Size(247, 20);
            this.tbSchool.TabIndex = 5;
            // 
            // lblAverageScore
            // 
            this.lblAverageScore.AutoSize = true;
            this.lblAverageScore.Location = new System.Drawing.Point(12, 108);
            this.lblAverageScore.Name = "lblAverageScore";
            this.lblAverageScore.Size = new System.Drawing.Size(75, 13);
            this.lblAverageScore.TabIndex = 6;
            this.lblAverageScore.Text = "Средний балл";
            // 
            // tbAverageScore
            // 
            this.tbAverageScore.Location = new System.Drawing.Point(111, 105);
            this.tbAverageScore.Name = "tbAverageScore";
            this.tbAverageScore.Size = new System.Drawing.Size(247, 20);
            this.tbAverageScore.TabIndex = 7;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(202, 143);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 27);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(283, 143);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // InputForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(372, 182);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbAverageScore);
            this.Controls.Add(this.lblAverageScore);
            this.Controls.Add(this.tbSchool);
            this.Controls.Add(this.lblSchool);
            this.Controls.Add(this.tbBirthYear);
            this.Controls.Add(this.lblBirthYear);
            this.Controls.Add(this.tbFullName);
            this.Controls.Add(this.lblFullName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Данные абитуриента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
