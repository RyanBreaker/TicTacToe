using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Spot
    {
        public int x { get; }
        public int y { get; }

        static public bool LineEquals(Pieces[] line)
        {
            return line[0] == line[1] && line[1] == line[2];
        }

        public Spot(int x = 0, int y = 0)
        {
            if (x < 0 || x >= 3 || y < 0 || y >= 3)
                throw new Exception("Oops.");

            this.x = x;
            this.y = y;
        }
    }
}
