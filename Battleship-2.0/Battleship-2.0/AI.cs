using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_2._0
{
    class AI
    {

        // Store all the positions where the AI has either missed or hit a ship.
        public bool[] misses = new bool[100];
        public bool[] hits = new bool[100];

        // Store all the AI's own ships in a variable.
        public bool[] ships = new bool[100];

        public int EasyBot()
        {
            // Create a random object.
            Random randNum = new Random();

            // Integer that will be the move played by the computer.
            int move = randNum.Next(1, 101)-1;

            // Generate a random number until it's a number that hasn't been played yet.
            while (hits[move] == true || misses[move] == true)
            {
                move = randNum.Next(1, 101)-1;
            }

            // Return the move.
            return move;
        }

        // Function that allows the AI to choose its own ships on easy mode.
        public void GenerateShip()
        {

            // Create a random object.
            Random randomGenerator = new Random();

            // Get positions for carrier ship.
            // Randomly get the orientation of the ship. If it's 1, it's horizontal; if it's 2, it's vertical.
            //int orientation = randomGenerator.Next(1, 3);
            int orientation = 1;

            // If the ship is horizontal.
            if (orientation == 1)
            {
                // Randomly generate the row and the column that the left-most cell of the ship should be on.
                int row = randomGenerator.Next(1, 11);
                int column = randomGenerator.Next(1, 7);
                int startingCell = column + (10 * (row - 1));

                for (int index = startingCell; index < startingCell+5; index++)
                {
                    ships[index - 1] = true;
                }
            }

            else if (orientation == 2)
            {
                // Randomly generate the now and the column of the top-most cell the ship should be on.
                int row = randomGenerator.Next(1, 7);
                int column = randomGenerator.Next(1, 7);

                for (int index = (column + (10 * (row-1))); index < index + (10 * row) + 1; index++)
                {
                    
                    ships[index - 1] = true;
                }
            }

            // Get positions for the cruiser ship. Must be in a while loop because it's possible that the position it's placed on is already taken.
            while (true)
            {
                // Generate the orientation of the ship.
                orientation = randomGenerator.Next(1, 3);

                // If the ship is horizontal.
                break;
            }
        }
    }
}
