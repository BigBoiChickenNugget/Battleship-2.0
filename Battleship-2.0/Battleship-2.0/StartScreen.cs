using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace Battleship_2._0
{
    public partial class StartScreen : Form
    {
        private SoundPlayer Player = new SoundPlayer();

        public StartScreen()
        {
            InitializeComponent();
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            player.URL = @"mainmusic.wav";
            player.controls.play();
           
        }

        private void QuitGame(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"menuclick1.wav");
            simpleSound.Play();
            Application.Exit();
        }

        private void StartNew(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"menuclick1.wav");
            simpleSound.Play();
            GameScreen game = new GameScreen();
            this.Hide();
            game.ShowDialog();
            this.Show();
        }

        private void Settings(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"menuclick1.wav");
            simpleSound.Play();
            Settings setting = new Settings();
            this.Hide();
            setting.ShowDialog();
            this.Show();
        }
    }
}
