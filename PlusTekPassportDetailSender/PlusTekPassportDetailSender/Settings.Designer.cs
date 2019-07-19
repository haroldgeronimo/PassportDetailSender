namespace PlusTekPassportDetailSender
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.fileLocationTxt = new System.Windows.Forms.TextBox();
            this.LocateBtn = new System.Windows.Forms.Button();
            this.URLTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TestBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.locateDbFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Db File Location";
            // 
            // fileLocationTxt
            // 
            this.fileLocationTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLocationTxt.Location = new System.Drawing.Point(150, 17);
            this.fileLocationTxt.Name = "fileLocationTxt";
            this.fileLocationTxt.Size = new System.Drawing.Size(457, 28);
            this.fileLocationTxt.TabIndex = 1;
            // 
            // LocateBtn
            // 
            this.LocateBtn.Location = new System.Drawing.Point(613, 13);
            this.LocateBtn.Name = "LocateBtn";
            this.LocateBtn.Size = new System.Drawing.Size(110, 36);
            this.LocateBtn.TabIndex = 2;
            this.LocateBtn.Text = "Locate File";
            this.LocateBtn.UseVisualStyleBackColor = true;
            this.LocateBtn.Click += new System.EventHandler(this.LocateBtn_Click);
            // 
            // URLTxt
            // 
            this.URLTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.URLTxt.Location = new System.Drawing.Point(150, 59);
            this.URLTxt.Name = "URLTxt";
            this.URLTxt.Size = new System.Drawing.Size(457, 28);
            this.URLTxt.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "API URL";
            // 
            // TestBtn
            // 
            this.TestBtn.Location = new System.Drawing.Point(613, 54);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(110, 36);
            this.TestBtn.TabIndex = 5;
            this.TestBtn.Text = "Test";
            this.TestBtn.UseVisualStyleBackColor = true;
            this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Username";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(613, 177);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(110, 36);
            this.SaveBtn.TabIndex = 8;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTxt.Location = new System.Drawing.Point(150, 102);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(457, 28);
            this.UsernameTxt.TabIndex = 7;
            // 
            // locateDbFileDialogue
            // 
            this.locateDbFileDialogue.DefaultExt = "mdb";
            this.locateDbFileDialogue.Filter = "Microsoft Database File (*.mdb) | *.mdb";
            // 
            // Settings
            // 
            this.AcceptButton = this.SaveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(733, 227);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.UsernameTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TestBtn);
            this.Controls.Add(this.URLTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LocateBtn);
            this.Controls.Add(this.fileLocationTxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileLocationTxt;
        private System.Windows.Forms.Button LocateBtn;
        private System.Windows.Forms.TextBox URLTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button TestBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.OpenFileDialog locateDbFileDialogue;
    }
}