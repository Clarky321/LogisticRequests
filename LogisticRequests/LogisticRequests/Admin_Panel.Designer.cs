namespace LogisticRequests
{
    partial class Admin_Panel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Panel));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSave2 = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(560, 249);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnSave2
            // 
            this.btnSave2.Animated = true;
            this.btnSave2.BackColor = System.Drawing.Color.Transparent;
            this.btnSave2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave2.BorderColor = System.Drawing.Color.White;
            this.btnSave2.BorderRadius = 10;
            this.btnSave2.BorderThickness = 1;
            this.btnSave2.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave2.FillColor = System.Drawing.Color.Black;
            this.btnSave2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave2.ForeColor = System.Drawing.Color.White;
            this.btnSave2.Location = new System.Drawing.Point(12, 305);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(164, 44);
            this.btnSave2.TabIndex = 50;
            this.btnSave2.Text = "Сохранить";
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // btnDelete2
            // 
            this.btnDelete2.Animated = true;
            this.btnDelete2.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete2.BorderColor = System.Drawing.Color.White;
            this.btnDelete2.BorderRadius = 10;
            this.btnDelete2.BorderThickness = 1;
            this.btnDelete2.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete2.FillColor = System.Drawing.Color.Black;
            this.btnDelete2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete2.ForeColor = System.Drawing.Color.White;
            this.btnDelete2.Location = new System.Drawing.Point(408, 305);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(164, 44);
            this.btnDelete2.TabIndex = 52;
            this.btnDelete2.Text = "Удалить";
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(218, 32);
            this.guna2HtmlLabel1.TabIndex = 53;
            this.guna2HtmlLabel1.Text = "Администрирование";
            // 
            // Admin_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.btnDelete2);
            this.Controls.Add(this.btnSave2);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin_Panel";
            this.Text = "Аккаунты";
            this.Load += new System.EventHandler(this.Admin_Panel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2Button btnSave2;
        private Guna.UI2.WinForms.Guna2Button btnDelete2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}