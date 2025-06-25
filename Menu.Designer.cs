namespace Морський_бій
{
    partial class Menu
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
            this.NameOfGame = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameOfGame
            // 
            this.NameOfGame.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.NameOfGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameOfGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.NameOfGame.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameOfGame.Enabled = false;
            this.NameOfGame.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameOfGame.ForeColor = System.Drawing.SystemColors.Menu;
            this.NameOfGame.HideSelection = false;
            this.NameOfGame.Location = new System.Drawing.Point(797, 104);
            this.NameOfGame.Name = "NameOfGame";
            this.NameOfGame.ReadOnly = true;
            this.NameOfGame.Size = new System.Drawing.Size(325, 46);
            this.NameOfGame.TabIndex = 0;
            this.NameOfGame.Text = "Морський бій";
            this.NameOfGame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Menu;
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(770, 900);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(397, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Автор : Дрочак Станіслав";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(238)))), ((int)(((byte)(89)))));
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.ForeColor = System.Drawing.SystemColors.Menu;
            this.StartButton.Location = new System.Drawing.Point(825, 500);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(300, 150);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Settings
            // 
            this.Settings.AutoEllipsis = true;
            this.Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Settings.Image = global::Морський_бій.Properties.Resources.icons8_settings_80;
            this.Settings.Location = new System.Drawing.Point(1765, 65);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(85, 85);
            this.Settings.TabIndex = 3;
            this.Settings.Tag = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.NameOfGame);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(640, 430);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Морський бій (Меню)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Settings_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameOfGame;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button Settings;
    }
}

