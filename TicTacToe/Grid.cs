using System;

namespace TicTacToe
{
    public enum Pieces { None = ' ', X = 'X', O = 'O' }

    public class Grid
    {
        private Pieces[,] gridArray = new Pieces[3, 3];

        public bool   playing { get; private set; } = true;
        public string result  { get; private set; } = "Playing";

        public Grid()
        {
            // Initialize gridArray
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    gridArray[x, y] = Pieces.None;
                }
            }
        }

        public bool setSpot(Spot spot, Pieces piece)
        {
            // Check if the spot is taken
            if(piece != Pieces.None && gridArray[spot.x, spot.y] == Pieces.None)
            {
                gridArray[spot.x, spot.y] = piece;
                testForEndGame();
                return true;
            }

            // Return false if spot is taken
            return false;
        }

        private void testForEndGame()
        {
            // Test for full grid
            bool full = true;
            for(int x = 0; x < 3 && full == true; x++)
            {
                for(int y = 0; y < 3 && full == true; y++)
                {
                    if (gridArray[x, y] == Pieces.None)
                        full = false;
                }
            }

            // TODO: Test for win.

            if (full)
            {
                result = "Stalemate";
                playing = false;
                return;
            }
        }

        public override string ToString()
        {
            const string LINE = "-----------\n";
            string s = "";

            for (int i = 0; i < 3; i++)
            {
                s += $" {(char)gridArray[i, 0]} | {(char)gridArray[i, 1]} | {(char)gridArray[i, 2]} \n";
                if (i != 2)
                    s += LINE;
            }

            return s;
        }
    }

    public class Spot
    {
        public int x { get; }
        public int y { get; }

        public Spot(int x = 0, int y = 0)
        {
            if (x < 0 || x >= 3 || y < 0 || y >= 3)
                throw new Exception("Oops.");

            this.x = x;
            this.y = y;
        }
    }
}
