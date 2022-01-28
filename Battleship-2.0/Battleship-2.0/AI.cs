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

        public int EasyBot()
        {
            // Create a random object.
            Random randNum = new Random();

            // Integer that will be the move played by the computer.
            int move;

            // Generate a random number until it's a number that hasn't been played yet.
            while (true)
            {
                move = randNum.Next(101);
                for (int index = 0; index < 100; index++)
                {
                    if (misses[index] == true || hits[index] == true)
                    {
                        continue;
                    }
                }
                return move-1;
            }
        }
    }
}
