using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship_2._0
{
    public partial class SelectDifficulty : Form
    {
        public static SelectDifficulty selectDifficulty;
        public SelectDifficulty()
        {
            InitializeComponent();
            selectDifficulty = this;
        }

        private void EasySelect(object sender, EventArgs e)
        {
            EasyDesc.Visible = true;
            NormalDesc.Visible = false;
            HardDesc.Visible = false;

            Confirm.Visible = true;
        }

        private void NormalSelect(object sender, EventArgs e)
        {
            EasyDesc.Visible = false;
            NormalDesc.Visible = true;
            HardDesc.Visible = false;

            Confirm.Visible = true;
        }

        private void HardSelect(object sender, EventArgs e)
        {
            EasyDesc.Visible = false;
            NormalDesc.Visible = false;
            HardDesc.Visible = true;

            Confirm.Visible = true;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            GameScreen game = new GameScreen();

            if (HardDesc.Visible == true)
            {
                GameScreen.selectDifficulty.lvl.Text = ("HARD");
            }
            else if (NormalDesc.Visible == true)
            {
                GameScreen.selectDifficulty.lvl.Text = ("NORMAL");
            }
            else
            {
                GameScreen.selectDifficulty.lvl.Text = ("EASY");
            }
            this.Hide();
            game.ShowDialog();
            this.Show();
            
        }
    }
}
