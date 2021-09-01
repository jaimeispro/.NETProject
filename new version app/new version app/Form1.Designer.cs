namespace new_version_app
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
            this.CC = new System.Windows.Forms.Label();
            this.NotauserLbl = new System.Windows.Forms.Label();
            this.LoginBTN = new System.Windows.Forms.Button();
            this.NewUser = new System.Windows.Forms.Button();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.UsernameTB = new System.Windows.Forms.TextBox();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.UserLbl = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CC
            // 
            this.CC.AutoSize = true;
            this.CC.Location = new System.Drawing.Point(119, 530);
            this.CC.Name = "CC";
            this.CC.Size = new System.Drawing.Size(35, 13);
            this.CC.TabIndex = 32;
            this.CC.Text = "label1";
            // 
            // NotauserLbl
            // 
            this.NotauserLbl.AutoSize = true;
            this.NotauserLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotauserLbl.Location = new System.Drawing.Point(661, 414);
            this.NotauserLbl.Name = "NotauserLbl";
            this.NotauserLbl.Size = new System.Drawing.Size(183, 20);
            this.NotauserLbl.TabIndex = 31;
            this.NotauserLbl.Text = "Not a user click below";
            // 
            // LoginBTN
            // 
            this.LoginBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBTN.Location = new System.Drawing.Point(701, 380);
            this.LoginBTN.Name = "LoginBTN";
            this.LoginBTN.Size = new System.Drawing.Size(103, 31);
            this.LoginBTN.TabIndex = 30;
            this.LoginBTN.Text = "LogIn";
            this.LoginBTN.UseVisualStyleBackColor = true;
            this.LoginBTN.Click += new System.EventHandler(this.LoginBTN_Click);
            // 
            // NewUser
            // 
            this.NewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewUser.Location = new System.Drawing.Point(665, 446);
            this.NewUser.Name = "NewUser";
            this.NewUser.Size = new System.Drawing.Size(179, 31);
            this.NewUser.TabIndex = 29;
            this.NewUser.Text = "Create New User";
            this.NewUser.UseVisualStyleBackColor = true;
            this.NewUser.Click += new System.EventHandler(this.NewUser_Click);
            // 
            // PasswordTB
            // 
            this.PasswordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTB.Location = new System.Drawing.Point(676, 224);
            this.PasswordTB.Multiline = true;
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = '*';
            this.PasswordTB.Size = new System.Drawing.Size(151, 30);
            this.PasswordTB.TabIndex = 28;
            // 
            // UsernameTB
            // 
            this.UsernameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTB.Location = new System.Drawing.Point(676, 184);
            this.UsernameTB.Multiline = true;
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(151, 30);
            this.UsernameTB.TabIndex = 27;
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLbl.Location = new System.Drawing.Point(565, 227);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(86, 20);
            this.PasswordLbl.TabIndex = 26;
            this.PasswordLbl.Text = "Password";
            // 
            // UserLbl
            // 
            this.UserLbl.AutoSize = true;
            this.UserLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLbl.Location = new System.Drawing.Point(560, 184);
            this.UserLbl.Name = "UserLbl";
            this.UserLbl.Size = new System.Drawing.Size(91, 20);
            this.UserLbl.TabIndex = 25;
            this.UserLbl.Text = "Username";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(541, 90);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(393, 73);
            this.Title.TabIndex = 24;
            this.Title.Text = "Meeting App";
            this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 636);
            this.Controls.Add(this.CC);
            this.Controls.Add(this.NotauserLbl);
            this.Controls.Add(this.LoginBTN);
            this.Controls.Add(this.NewUser);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.UsernameTB);
            this.Controls.Add(this.PasswordLbl);
            this.Controls.Add(this.UserLbl);
            this.Controls.Add(this.Title);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CC;
        private System.Windows.Forms.Label NotauserLbl;
        private System.Windows.Forms.Button LoginBTN;
        private System.Windows.Forms.Button NewUser;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.TextBox UsernameTB;
        private System.Windows.Forms.Label PasswordLbl;
        private System.Windows.Forms.Label UserLbl;
        private System.Windows.Forms.Label Title;
    }
}

