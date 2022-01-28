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
    public partial class GameScreen : Form
    {

        // Variable's that stores the enemy's and the player's cells on the board that have a boat on them. 
        bool[] isHit = new bool[100];
        bool[] playerBoats = new bool[100];

        // Variable's that stores the places where the player has either been hit or missed.
        bool[] playerHits = new bool[100];
        bool[] playerMiss = new bool[100];

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
            RestartGame();
            gameTimer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            // If there are more than 20 spots entered, set the enterBoats bool to false. Meaning that boats are no longer required to be entered.
            if (numBoats == 20)
            {
                enterBoats = false;
            }

            // If the user is still in the process of entering boats, don't allow the program to go any further.
            if (enterBoats == true)
            {
                return;
            }

            // If boats aren't required to be entered, the game itself can start.
            if  (turn == false)
            {
                ComputerMove();
            }
        }

        // If the player clicks one of the enemy's cells.
        private void ClickCell(object sender, EventArgs e)
        {
            // If the player hasn't entered their ships yet, or if it's not the users turn quit the function.
            if (enterBoats == true || turn == false)
            {
                return;
            }

            // Store the cell clicked as a PictureBox object.
            PictureBox cell = (PictureBox)sender;

            // Get the number at the end of the picture box's name. This makes it so that we can index the appropriate cell.
            int index = int.Parse(((string)cell.Name).Substring(8));

            // If there's a boat sitting on the part the user clicks, then color the cell the hit color, otherwise, color it the miss color.
            if (isHit[index-1] == true)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"enemyshipsunk.wav");
                simpleSound.Play();
                cell.Image = Properties.Resources.PlayerHit;
            }

            else
            {
                SoundPlayer simpleSound = new SoundPlayer(@"missile.wav");
                simpleSound.Play();
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
            // Create an AI class object.
            AI computer = new AI();

            // Set the properties of the AI object to some bools.
            computer.misses = playerMiss;
            computer.hits = playerHits;

            // Get a move made by the computer.
            int move = computer.EasyBot();

            // Get the cell that the computer made a move on.
            PictureBox cell = picPlayer1;
            string cellName = "picPlayer" + (move + 1);

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Name == cellName)
                {
                    cell = (PictureBox)x;
                }
            }
            // If the AI's move is a hit, color the cell appropriately.
            if (playerBoats[move] == true)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"allyshipsunk.wav");
                simpleSound.Play();
                // Set the playerHits cell to true.
                playerHits[move] = true;

                // Change the picture of the cell.
                cell.Image = Properties.Resources.PlayerHit;
            }

            // If the AI's move misses, colour the cell apprpriately.
            else
            {

                // Set the playerMiss cell to true.
                playerMiss[move] = true;

                // Change the picture of the cell.
                cell.Image = Properties.Resources.miss;
            }

            turn = true;
        }

        // Function to restart game, or start it. Basically a function that sets up the game.
        private void RestartGame()
        {
            moves = 0;
            turn = true;
            enterBoats = true;

        }

        // Function that runs if the player clicks one of their own cells.
        private void ClickPlayerCell(object sender, EventArgs e)
        {
             // Store the cell clicked as a PictureBox object.
            PictureBox cell = (PictureBox)sender;

            // Get the number at the end of the picture box's name. This makes it so that we can index the appropriate cell.
            int index = int.Parse(((string)cell.Name).Substring(9));

            // If this cell is not taken and if the user is still process in the process of entering, otherwise, do nothing.
            if (playerBoats[index-1] == false && enterBoats == true)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"shipplace.wav");
                simpleSound.Play();
                playerBoats[index - 1] = true;
                cell.Image = Properties.Resources.PlayerTaken;
                numBoats++;
            }
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }


    }
}
