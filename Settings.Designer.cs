namespace Морський_бій
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
            this.BotShipsVisibleSwitch = new System.Windows.Forms.CheckBox();
            this.Review = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // BotShipsVisibleSwitch
            // 
            this.BotShipsVisibleSwitch.Location = new System.Drawing.Point(59, 40);
            this.BotShipsVisibleSwitch.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.BotShipsVisibleSwitch.Name = "BotShipsVisibleSwitch";
            this.BotShipsVisibleSwitch.Size = new System.Drawing.Size(227, 30);
            this.BotShipsVisibleSwitch.TabIndex = 0;
            this.BotShipsVisibleSwitch.Text = "Показ кораблів бота \r\n(використовувати тільки для тесту)";
            this.BotShipsVisibleSwitch.UseVisualStyleBackColor = true;
            this.BotShipsVisibleSwitch.CheckedChanged += new System.EventHandler(this.BotShipsVisibleSwitch_CheckedChanged);
            this.BotShipsVisibleSwitch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Settings_close);
            // 
            // Review
            // 
            this.Review.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Review.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Review.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Review.Location = new System.Drawing.Point(59, 100);
            this.Review.Name = "Review";
            this.Review.ReadOnly = true;
            this.Review.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.Review.Size = new System.Drawing.Size(227, 320);
            this.Review.TabIndex = 1;
            this.Review.Text = resources.GetString("Review.Text");
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.Review);
            this.Controls.Add(this.BotShipsVisibleSwitch);
            this.MaximumSize = new System.Drawing.Size(400, 600);
            this.MinimumSize = new System.Drawing.Size(350, 500);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметри";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox BotShipsVisibleSwitch;
        private System.Windows.Forms.RichTextBox Review;
    }
}