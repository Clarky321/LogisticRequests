namespace LogisticRequests
{
    partial class sign_up
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sign_up));
            this.TextBox_Password2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.TextBox_User2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnPass = new System.Windows.Forms.Label();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnCreate = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogIN = new System.Windows.Forms.Label();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.TextBox_FIO = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // TextBox_Password2
            // 
            this.TextBox_Password2.Animated = true;
            this.TextBox_Password2.BorderColor = System.Drawing.Color.Indigo;
            this.TextBox_Password2.BorderRadius = 10;
            this.TextBox_Password2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_Password2.DefaultText = "";
            this.TextBox_Password2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBox_Password2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBox_Password2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_Password2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_Password2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_Password2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.TextBox_Password2.ForeColor = System.Drawing.Color.Black;
            this.TextBox_Password2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_Password2.Location = new System.Drawing.Point(13, 125);
            this.TextBox_Password2.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_Password2.MaxLength = 30;
            this.TextBox_Password2.Name = "TextBox_Password2";
            this.TextBox_Password2.PasswordChar = '\0';
            this.TextBox_Password2.PlaceholderText = "Пароль";
            this.TextBox_Password2.SelectedText = "";
            this.TextBox_Password2.Size = new System.Drawing.Size(279, 29);
            this.TextBox_Password2.TabIndex = 19;
            // 
            // TextBox_User2
            // 
            this.TextBox_User2.Animated = true;
            this.TextBox_User2.BorderColor = System.Drawing.Color.Indigo;
            this.TextBox_User2.BorderRadius = 10;
            this.TextBox_User2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_User2.DefaultText = "";
            this.TextBox_User2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBox_User2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBox_User2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_User2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_User2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_User2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.TextBox_User2.ForeColor = System.Drawing.Color.Black;
            this.TextBox_User2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_User2.Location = new System.Drawing.Point(13, 88);
            this.TextBox_User2.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_User2.MaxLength = 30;
            this.TextBox_User2.Name = "TextBox_User2";
            this.TextBox_User2.PasswordChar = '\0';
            this.TextBox_User2.PlaceholderText = "Логин";
            this.TextBox_User2.SelectedText = "";
            this.TextBox_User2.Size = new System.Drawing.Size(279, 29);
            this.TextBox_User2.TabIndex = 18;
            // 
            // btnPass
            // 
            this.btnPass.AutoSize = true;
            this.btnPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPass.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnPass.Location = new System.Drawing.Point(12, 168);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(111, 17);
            this.btnPass.TabIndex = 17;
            this.btnPass.Text = "Показать/Скрыть";
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(80, 12);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(132, 32);
            this.guna2HtmlLabel2.TabIndex = 16;
            this.guna2HtmlLabel2.Text = "Регистрация";
            // 
            // btnCreate
            // 
            this.btnCreate.Animated = true;
            this.btnCreate.BackColor = System.Drawing.SystemColors.Control;
            this.btnCreate.BorderColor = System.Drawing.Color.Indigo;
            this.btnCreate.BorderRadius = 10;
            this.btnCreate.BorderThickness = 1;
            this.btnCreate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCreate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCreate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCreate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCreate.FillColor = System.Drawing.Color.Black;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(12, 199);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(280, 41);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "Создать";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnLogIN
            // 
            this.btnLogIN.AutoSize = true;
            this.btnLogIN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogIN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLogIN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnLogIN.Location = new System.Drawing.Point(176, 251);
            this.btnLogIN.Name = "btnLogIN";
            this.btnLogIN.Size = new System.Drawing.Size(42, 17);
            this.btnLogIN.TabIndex = 21;
            this.btnLogIN.Text = "Войти";
            this.btnLogIN.Click += new System.EventHandler(this.btnLogIN_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(45, 250);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(125, 19);
            this.guna2HtmlLabel1.TabIndex = 20;
            this.guna2HtmlLabel1.Text = "У меня есть аккаунт!";
            // 
            // TextBox_FIO
            // 
            this.TextBox_FIO.Animated = true;
            this.TextBox_FIO.BorderColor = System.Drawing.Color.Indigo;
            this.TextBox_FIO.BorderRadius = 10;
            this.TextBox_FIO.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_FIO.DefaultText = "";
            this.TextBox_FIO.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBox_FIO.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBox_FIO.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_FIO.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_FIO.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_FIO.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.TextBox_FIO.ForeColor = System.Drawing.Color.Black;
            this.TextBox_FIO.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_FIO.Location = new System.Drawing.Point(13, 51);
            this.TextBox_FIO.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_FIO.MaxLength = 30;
            this.TextBox_FIO.Name = "TextBox_FIO";
            this.TextBox_FIO.PasswordChar = '\0';
            this.TextBox_FIO.PlaceholderText = "ФИО";
            this.TextBox_FIO.SelectedText = "";
            this.TextBox_FIO.Size = new System.Drawing.Size(279, 29);
            this.TextBox_FIO.TabIndex = 22;
            // 
            // sign_up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(304, 281);
            this.Controls.Add(this.TextBox_FIO);
            this.Controls.Add(this.btnLogIN);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.TextBox_Password2);
            this.Controls.Add(this.TextBox_User2);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.btnCreate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "sign_up";
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.sign_up_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox TextBox_Password2;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_User2;
        private System.Windows.Forms.Label btnPass;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button btnCreate;
        private System.Windows.Forms.Label btnLogIN;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_FIO;
    }
}