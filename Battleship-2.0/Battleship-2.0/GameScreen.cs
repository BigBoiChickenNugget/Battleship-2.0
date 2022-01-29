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

        // Variable that stores the cells the player has clicked.
        bool[] isClicked = new bool[100];

        // Variable's that stores the places where the player has either been hit or missed.
        bool[] playerHits = new bool[100];
        bool[] playerMiss = new bool[100];

        // Variable that stores the number of moves the user has made so far.
        int moves = 0;

        // Boolean that shows if it's the players or computers turn. If it's true, it's the player's turn, otherwise, it's the computers turn.
        bool turn = true;

        // Variables that store the ship pictures current x and y positions.
        int shipX;
        int shipY;

        // Boolean that checks if the user is permitted to input their boat spots.
        bool enterBoats = false;
        int numBoats = 0;

        // Boolean that's meant to see if all the ships that the player has are placed properly.
        bool carrier = false;
        bool battleship = false;
        bool cruiser = false;
        bool submarine = false;
        bool destroyer = false;

        // Boolean to see if a ship is being moved or not.
        bool shipMoving = false;

        // Variable that stores the picture box of the ship that's being pressed on.
        PictureBox mouseShip;

        public GameScreen()
        {
            InitializeComponent();
            RestartGame();
            gameTimer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            // If there are more than 20 spots entered, set the enterBoats bool to false. Meaning that boats are no longer required to be entered.
            if (numBoats == 17)
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
            int index = int.Parse(((string)cell.Name).Substring(8))-1;

            // If cell has already been clicked, quit function.
            if (isClicked[index] == true)
            {
                return;
            }

            // If there's a boat sitting on the part the user clicks, then color the cell the hit color, otherwise, color it the miss color.
            if (isHit[index] == true)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"enemyshipsunk.wav");
                simpleSound.Play();
                cell.Image = Properties.Resources.hit;
            }

            else
            {
                SoundPlayer simpleSound = new SoundPlayer(@"missile.wav");
                simpleSound.Play();
                cell.Image = Properties.Resources.miss;
            }

            // Add this cell to the isClicked array. This makes it so program doesn't allow the user to click on this cell again.
            isClicked[index] = true;

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

            // Iterate through all the controls and look for the one that has a name matching the one cell chosen by the computer.
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

            // Make moves 0, set the turn to the player, and make it so that the user can deploy their boats.
            moves = 0;
            turn = true;
            enterBoats = true;

            // Get the computer to choose its ship locations.
            AI computer = new AI();

            // Make the computer choose 17 cells.
            for (int numEnemyShips = 0; numEnemyShips < 17; numEnemyShips++)
            {
                computer.ships = isHit;
                isHit[computer.EasyShip()] = true;
            }
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

                // Play sound effect.
                SoundPlayer simpleSound = new SoundPlayer(@"shipplace.wav");
                simpleSound.Play();

                // Set the playeres boat position to this cell and change the picture of the cell to display that it's taken
                playerBoats[index - 1] = true;
                cell.Image = Properties.Resources.PlayerTaken;

                // Increase the number of boats the player has placed.
                numBoats++;
            }
        }

        // If the mouse button is pressed over one of the ships, set the shipMoving variable to true, and get 
        private void HoldShip(object sender, MouseEventArgs e)
        {

            // Set the shipMoving variable to true, which means that the ship is being moved.
            shipMoving = true;

            // Store the ships initial location in the shipX and shipY variable.
            shipX = e.X;
            shipY = e.Y; 
        }

        // Function that moves the ship while the mouse is moving over it and holding down.
        private void MoveShip(object sender, MouseEventArgs e)
        {

            // Store the ship cell in a variable.
            mouseShip = (PictureBox)sender;

            // If the mouse is held down on the ship, move the ship.
            if (shipMoving == true)
            {

                // Move the ship to the location of the mouse.
                mouseShip.Top = mouseShip.Top + (e.Y - shipY);
                mouseShip.Left = mouseShip.Left + (e.X - shipX);
            }
        }

        // If the mouse is let go of on the MouseShip, stop moving the MouseShip and snap it to its nearest grid.
        private void DropShip(object sender, MouseEventArgs e)
        {

            // Set the MouseShipMoving variable to false signifying that the MouseShip is no longer moving.
            shipMoving = false;

            // Get the picturebox nearest to the mouse.
            PictureBox snappedCell = null;
            int minimumLeft = 100000000;
            int minimumTop = 100000000;

            // Iterate through all the controls.
            foreach (Control x in this.Controls)
            {

                // If the control is a picture box and it's one of the pictureboxes where the user places their boats.
                if (x is PictureBox && ((PictureBox)x).Name.Substring(0, 9) == "picPlayer")
                {

                    // If the picturebox is the closest to the user, make it the snappedCell.
                    PictureBox tmpCell = (PictureBox)x;
                    if (minimumLeft + minimumTop > Math.Abs(tmpCell.Left-mouseShip.Left) + Math.Abs(tmpCell.Top-mouseShip.Top))//minimumLeft > Math.Abs(tmpCell.Left-mouseShip.Left) && minimumTop > Math.Abs(tmpCell.Top-mouseShip.Top))
                    {
                        minimumLeft = Math.Abs(tmpCell.Left - mouseShip.Left);
                        minimumTop = Math.Abs(tmpCell.Top - mouseShip.Top);

                        snappedCell = tmpCell;
                    }
                }
            }

            // Set the position for the ship that user is dragging equal to the picture box that is closest to it.
            mouseShip.Left = snappedCell.Left;
            mouseShip.Top = snappedCell.Top;

            // Get the type and orientation of the boat.
            string shipType = (mouseShip.Name).Substring(3).ToLower();
            int size = 0;
            string orientation = "Left";

            if (mouseShip.Size.Height > mouseShip.Size.Width)
            {
                orientation = "Up";
            }

            // Get the size of the ship based on its size.
            if (shipType == "carrier")
                size = 5;
            else if (shipType == "battleship")
                size = 4;
            else if (shipType == "submarine")
                size = 3;
            else if (shipType == "cruiser")
                size = 3;
            else if (shipType == "destroyer")
                size = 2;

            // See if the ship is in an invalid location.
            int cell = int.Parse(snappedCell.Name.Substring(9));
            if (orientation == "Left")
            {

                // If the ship's size causes it to hang of the edge.
                if ((cell > 11-size && cell < 11) || (cell > 21-size && cell < 21) || (cell > 31-size && cell < 31) || (cell > 41-size && cell < 41) || (cell > 51-size && cell < 51) || (cell > 61-size && cell < 61) || (cell > 71-size && cell < 71) || (cell > 81-size && cell < 81) || (cell > 91-size && cell < 91) || cell > 101-size)
                {

                    // Inform the player that it's an invalid position.
                    MessageBox.Show("Invalid position");

                    // Set the booleans for whatever ship the user is moving to false, signifying that this ship hasn't been successfully placed.
                    if (shipType == "battleship")
                        battleship = false;
                    else if (shipType == "carrier")
                        carrier = false;
                    else if (shipType == "cruiser")
                        cruiser = false;
                    else if (shipType == "submarine")
                        submarine = false;
                    else if (shipType == "destroyer")
                        destroyer = false;
                }

                // Otherwise, the ship is valid, so set this ship's boolean value to true, signifying that it is properly placed.
                else
                {
                    if (shipType == "battleship")
                        battleship = true;
                    else if (shipType == "carrier")
                        carrier = true;
                    else if (shipType == "cruiser")
                        cruiser = true;
                    else if (shipType == "submarine")
                        submarine = true;
                    else if (shipType == "destroyer")
                        destroyer = true;
                }
            }

            // If the ship is up or down, run this code to check for an invalid position.
            else if (orientation == "Up")
            {

                // Create the row variable and set it equal to cell. The purpose of the row variable is to see what the last cell in the user's column is.
                int column = cell;
                while (column < 100)
                {
                    column += 10;
                }
                column -= 10;

                // Iterate through the column numbers that are in the column chosen above.
                for (int index = column; index >= (column - (10 * (size-2))); index -= 10)
                {

                    // If the ship is on one of these cells, it means that the ship is not in a valid position.
                    if (cell == index)
                    {

                        // Tell the user that their position is invalid.
                        MessageBox.Show("Invalid position");

                        // Set the ship's own variable to false. And brek the loop.
                        if (shipType == "battleship")
                            battleship = false;
                        else if (shipType == "carrier")
                            carrier = false;
                        else if (shipType == "cruiser")
                            cruiser = false;
                        else if (shipType == "submarine")
                            submarine = false;
                        else if (shipType == "destroyer")
                            destroyer = false;

                        break;
                    }

                    // Otherwise, set the ship's variable to true.
                    else
                    {
                        if (shipType == "battleship")
                            battleship = true;
                        else if (shipType == "carrier")
                            carrier = true;
                        else if (shipType == "cruiser")
                            cruiser = true;
                        else if (shipType == "submarine")
                            submarine = true;
                        else if (shipType == "destroyer")
                            destroyer = true;
                    }
                }
            }
        }

        private void RotateShip(object sender, KeyEventArgs e)
        {
            // Variable that will store what kind of ship it is.
            string shipType = (mouseShip.Name).Substring(3).ToLower();

            // Variable that will store the ship's orientation.
            string orientation = "Left";

            if (mouseShip.Size.Height > mouseShip.Size.Width)
            {
                orientation = "Up";
            }

            // If the ship is being held down by the mouse.
            if (shipMoving == true)
            {
               // If the user presses left arrow key, change the picture to the left version of the boat and resize the picture box.
               if (e.KeyCode == Keys.Left)
               {
                    // Picture name.
                    string picName = shipType + "Left";

                    // Show new picture.
                    mouseShip.Image = (Bitmap) Properties.Resources.ResourceManager.GetObject(picName);

                    // Resize picture box if the picture box was previous up or down.
                    if (orientation == "Up")
                    {
                        Size size = new Size(mouseShip.Size.Height, mouseShip.Size.Width);
                        mouseShip.Size = size;
                    }
               }

               // If the user presses right arrow key, change the picture to the right version of the boat and resize the picture box.
               if (e.KeyCode == Keys.Right)
               {
                    // Picture name.
                    string picName = shipType + "Right";

                    // Show new picture
                    mouseShip.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(picName);

                    // Resize picture box if the picture box was previous up or down.
                    if (orientation == "Up")
                    {
                        Size size = new Size(mouseShip.Size.Height, mouseShip.Size.Width);
                        mouseShip.Size = size;
                    }
               }


               // If the user presses down arrow key. 
               if (e.KeyCode == Keys.Down)
               {
                    // Picture name.
                    string picName = shipType + "Down";

                    // Apply new picture.
                    mouseShip.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(picName);

                    // Resize picture box if the picturebox was previous left or right.
                    if (orientation == "Left")
                    {
                        Size size = new Size(mouseShip.Size.Height, mouseShip.Size.Width);
                        mouseShip.Size = size;
                    }
               }

               // If the user presses up arrow key. 
               if (e.KeyCode == Keys.Up)
               {

                    // Picture name.
                    string picName = shipType + "Up";

                    // Apply new picture.
                    mouseShip.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(picName);

                    // Resize picture box if the picturebox was previous left or right.
                    if (orientation == "Left")
                    {
                        Size size = new Size(mouseShip.Size.Height, mouseShip.Size.Width);
                        mouseShip.Size = size;
                    }
               }
            }
        }
    }
}
