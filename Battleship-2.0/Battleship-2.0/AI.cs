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

        // Array that stores the probabilities of a specific cell having a boat.
        private int[] probabilities = new int[100];

        // Booleans that store whether or not a ship as been sunk.
        public bool carrier;
        public bool battleship;
        public bool cruiser;
        public bool submarine;
        public bool destroyer;

        public int EasyBot()
        {
            // Create a random object.
            Random randNum = new Random();

            // Integer that will be the move played by the computer.
            int move = randNum.Next(1, 101) - 1;

            // Generate a random number until it's a number that hasn't been played yet.
            while (hits[move] == true || misses[move] == true)
            {
                move = randNum.Next(1, 101) - 1;
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

            // Iterate through all the ship sizees starting from the biggest and generate their positions.
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
                        int column = randomGenerator.Next(1, 11 - (size - 1));
                        int startingCell = column + (10 * (row - 1));

                        // Variable to see if the position played is valid (cells aren't taken by another cell).
                        bool validPosition = true;

                        // Check to see if another ship lies in the cells.
                        for (int index = startingCell; index < startingCell + size; index++)
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
                        for (int index = startingCell; index < startingCell + size; index++)
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
                        int row = randomGenerator.Next(1, 11 - (size - 1));
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

        // The medium level AI employs the "Hunt and Target" algorithm.
        // The way this algorithm works is that it initially "hunts" for a cell that has a boat on it, and then it switches to "target" mode.
        // In "target" mode the algorithm looks all around the blocks that are hit, and then it switches back to "hunt" mode.
        public int MediumBot()
        {
            // Array that stores the indexes for all the cells that are found to be hit by the AI.
            int[] possibleTargets = new int[0];

            // Iterate through all the cells of the player and check if any of them have a hit made on them by the AI.
            for (int index = 0; index < 100; index++)
            {

                // If the user has made a hit on position.
                if (hits[index] == true)
                {

                    // Resize the array and add the hit cell's index to the array.
                    Array.Resize(ref possibleTargets, possibleTargets.Length + 1);
                    possibleTargets[possibleTargets.Length - 1] = index;
                }
            }

            // If the possibleTargets is not empty, it means that it is possible for this code to be in target mode.
            if (possibleTargets.Length != 0)
            {

                // Iterate through all the items in the possibleTargets array.
                for (int index = 0; index < possibleTargets.Length; index++)
                {

                    // Booleans that check if the cell is bordering any borders.
                    bool borderNorth = false;
                    bool borderSouth = false;
                    bool borderEast = false;
                    bool borderWest = false;

                    // If the cell is on the right-most column, then it borders on the East side.
                    for (int i = 9; i < 100; i += 10)
                        if (possibleTargets[index] == i)
                            borderEast = true;

                    // If the cell is on the bottom row, then it borders on the South side.
                    for (int i = 90; i < 100; i++)
                        if (possibleTargets[index] == i)
                            borderSouth = true;

                    // If the cell is on the top row, then it borders on the North side.
                    for (int i = 0; i < 10; i++)
                        if (possibleTargets[index] == i)
                            borderNorth = true;

                    // If the cell is on the left-most column, then it borders on the West side.
                    for (int i = 0; i < 100; i += 10)
                        if (possibleTargets[index] == i)
                            borderWest = true;

                    // Return the cell that is East of the target cell if there is no border and that cell hasn't been hit or missed yet.
                    if (borderEast == false)
                        if (hits[possibleTargets[index] + 1] == false && misses[possibleTargets[index] + 1] == false)
                            return possibleTargets[index] + 1;

                    // Return the cell that is West of the target cell if there is no border and that cell hasn't been hit or missed yet.
                    if (borderWest == false)
                        if (hits[possibleTargets[index] - 1] == false && misses[possibleTargets[index] - 1] == false)
                            return possibleTargets[index] - 1;

                    // Return the cell that is South of the target cell if there is no border and that cell hasn't been hit or missed yet.
                    if (borderSouth == false)
                        if (hits[possibleTargets[index] + 10] == false && misses[possibleTargets[index] + 10] == false)
                            return possibleTargets[index] + 10;

                    // Return teh cell that is North of the target cell if there is no border and that cell hasn't been hit or missed yet.
                    if (borderNorth == false)
                        if (hits[possibleTargets[index] - 10] == false && misses[possibleTargets[index] - 10] == false)
                            return possibleTargets[index] - 10;
                }
            }

            // If no value has been returned yet, it means that the algorithm is in hunt mode, so the AI can just play a random value.
            int move = EasyBot();

            // Since the smallest ship is of size two, that means that we only have to hunt half the board for ships, so we only have to return the numbers that are even (including 0) from 0-99.
            while (true)
            {

                // The pattern followed by the cells is that they're divisible by 2 in the first row, not in the second, and so on.
                // This will make the board look somewhat like a chess board, and reduces the number of searches the AI will need to perform by half.
                if (move < 10 && move % 2 == 0)
                    break;
                else if (move >= 10 && move < 20 && move % 2 != 0)
                    break;
                else if (move >= 20 && move < 30 && move % 2 == 0)
                    break;
                else if (move >= 30 && move < 40 && move % 2 != 0)
                    break;
                else if (move >= 40 && move < 50 && move % 2 == 0)
                    break;
                else if (move >= 50 && move < 60 && move % 2 != 0)
                    break;
                else if (move >= 60 && move < 70 && move % 2 == 0)
                    break;
                else if (move >= 70 && move < 80 && move % 2 != 0)
                    break;
                else if (move >= 80 && move < 90 && move % 2 == 0)
                    break;
                else if (move >= 90 && move < 100 && move % 2 != 0)
                    break;

                // If the random guess does not follow the above rule, then update it.
                move = EasyBot();
            }

            // Return the move.
            return move;
        }

        // In this algorithm, the AI is given the ships that are sunken, and based on that, the AI computes the probabilities for a given location being a hit.
        // That location is hit, and if a cell is hit, it is searched around.
        public int HardBot()
        {

            // Check for hits.
            for (int cell = 0; cell < 100; cell++)
            {

                // If there's a hit on a cell.
                if (hits[cell] == true)
                {

                    // Variable storing the initial orientation of the ship cluster that's been hit. Initially, the orientation is null.
                    string orientation = null;

                    // Variables that say whether or not the ship cluster has ended on all 4 ends.
                    bool endEast = false;
                    bool endWest = false;
                    bool endNorth = false;
                    bool endSouth = false;

                    // Variable storing the size of the ship cluster. Initially 1, because the hit box is 1.
                    int size = 1;

                    // Set the index variable equal to 1 initially.
                    int index = 1;

                    // Iterate through the blocks around to the cell horizontally until they come to an end.
                    while (endEast == false && endWest == false)
                    {

                        // If the cell is not ended on both sides, continue checking.
                        if (((cell + (index - 1)) % 10 != 9 && endEast == false) || ((cell - (index - 1)) % 10 != 0 && endWest == false))
                        {

                            // If the cell is not ended on the East side, run this code.
                            if ((cell + index - 1) % 10 != 9 && endEast == false)
                            {

                                // If the next block is a miss, the cluster ends on the East side.
                                if (misses[cell + index] == true)
                                    endEast = true;

                                // If the cluster is a hit, the orientation is horizontal and increment the size of the cluster.
                                if (hits[cell + index] == true && endEast == false)
                                {
                                    orientation = "Horizontal";
                                    size++;
                                }
                            }

                            // If the cluster doesn't end on the West side.
                            if ((cell - (index - 1)) % 10 != 0 && endWest == false)
                            {

                                // If the next cell is a miss, the cell ends on the West side.
                                if (misses[cell - index] == true)
                                    endWest = true;

                                // If the cell is a hit, increment the size and set the orientation equal to horizontal.
                                if (hits[cell - index] == true && endWest == false)
                                {
                                    orientation = "Horizontal";
                                    size++;
                                }
                            }

                            // If the cell doesn't end on the East side.
                            if ((cell + (index - 1)) % 10 != 9 && cell + index < 100)
                            {
                                // If the cell has not been hit or missed yet, and if the orientation is horizontal, hit this cell.
                                if (hits[cell + index] == false && misses[cell + index] == false && orientation == "Horizontal" && endEast == false)
                                    return (cell + index);

                                // Otherwise, the cell ends on the East side.
                                else
                                    endEast = true;
                            }

                            // If the cell doesn't end on the West side.
                            if ((cell - (index - 1)) % 10 != 0 && cell - index >= 0)
                            {
                                // If the cell has not been hit or missed yet, and if the orientation is horizontal, hit this cell.
                                if (hits[cell - index] == false && misses[cell - index] == false && orientation == "Horizontal" && endWest == false)
                                    return (cell - index);

                                // Otherwise, the cell ends on the West side.
                                else
                                    endWest = true;
                            }
                        }

                        // If the cell is at the end of the row, it ends on the East side.
                        if ((cell + (index - 1)) % 10 == 9)
                            endEast = true;

                        // If the cell is at the start of the row, it ends on the West side.
                        if ((cell - (index - 1)) % 10 == 0)
                            endWest = true;

                        // Increment the index variable.
                        index++;
                    }

                    // If the orientation is null and not horizontal. 
                    if (orientation == null)
                    {
                        // Make the size of the cluster one.
                        size = 1;

                        // Set the index variable to 10, since vertical is 10 up or 10 down.
                        index = 10;

                        // Run this loop while the cell has not ended in the North or South direction.
                        while (endNorth == false && endSouth == false)
                        {

                            // If the cell has not ended in the North or South direction, run this code.
                            if ((cell + index < 100 && endSouth == false) || (cell - index >= 0 && endNorth == false))
                            {

                                // If the cluster has not ended in teh South direction.
                                if (cell + index < 100 && endSouth == false)
                                {

                                    // If the cell is a miss, it ends in the South direction.
                                    if (misses[cell + index] == true)
                                        endSouth = true;

                                    // If the cell is a hit, set the orientation to vertical and increment the size.
                                    if (hits[cell + index] == true)
                                    {
                                        orientation = "Vertical";
                                        size++;
                                    }
                                }

                                // If the cluster doesn't end in the North direction.
                                if (cell - index >= 0 && endNorth == false)
                                {

                                    // If the cell is a miss, it ends in the North direction.
                                    if (misses[cell - index] == true)
                                        endNorth = true;

                                    // If the cell is a hit, set the orientation to vertical and increment the size.
                                    if (hits[cell - index] == true)
                                    {
                                        orientation = "Vertical";
                                        size++;
                                    }
                                }

                                // If the cell is valid in the South direction.
                                if (cell + index < 100)
                                {

                                    // If the cell is not a miss or a hit, and the orientation is vertical and the cell doesn't end in the South direction, return this cell as a move.
                                    if (hits[cell + index] == false && misses[cell + index] == false && orientation == "Vertical" && endSouth == false)
                                        return (cell + index);

                                    // Otherwise, the cell ends in the South direction.
                                    else
                                        endSouth = true;
                                }

                                // If the cell is valid in the North direction.
                                if (cell - index >= 0)
                                {

                                    // If the cell isn't a hit and it isn't a miss and the orientation is vertical, return this cell as a move.
                                    if (hits[cell - index] == false && misses[cell - index] == false && orientation == "Vertical" && endNorth == false)
                                        return (cell - index);

                                    // Otherwise, teh cell ends in the North direction.
                                    else
                                        endNorth = true;
                                }
                            }

                            // If the cell is more than or equal to 100, it is invalid in the South direction.
                            if (cell + index >= 100)
                                endSouth = true;

                            // If the cell is less than 0, it is invalid in the South direction.
                            if (cell - index < 0)
                                endNorth = true;
                        }

                    }

                    // If the orientation is null (lone cell).
                    if (orientation == null)
                    {
                        
                        // If it is possible to hit the cell in the East direction, do it.
                        if (cell % 10 != 9 && misses[cell + 1] != true)
                            return cell + 1;

                        // If it is possible to hit the cell in the West direction, do it.
                        if (cell % 10 != 0 && misses[cell - 1] != true)
                            return cell - 1;

                        // If it is possible to hit the cell in the South direction, do it.
                        if (cell + 10 < 100 && misses[cell + 10] != true)
                            return cell + 10;

                        // If it is possible to hit the cell in the North direction, do it.
                        if (cell - 10 >= 0 && misses[cell - 10] != true)
                            return cell - 10;
                    }
                }
            }

            // Update the probabilities array depending on whether or not a ship exists.
            if (cruiser == false)
                GetProbabilities(5);
            if (battleship == false)
                GetProbabilities(4);
            if (cruiser == false)
                GetProbabilities(3);
            if (submarine == false)
                GetProbabilities(3);
            if (destroyer == false)
                GetProbabilities(2);

            // Create an array storing the cells with the highest probabilities.
            int[] highestCells = new int[0];

            // Create an integer which is the biggest probability cell.
            int largestCell = 0;

            // Iterate through all elements in the probabilities array.
            for (int index = 0; index < 100; index++)
            {

                // If this cell is a hit or a miss, continue.
                if (hits[index] == true || misses[index] == true)
                    continue;

                // If the probability of the cell is greater than the largest probability so far, set the highest probability to this cell alone.
                if (probabilities[index] > largestCell)
                {
                    largestCell = probabilities[index];
                    Array.Resize(ref highestCells, 1);
                    highestCells[0] = index;
                }

                // If the probability is equal to the largest probability so far, add the new probability to the array.
                else if (probabilities[index] == largestCell)
                {
                    Array.Resize(ref highestCells, highestCells.Length + 1);
                    highestCells[highestCells.Length - 1] = index;
                }
            }

            // Create a random generator.
            Random randomGenerator = new Random();

            // Return a random element from the highest probabilites array.
            int move = randomGenerator.Next(highestCells.Length);
            return highestCells[move];
        }

        // Function that calculates the probabilities array given the size of a specific ship.
        private void GetProbabilities(int size)
        {


            // Iterate through all the cells.
            for (int cell = 0; cell < 100; cell++)
            {

                // Create a boolean possible that stores whether or not it is possible for a ship to be placed horizontally in this direction.
                bool possible = true;

                // Iterate through all the cells over which the ship will be placed.
                for (int index = cell; index < cell + size; index++)
                {

                    // If a cell the ship is placed on is a miss or hangs over an edge, it is not possible for the ship to be placed ehre.
                    if (misses[index] == true || hits[index] || cell % 10 > 10 - size)
                    {
                        possible = false;
                        break;
                    }
                }

                // If it is possible for the ship to be placed.
                if (possible == true)
                {

                    // Iterate through all the cells the ship will be placed on and increment their probabilties.
                    for (int index = cell; index < cell + size; index++)
                    {
                        probabilities[index]++;
                    }
                }
            }


            // Iterate through all the cells, this time calculating vertical probability.
            for (int cell = 0; cell < 100; cell++)
            {

                // Boolean storing whether or not it is possible for a ship to be placed.
                bool possible = true;

                // Iterate through all the cells the ship will be placed on if placed vertically.
                for (int index = cell; index < cell + (size * 10); index += 10)
                {
                    // If a cell is a miss or hands over the edge, it is not possible for the ship to be placed.
                    if (misses[index] == true || hits[index] == true || cell >= 100 - (10 * (size-1)))
                    {
                        possible = false;
                        break;
                    }
                }

                // If it is possible for the ship to be placed.
                if (possible == true)
                {

                    // Iterate through all teh cells and increment their probabilities.
                    for (int index = cell; index < cell + (size * 10); index += 10)
                    {
                        probabilities[index]++;
                    }
                }
            }
        }
    }
}
