using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Battleship_2._0
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            player.URL = "battleship_8-bit_music.mp3";
            player.controls.play();
        }

        private void QuitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartNew(object sender, EventArgs e)
        {
            GameScreen game = new GameScreen();
            this.Hide();
            game.ShowDialog();
            this.Show();
        }

        private void Settings(object sender, EventArgs e)
        {
            Settings setting = new Settings();
            this.Hide();
            setting.ShowDialog();
            this.Show();
        }
    }
}
