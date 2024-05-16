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
        public List<ICard> cardsInDeck;
        public List<ICard> shuffledDeck;
        public Deck(List<ICard> cardsInDeck, string name)
        {
            this.name = name;
            this.cardsInDeck = new List<ICard>(cardsInDeck);
            Random rng = new Random();
            shuffledDeck = this.cardsInDeck.OrderBy(a => rng.Next()).ToList();
        }
    }
}
