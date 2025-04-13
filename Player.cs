using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Player
        {
        public string Name { get; set; }
        public int health { get; set; }
        public int attack;
        //public int gold;
        //public string field;
        public string type; 
        public int OwnedGold { get; set; }
        public Deck Deck { get; set; }
        public List<Card> Hand = new List<Card>();
        public Player(string name, Deck deck, int gold = 5, int health = 20, int attack = 0)
        {
            type = "player";
            Name = name;
            Deck = deck;
            OwnedGold = gold;
            this.health = health;
            this.attack = attack;
            for (int i = 0; i < 4; i++)
            {
                Hand.Add(deck.shuffledDeck[0]);
                deck.shuffledDeck.RemoveAt(0);
            }
        }
        public void DrawCard() 
        { 
            if(Deck.shuffledDeck.Count > 0)
            {
                Hand.Add(Deck.shuffledDeck[0]);
                Deck.shuffledDeck.RemoveAt(0);
            }
        }
    }
}
