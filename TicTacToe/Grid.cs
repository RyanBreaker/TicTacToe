using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public enum Pieces { None = ' ', X = 'X', O = 'O' }

    public class Grid
    {
        private Pieces[,] gridArray = new Pieces[3, 3];

        public bool playing { get; private set; } = true;
        public string result { get; private set; } = "Playing";

        // List of array representations of each possible row-combination in the grid
        private List<Pieces[]> allPossibleWins
        {
            get
            {
                var list = new List<Pieces[]>();
                int x, y;
                Pieces[] arr;

                // Horizontal rows
                for (x = 0; x < 3; x++)
                {
                    arr = new Pieces[3];
                    for (y = 0; y < 3; y++)
                        arr[y] = gridArray[x, y];
                    list.Add(arr);
                }

                // Vertical columns
                for (y = 0; y < 3; y++)
                {
                    arr = new Pieces[3];
                    for (x = 0; x < 3; x++)
                        arr[x] = gridArray[x, y];
                    list.Add(arr);
                }

                // Diagonals
                // Top-left to bottom-right
                arr = new Pieces[3];
                for (x = 0; x < 3; x++)
                    arr[x] = gridArray[x, x];
                list.Add(arr);

                // Top-right to bottom-left
                arr = new Pieces[3];
                for (x = 2, y = 0; x >= 0 && y < 3; x--, y++)
                {
                    arr[y] = gridArray[x, y];
                }
                list.Add(arr);

                return list;
            }
        }


        public Grid()
        {
            // Initialize gridArray
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    gridArray[x, y] = Pieces.None;
        }

        public bool setSpot(Spot spot, Pieces piece)
        {
            // Check if the spot is taken
            if (piece != Pieces.None && gridArray[spot.x, spot.y] == Pieces.None)
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
            // Is set to false in a loop to indicate possible stalemate
            bool full = true;
            int x, y;

            // Test for full grid
            for (x = 0; x < 3 && full == true; x++)
                for (y = 0; y < 3 && full == true; y++)
                    if (gridArray[x, y] == Pieces.None)
                        full = false;
             
            // Look for wins
            foreach (var arr in allPossibleWins)
            {
                if (arr[0] != Pieces.None && Spot.LineEquals(arr))
                {
                    setResult(arr[0]);
                    return;
                }
            }

            if (full)
            {
                setResult(Pieces.None);
            }
        }

        private void setResult(Pieces winner)
        {
            playing = false;
            if (winner == Pieces.None)
                result = "Stalemate";
            else
                result = (char)winner + " won";
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
}
