using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Морський_бій
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private static Settings settingsInstance;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете вийти?", "Вихід", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Game = new Game();
            Game.Show();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            if (settingsInstance == null || settingsInstance.IsDisposed)
            {
                settingsInstance = new Settings();
                settingsInstance.Show();
            }
            else
            {
                settingsInstance.Focus(); // ✅ Якщо форма вже існує, просто активуємо її
            }
        }
        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (settingsInstance == null || settingsInstance.IsDisposed)
                {
                settingsInstance = new Settings();
                settingsInstance.Show();
                };
            }
            else
            {
                settingsInstance.Focus(); // ✅ Якщо форма вже існує, просто активуємо її
            };
        }
    }
}
