using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TextElementsDisplayer
    {
        public void DisplayWinscreen(string winnerName, int turnsPlayed)
        {
            string winner = $"{winnerName} has won the game! ";
            string turns = $"Length of game: {turnsPlayed} turns";
            Console.WriteLine("\n\n\n");
            Console.WriteLine(new string('=', 160));
            Console.WriteLine(new string(' ', (160 - winner.Length) / 2) + winner + new string(' ', (160 - winner.Length) / 2));
            Console.WriteLine(new string(' ', (160 - turns.Length) / 2) + turns + new string(' ', (160 - turns.Length) / 2));
            Console.WriteLine(new string('=', 160));
        }
        public void DisplayDrawScreen()
        {
            string draw = "DRAW !!!";
            string info = "All cards have died!";
            Console.WriteLine("\n\n\n");
            Console.WriteLine(new string('=', 160));
            Console.WriteLine(new string(' ', (160 - draw.Length) / 2) + info + new string(' ', (160 - draw.Length) / 2));
            Console.WriteLine(new string(' ', (160 - draw.Length) / 2) + draw + new string(' ', (160 - draw.Length) / 2));
            Console.WriteLine(new string('=', 160));
        }
    }
}
