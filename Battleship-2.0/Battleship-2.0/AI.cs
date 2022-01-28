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
        public int EasyShip()
        {

            // Create a random object.
            Random randNum = new Random();

            // Integer that will be the cell the AI's ship is on.
            int shipCell = randNum.Next(1, 101) - 1;

            // Keep generating this number until it's a cell that hasn't been played yet.
            while (ships[shipCell] == true)
            {
                shipCell = randNum.Next(1, 101) - 1;
            }

            return shipCell;
        }
    }
}
