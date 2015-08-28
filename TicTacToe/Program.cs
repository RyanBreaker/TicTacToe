using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid();
            string input;

            const string TRYAGAIN = "Try again.";

            int x, y;
            
            // Game loop
            while (grid.playing)
            {
                // Show grid to players
                Console.WriteLine(grid.ToString());

                // Get player move and check the input; see regex for current format
                input = Console.ReadLine().ToUpper();
                if (!(input.Length == 3 && Regex.IsMatch(input, "^([0-2]{2})(X|O)$")))
                {
                    Console.WriteLine(TRYAGAIN);
                    continue;
                }

                // Plugin input
                x = int.Parse(input[0].ToString());
                y = int.Parse(input[1].ToString());

                // Set the spot, returns false if spot is already set or given wrong input
                if (!grid.setSpot(new Spot(x, y), (Pieces)input[2]))
                {
                    Console.WriteLine(TRYAGAIN);
                    continue;
                }
            }

            // Game is over when execution gets here
            Console.WriteLine("Game is over!");
            Console.WriteLine("Result: " + grid.result);
            Console.WriteLine(grid.ToString());

            Console.ReadLine();
        }
    }
}
