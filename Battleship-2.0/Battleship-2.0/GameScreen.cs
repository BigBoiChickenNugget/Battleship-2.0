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
    public partial class GameScreen : Form
    {

        // Variable that stores the enemy's side of the board that have the boat on them.
        bool[] IsHit = new bool[100];
        bool[] playerBoats = new bool[100];

        // Variable that stores the number of moves the user has made so far.
        int moves = 0;

        // Boolean that shows if it's the players or computers turn. If it's true, it's the player's turn, otherwise, it's the computers turn.
        bool turn = true;

        // Boolean that checks if the user is permitted to input their boat spots.
        bool enterBoats = false;
        int numBoats = 0;

        public GameScreen()
        {
            InitializeComponent();
            StartGame();
            if (numBoats == 20)
            {
                enterBoats = false;
                gameTimer.Start();
            }
        }

        private void Tick(object sender, EventArgs e)
        {
            if  (turn == false)
            {
                ComputerMove();
            }
        }

        private void ClickCell(object sender, EventArgs e)
        {

            // Store the cell clicked as a PictureBox object.
            PictureBox cell = (PictureBox)sender;

            // Get the number at the end of the picture box's name. This makes it so that we can index the appropriate cell.
            int index = int.Parse(((string)cell.Name).Substring(8));

            // If there's a boat sitting on the part the user clicks, then color the cell the hit color, otherwise, color it the miss color.
            if (IsHit[index-1] == true)
            {
                cell.Image = Properties.Resources.hit;
            }

            else
            {
                cell.Image = Properties.Resources.miss;
            }

            // Increment the move counter by one.
            moves++;
            lblMoves.Text = "Move: " + moves;

            // Set it to the computers turn.
            turn = false;
        }

        private void ComputerMove()
        {

        }

        private void StartGame()
        {
            moves = 0;
            turn = true;
            enterBoats = true;
        }

        private void ClickPlayerCell(object sender, EventArgs e)
        {

             // Store the cell clicked as a PictureBox object.
            PictureBox cell = (PictureBox)sender;

            // Get the number at the end of the picture box's name. This makes it so that we can index the appropriate cell.
            int index = int.Parse(((string)cell.Name).Substring(9));

            // If this cell is not taken.
            if (playerBoats[index-1] == false && enterBoats == true)
            {
                playerBoats[index - 1] = true;
                cell.Image = Properties.Resources.PlayerTaken;
                numBoats++;
            }
        }
    }
}
