using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class UserInterfaceDisplayer
    {
        private void DisplayCard(string field, Dictionary<string, Dictionary<string, dynamic>> boardSide)
        {
            string column = field[0].ToString();
            string row = field[1].ToString();
            if (boardSide[column][row] != null)
            {
                string a = $" a:{boardSide[column][row].attack.ToString()}" + new string(' ', 3 - boardSide[column][row].attack.ToString().Length);
                string h = $" h:{boardSide[column][row].health.ToString()}" + new string(' ', 3 - boardSide[column][row].health.ToString().Length);
                string g = $" g:{boardSide[column][row].gold.ToString()}" + new string(' ', 3 - boardSide[column][row].gold.ToString().Length);
                string t = $" T:{boardSide[column][row].type.ToString()}" + new string(' ', 12 - boardSide[column][row].type.ToString().Length);
                Console.Write(column + row + ":[");
                Console.Write(t);
                Console.Write(a);
                Console.Write(h);
                Console.Write(g);
                Console.Write("]  ");
            }
            else
            {
                Console.Write(column + row + ":[");
                Console.Write("".PadRight(33, ' '));
                Console.Write("]  ");
            }
        }
        public void DisplayBoards(Dictionary<string, Dictionary<string, dynamic>> boardSide1, Dictionary<string, Dictionary<string, dynamic>> boardSide2, Player player1, Player player2)
        {
            string playerInfo1 = $"ABCD3:[ Name: {player1.Name}  Health:{player1.health}  Gold:{player1.OwnedGold}";
            string playerInfo2 = $"ABCD3:[ Name: {player2.Name}  Health:{player2.health}  Gold:{player2.OwnedGold}";
            Console.Clear();
            Console.WriteLine(playerInfo2 + new string(' ', 160 - playerInfo2.Length) + "]");
            for (int i = 2; i > 0; i--)
            {
                Console.Write("   ");
                foreach(var kvp in boardSide2)
                {
                    string field = kvp.Key + i.ToString();
                    DisplayCard(field, boardSide2);
                }
                Console.WriteLine();    
            }
            Console.WriteLine();
            for (int i = 1; i < 3; i++)
            {
                Console.Write("   ");
                foreach (var kvp in boardSide1)
                {
                    string field = kvp.Key + i.ToString();
                    DisplayCard(field, boardSide1);
                }
                Console.WriteLine();
            }
            Console.WriteLine(playerInfo1 + "    <<< CURRENTLY PLAYING" + new string(' ', 135 - playerInfo1.Length) + "]");
            Console.WriteLine();
        }
        public void DisplayTradesman(List<CardUpgrade> avaliableUpgrades)
        {
            Console.WriteLine(new String('_', 160));
            Console.WriteLine("Tradesman current offer:");
            int i = 0;
            foreach(CardUpgrade u in avaliableUpgrades)
            {
                i++;
                if (u == null)
                    Console.WriteLine($"{i}.  -----");
                else
                    Console.WriteLine($"{i}.  Type: {u.type.Substring(u.type.Length - 3)}   Bonus a: {u.attack}   Bonus h: {u.health}   Cost: {u.cost}");
            }
            Console.WriteLine(new String('_', 160));
            Console.WriteLine();
        }
    }
}
