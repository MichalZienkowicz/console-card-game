using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cardsForDeck1 = new List<Card>()
            {
            new StandardCard(1, 1, 1),
            new StandardCard(1, 2, 2),
            new StandardCard(2, 1, 2),
            new StandardCard(2, 2, 2),
            new StandardCard(2, 3, 3),
            new StandardCard(4, 2, 3),
            new FlyingCard(3, 2, 4),
            new FlyingCard(2, 2, 3),
            new ShooterCard(2, 2, 3),
            new StandardCard(1, 3, 3),
            };

            List<Card> cardsForDeck2 = new List<Card>()
            {
            new StandardCard(1, 2, 2),
            new StandardCard(2, 1, 2),
            new StandardCard(1, 2, 2),
            new StandardCard(1, 2, 1),
            new StandardCard(1, 4, 3),
            new StandardCard(3, 3, 3),
            new FlyingCard(2, 2, 3),
            new FlyingCard(3, 4, 5),
            new ShooterCard(2, 2, 3),
            new ShooterCard(1, 2, 3),
            };

            Deck deck1 = new Deck(cardsForDeck1, "deck1");
            Deck deck2 = new Deck(cardsForDeck2, "deck2");

            List<Deck> MyDecks = new List<Deck>() 
            {deck1, deck2};

            RunGame game = new RunGame();
            game.Run();
        }
    }
}
