using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Battleship_2._0
{
    public partial class LeaderBoard : Form
    {
        public LeaderBoard()
        {
            InitializeComponent();
            GetLeaderBoard();
        }

        // As soon as the form loads, load the leaderboard.
        private void GetLeaderBoard()
        {

            // Create a streamreader.
            StreamReader sr = new StreamReader(@"leaderboard.txt");

            // Get the number of items in the leaderboard.
            int numItems = int.Parse(sr.ReadLine());

            // Iterate through all the items in the leaderboard.
            for (int placement = 0; placement < numItems; placement++)
            {

                // Store the entire line split by ';; in an array.
                string[] entireLine = sr.ReadLine().Split(';');

                // Use the array to get the values for the username and the score the user got (moves).
                string username = entireLine[0];
                string score = entireLine[1];

                // If it is the first position, update the values for the first podium.
                if (placement == 0)
                {
                    lblFPuser.Text = username.ToUpper();
                    lblMoves1.Text = score;
                }

                // If it is the second position, update the values for the second podium.
                else if (placement == 1)
                {
                    lblSPuser.Text = username.ToUpper();
                    lblMoves2.Text = score;
                }

                // If it is the second position, update the values for the second podium.
                else if (placement == 2)
                {
                    lblTPuser.Text = username.ToUpper();
                    lblMoves3.Text = score;
                }
            }

            // If the size of the leaderboard is not 3, meaning that there are unfilfilled values, change the values displayed there to some defaule values.
            for (int placement = numItems; placement < 3; placement++)
            {
                if (placement == 0)
                {
                    lblFPuser.Text = "NOBODY";
                    lblMoves1.Text = "";
                }

                else if (placement == 1)
                {
                    lblSPuser.Text = "NOBODY";
                    lblMoves2.Text = "";
                }

                else if (placement == 2)
                {
                    lblTPuser.Text = "NOBODY";
                    lblMoves3.Text = "";
                }
            }

            // Close streamreader.
            sr.Close();
        }
    }
}
