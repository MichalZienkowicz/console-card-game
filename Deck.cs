using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Deck
    {
        public string name;
        public List<Card> cardsInDeck;
        public List<Card> shuffledDeck;
        public Deck(List<Card> cardsInDeck, string name)
        {
            this.name = name;
            this.cardsInDeck = new List<Card>(cardsInDeck);
            Random rng = new Random();
            shuffledDeck = this.cardsInDeck.OrderBy(a => rng.Next()).ToList();
        }
    }
}
