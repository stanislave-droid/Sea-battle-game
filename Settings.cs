using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Морський_бій
{
    public partial class Settings : Form
    {

        public Settings()
        {
            InitializeComponent();
            
        }

        public void BotShipsVisibleSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.BotShipsVisible = BotShipsVisibleSwitch.Checked;
            Properties.Settings.Default.Save(); // ✅ Зберігає вибір
            if (BotShipsVisibleSwitch.Checked == true)
            {
                Морський_бій.Game.isVisible = true;
            }
            else
            {
                Морський_бій.Game.isVisible = false;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            BotShipsVisibleSwitch.Checked = Properties.Settings.Default.BotShipsVisible; // ✅ Встановлює попередній стан чекбоксу
        }

        private void Settings_close(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            Console.WriteLine("Bye");
            return;
        }

    }
}

