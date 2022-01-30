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

            // The initial size of the ship is 5, because the first ship done will be the carrier.
            int size = 5;

            // Variable to see if the submarine has been placed yet.
            bool submarinePlaced = false;

            while (size > 1)
            {
                // Get positions for the battleship ship. Must be in a while loop because it's possible that the position it's placed on is already taken.
                while (true)
                {
                    // Generate the orientation of the ship.
                    int orientation = randomGenerator.Next(1, 3);

                    // If the ship is horizontal.
                    if (orientation == 1)
                    {
                        // Randomly generate the row and the column that the left-most cell will be on.
                        int row = randomGenerator.Next(1, 11);
                        int column = randomGenerator.Next(1, 11-(size-1));
                        int startingCell = column + (10 * (row - 1));

                        // Variable to see if the position played is valid (cells aren't taken by another cell).
                        bool validPosition = true;

                        // Check to see if another ship lies in the cells.
                        for (int index = startingCell; index < startingCell+size; index++)
                        {
                            if (ships[index - 1] == true)
                            {
                                validPosition = false;
                                break;
                            }
                        }

                        // If the positions are taken, start the while loop again.
                        if (validPosition == false)
                            continue;

                        // Set the cells the ship lies on to true, signifying that there're ships in those cells.
                        for (int index = startingCell; index < startingCell+size; index++)
                        {
                            ships[index - 1] = true;
                        }

                        // Break while loop.
                        break;
                    }

                    // Run this code if the ship is meant to be placed vertically.
                    else if (orientation == 2)
                    {
                        // Randomly generate the row and the column that the top-most cell will be on.
                        int row = randomGenerator.Next(1, 11-(size-1));
                        int column = randomGenerator.Next(1, 11);
                        int startingCell = column + (10 * (row - 1));

                        // Variable to see if the position the ship will be on are already taken by another ship.
                        bool validPosition = true;

                        // Check to see if the positions are taken.
                        for (int index = startingCell; index < startingCell + (10 * (size - 1)) + 1; index++)
                        {
                            // If the spot is taken, set validPosition to false, signifying that this spot is taken and break the for loop.
                            if (ships[index - 1] == true)
                            {
                                validPosition = false;
                                break;
                            }
                        }

                        // If validPosition is false, start the while loop again.
                        if (validPosition == false)
                            continue;
                        
                        // If validPosition is true, set the cells to true.
                        for (int index = startingCell; index < startingCell + (10 * (size - 1)) + 1; index += 10)
                        {
                            // Set the cell to true.
                            ships[index - 1] = true;
                        }

                        // Break the while loop.
                        break;
                    }
                }

                // Deincrement the size variable signifying that the ship have been successfully placed; however, if the size variable is 3, then keep it at 3 because there are two ships at size 3.
                if (size == 3 && submarinePlaced == false)
                {
                    submarinePlaced = true;
                    continue;
                }

                size--;
            }
        }
    }
}
