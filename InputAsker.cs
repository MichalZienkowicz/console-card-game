using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class InputAsker
    {
        public Card AskForCardToPlay(List<Card> hand, bool firstTurn = false)
        {
            Card card;
            int downRange = 1;
            int index;
            if(hand.Count() > 0)
            {
                Console.WriteLine("Choose the card from your hand to play!");
                if(firstTurn == false)
                {
                    Console.WriteLine("0.  Don't play any card.");
                    downRange = 0;
                }
                int i = 0;
                foreach (Card handCard in hand)
                {
                    i++;
                    Console.WriteLine($"{i}.  type: [{handCard.type}]  attack: [{handCard.attack}]  health: [{handCard.health}]  gold: [{handCard.gold}]");
                }

                Console.Write("Enter number of chosen card: ");
                index = TryGetIntInRange(downRange, hand.Count) - 1;
                if (index == -1)
                    card = null;
                else
                    card = hand[index];
            }
            else
            {
                Console.WriteLine("No cards avaliable to play!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                card = null;
            }
            return card;
        }
        public string AskForPlacementField(Dictionary<string, Dictionary<string, dynamic>> boardSide) 
        {
            string field;
            Console.Write("Enter field you want to place the card on: ");
            while (true)
            {
                try
                {
                    field = Console.ReadLine();
                    string column = field[0].ToString();
                    string row = field[1].ToString();
                    if (field.Length > 2 || boardSide[column][row]!=null)
                        throw new Exception();
                }
                catch (Exception )
                {
                    Console.Write("Invalid input, try again: ");
                    continue;
                }
                break;
            }
            return field;
        }
        public string AskForAttackField(List<string> avaliableAttackFields, string attackerField)
        {
            string value;
            int index;
            Console.WriteLine($"Choose the target field for your card on field {attackerField}");
            Console.WriteLine("0.  Dont attack with this card.");
            int i = 0;
            foreach (string field in avaliableAttackFields)
            {
                i++;
                Console.WriteLine($"{i}.  {field}");
            }
            Console.Write("Enter number of field with chosen target: ");
            index = TryGetIntInRange(0, avaliableAttackFields.Count) - 1;
            if (index == -1)
                value = null;
            else
                value = avaliableAttackFields[index];
            return value;
        }
        public string AskForPlayerName()
        {
            Console.WriteLine("Enter name of the player: ");
            string name = Console.ReadLine();
            return name;
        }
        public string AskForCardFieldToUpgrade(Dictionary<string, Dictionary<string, dynamic>> boardSide)
        {
            string field;
            Console.WriteLine("Choose field with card you want use the upgrade on!");
            while (true)
            {
                try
                {
                    Console.Write("Enter field here: ");
                    field = Console.ReadLine();
                    string column = field[0].ToString();
                    string row = field[1].ToString();
                    if (field.Length > 2 || boardSide[column][row] == null)
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.Write("Invalid input, try again: ");
                    continue;
                }
                break;
            }
            return field;
        }
        public int AskForIndexOfUpgradeToBuy(List<CardUpgrade> avaliableUpgrades, int playerGold, Dictionary<string, Dictionary<string, dynamic>> boardSide)// to do: make sure no bying with negative gold takes place
        {
            {
                int index;
                bool cardOnTable = false;
                foreach (var kvp in boardSide)
                {
                    if(cardOnTable == false)
                        foreach (var kvp2 in kvp.Value)
                        if (kvp2.Key == "1" || kvp2.Key == "2")
                            if (kvp2.Value != null)
                                {
                                    cardOnTable = true;
                                    break;
                                }
                }
                if (cardOnTable == false)
                {
                    Console.WriteLine("You can't buy upgrade without having cards on board!");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    index = -1;
                }
                else
                {
                    Console.WriteLine("Choose upgrade to buy!");
                    Console.WriteLine("0.  Don't buy any upgrade.");
                    Console.Write("Enter number of chosen upgrade: ");
                    index = TryGetIntInRange(0, avaliableUpgrades.Count) - 1;
                    if (avaliableUpgrades[index] == null)
                    {
                        Console.WriteLine("No upgrade of that number avaliable!");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        index = -1;
                    }
                    if (index != -1 && avaliableUpgrades[index].cost > playerGold)
                    {
                        Console.WriteLine("This upgrade is too expensive!");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        index = -1;
                    }
                }
                return index;
            }
        }
        public Deck AskForDeckPick(List<Deck> decks)
        {
            int index;
            Console.WriteLine("Choose players deck!");
            int i = 0;
            foreach (Deck d in decks)
            {
                i++;
                Console.WriteLine($"{i}.  {d.name}");
            }
            Console.Write("Enter number of chosen deck: ");
            index = TryGetIntInRange(1, decks.Count) - 1;
            return decks[index];
        }
        public int AskForNextAction()
        {
            int number;
            Console.WriteLine("Choose your next action!");
            Console.WriteLine("0. Attack and finish your turn.");
            Console.WriteLine("1. Play card.");
            Console.WriteLine("2. Buy card upgrade.");
            Console.Write("Enter number: ");
            number = TryGetIntInRange(0,2);
            return number;
        }
        public int AskForNextActionFirstTurn()
        {
            int number;
            Console.WriteLine("Choose your next action!");
            Console.WriteLine("0. Finish your turn.");
            Console.WriteLine("1. Play another card.");
            Console.Write("Enter number: ");
            number = TryGetIntInRange(0,1);
            return number;
        }
        private int TryGetIntInRange(int downRange, int range)
        {
            int n;
            while (true)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                    if (n < downRange || n > range)
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.Write("Invalid input, try again: ");
                    continue;
                }
                break;
            }
            return n;
        }  
    }
}
