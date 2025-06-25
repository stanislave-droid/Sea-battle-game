namespace Морський_бій
{
    partial class Game
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
            this.LeaveButton = new System.Windows.Forms.Button();
            this.NameOfGame = new System.Windows.Forms.TextBox();
            this.MyGameArea = new System.Windows.Forms.TextBox();
            this.BotGameArea = new System.Windows.Forms.TextBox();
            this.Ship4x = new System.Windows.Forms.TextBox();
            this.Ship3x = new System.Windows.Forms.TextBox();
            this.Ship2x = new System.Windows.Forms.TextBox();
            this.Ship1x = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LeaveButton
            // 
            this.LeaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LeaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LeaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeaveButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeaveButton.ForeColor = System.Drawing.SystemColors.Menu;
            this.LeaveButton.Location = new System.Drawing.Point(1749, 55);
            this.LeaveButton.Name = "LeaveButton";
            this.LeaveButton.Size = new System.Drawing.Size(86, 35);
            this.LeaveButton.TabIndex = 0;
            this.LeaveButton.Text = "Вихід";
            this.LeaveButton.UseVisualStyleBackColor = false;
            this.LeaveButton.Click += new System.EventHandler(this.LeaveButton_Click);
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
            this.NameOfGame.Location = new System.Drawing.Point(797, 37);
            this.NameOfGame.Name = "NameOfGame";
            this.NameOfGame.ReadOnly = true;
            this.NameOfGame.Size = new System.Drawing.Size(325, 46);
            this.NameOfGame.TabIndex = 1;
            this.NameOfGame.Text = "Морський бій";
            this.NameOfGame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MyGameArea
            // 
            this.MyGameArea.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.MyGameArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyGameArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.MyGameArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MyGameArea.Enabled = false;
            this.MyGameArea.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyGameArea.ForeColor = System.Drawing.SystemColors.Menu;
            this.MyGameArea.HideSelection = false;
            this.MyGameArea.Location = new System.Drawing.Point(300, 256);
            this.MyGameArea.Name = "MyGameArea";
            this.MyGameArea.ReadOnly = true;
            this.MyGameArea.Size = new System.Drawing.Size(325, 46);
            this.MyGameArea.TabIndex = 2;
            this.MyGameArea.Text = "Моя ділянка";
            this.MyGameArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BotGameArea
            // 
            this.BotGameArea.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.BotGameArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BotGameArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.BotGameArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BotGameArea.Enabled = false;
            this.BotGameArea.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotGameArea.ForeColor = System.Drawing.SystemColors.Menu;
            this.BotGameArea.HideSelection = false;
            this.BotGameArea.Location = new System.Drawing.Point(1300, 256);
            this.BotGameArea.Name = "BotGameArea";
            this.BotGameArea.ReadOnly = true;
            this.BotGameArea.Size = new System.Drawing.Size(325, 46);
            this.BotGameArea.TabIndex = 3;
            this.BotGameArea.Text = "Бота ділянка";
            this.BotGameArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ship4x
            // 
            this.Ship4x.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Ship4x.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ship4x.BackColor = System.Drawing.Color.Blue;
            this.Ship4x.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ship4x.Enabled = false;
            this.Ship4x.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ship4x.ForeColor = System.Drawing.SystemColors.Menu;
            this.Ship4x.HideSelection = false;
            this.Ship4x.Location = new System.Drawing.Point(280, 145);
            this.Ship4x.Name = "Ship4x";
            this.Ship4x.ReadOnly = true;
            this.Ship4x.Size = new System.Drawing.Size(100, 33);
            this.Ship4x.TabIndex = 4;
            this.Ship4x.Text = "4x/1";
            this.Ship4x.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ship3x
            // 
            this.Ship3x.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Ship3x.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ship3x.BackColor = System.Drawing.Color.Blue;
            this.Ship3x.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ship3x.Enabled = false;
            this.Ship3x.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ship3x.ForeColor = System.Drawing.SystemColors.Menu;
            this.Ship3x.HideSelection = false;
            this.Ship3x.Location = new System.Drawing.Point(670, 145);
            this.Ship3x.Name = "Ship3x";
            this.Ship3x.ReadOnly = true;
            this.Ship3x.Size = new System.Drawing.Size(100, 33);
            this.Ship3x.TabIndex = 5;
            this.Ship3x.Text = "3x/2";
            this.Ship3x.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ship2x
            // 
            this.Ship2x.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Ship2x.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ship2x.BackColor = System.Drawing.Color.Blue;
            this.Ship2x.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ship2x.Enabled = false;
            this.Ship2x.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ship2x.ForeColor = System.Drawing.SystemColors.Menu;
            this.Ship2x.HideSelection = false;
            this.Ship2x.Location = new System.Drawing.Point(975, 145);
            this.Ship2x.Name = "Ship2x";
            this.Ship2x.ReadOnly = true;
            this.Ship2x.Size = new System.Drawing.Size(100, 33);
            this.Ship2x.TabIndex = 6;
            this.Ship2x.Text = "2x/3";
            this.Ship2x.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ship1x
            // 
            this.Ship1x.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Ship1x.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ship1x.BackColor = System.Drawing.Color.Blue;
            this.Ship1x.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ship1x.Enabled = false;
            this.Ship1x.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ship1x.ForeColor = System.Drawing.SystemColors.Menu;
            this.Ship1x.HideSelection = false;
            this.Ship1x.Location = new System.Drawing.Point(1200, 145);
            this.Ship1x.Name = "Ship1x";
            this.Ship1x.ReadOnly = true;
            this.Ship1x.Size = new System.Drawing.Size(52, 33);
            this.Ship1x.TabIndex = 7;
            this.Ship1x.Text = "1x/4";
            this.Ship1x.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.Ship1x);
            this.Controls.Add(this.Ship2x);
            this.Controls.Add(this.Ship3x);
            this.Controls.Add(this.Ship4x);
            this.Controls.Add(this.BotGameArea);
            this.Controls.Add(this.MyGameArea);
            this.Controls.Add(this.NameOfGame);
            this.Controls.Add(this.LeaveButton);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(640, 430);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Морський бій (Гра)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Game_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Game_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Game_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Game_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LeaveButton;
        private System.Windows.Forms.TextBox NameOfGame;
        private System.Windows.Forms.TextBox MyGameArea;
        private System.Windows.Forms.TextBox BotGameArea;
        private System.Windows.Forms.TextBox Ship4x;
        private System.Windows.Forms.TextBox Ship3x;
        private System.Windows.Forms.TextBox Ship2x;
        private System.Windows.Forms.TextBox Ship1x;
    }
}