﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GameSegments
    {
        private List<Deck> decks = new List<Deck>();
        private Tradesman tradesman;
        private InputAsker asker;
        private GraphicInterfaceDisplayer gid;
        public GameSegments(List<Deck> givenDecks=null)
        {
            gid = new GraphicInterfaceDisplayer();
            asker = new InputAsker();
            tradesman = new Tradesman();
            if(givenDecks != null)
            foreach(Deck deck in givenDecks)
                decks.Add(deck);
        }
        public void CreateDecks()
        {
            List<ICard> cardsForDeck1 = new List<ICard>()
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
            List<ICard> cardsForDeck2 = new List<ICard>()
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
            Deck deck1 = new Deck(cardsForDeck1, "StandardDeck1");
            Deck deck2 = new Deck(cardsForDeck2, "StandardDeck2");
            decks.Add(deck1);
            decks.Add(deck2);
        }
        public Player InitiatePlayer()
        {
            string name = asker.AskForPlayerName();
            Deck deck = asker.AskForDeckPick(decks);
            decks.Remove(deck);
            Player player = new Player(name, deck);
            return player;
        }
        public void FirstTour(TableSide turnSide, TableSide oppositeSide)
        {
            bool firstTour = true;
            for(int i=0; i<2; i++)
            {
                gid.DisplayBoards(turnSide.boardSide, oppositeSide.boardSide, turnSide.player, oppositeSide.player);
                ICard card = asker.AskForCardToPlay(turnSide.player.Hand, firstTour);
                string field = asker.AskForPlacementField(turnSide.boardSide);
                turnSide.PlaceCard(card, field);
                gid.DisplayBoards(turnSide.boardSide, oppositeSide.boardSide, turnSide.player, oppositeSide.player);
            }
            bool repeat = true;
            int action;
            while (repeat)
            {
                gid.DisplayBoards(turnSide.boardSide, oppositeSide.boardSide, turnSide.player, oppositeSide.player);
                action = asker.AskForNextActionFirstTour();
                switch (action)
                {
                    case 0:

                        repeat = false;
                        break;

                    case 1:

                        ICard card = asker.AskForCardToPlay(turnSide.player.Hand);
                        if (card != null)
                        {
                            string pField = asker.AskForPlacementField(turnSide.boardSide);
                            if (pField != null)
                                turnSide.PlaceCard(card, pField);
                        }
                        break;
                }
                gid.DisplayBoards(turnSide.boardSide, oppositeSide.boardSide, turnSide.player, oppositeSide.player);
            }
        }



        public void ChooseNextAction(TableSide turnSide, TableSide oppositeSide)
        {
            turnSide.player.DrawCard();
            tradesman.UpdateAvaliableCardUpgrades();
            bool repeat = true;
            while (repeat)
            {
                gid.DisplayBoards(turnSide.boardSide, oppositeSide.boardSide, turnSide.player, oppositeSide.player);
                gid.TradesmanDisplay(tradesman.avaliableCardUpgrades);
                int action = asker.AskForNextAction();
                switch (action)
                {
                    case 0:

                        foreach (var kvp in turnSide.boardSide)
                        {
                            foreach (var kvp2 in kvp.Value)
                            {
                                if (kvp2.Key == "1" || kvp2.Key == "2")
                                    if (kvp2.Value != null)
                                    {
                                        List<string> aFields = kvp.Value[kvp2.Key].AvaliableAttackFields(turnSide.boardSide, oppositeSide.boardSide);
                                        if (aFields != null)
                                        {
                                            gid.DisplayBoards(turnSide.boardSide, oppositeSide.boardSide, turnSide.player, oppositeSide.player);
                                            gid.TradesmanDisplay(tradesman.avaliableCardUpgrades);
                                            string aField = asker.AskForAttackField(aFields, kvp.Key + kvp2.Key);
                                            if (aField != null)
                                            {
                                                kvp.Value[kvp2.Key].Attack(turnSide.boardSide, oppositeSide.boardSide, aField);
                                                oppositeSide.CheckDeadCards(turnSide.player);
                                                turnSide.CheckDeadCards(oppositeSide.player);
                                            }
                                        }
                                    }
                            }
                        }
                        repeat = false;
                        break;

                    case 1:

                        ICard card = asker.AskForCardToPlay(turnSide.player.Hand);
                        if (card != null)
                        {
                            string pField = asker.AskForPlacementField(turnSide.boardSide);
                            if (pField != null)
                                turnSide.PlaceCard(card, pField);
                        }
                        break;

                    case 2:

                        int n = asker.AskForUpgradeToBuy(tradesman.avaliableCardUpgrades, turnSide.player.OwnedGold, turnSide.boardSide);
                        if (n >= 0)
                        {
                            CardUpgrade upgrade = tradesman.SellUpgradeToPlayer(n);
                            turnSide.player.OwnedGold -= upgrade.cost;
                            string field = asker.AskForCardFieldToUpgrade(turnSide.boardSide);
                            turnSide.ReplaceCardWithUpgrade(field, upgrade);
                        }
                        break;
                }
            }
        }      
    }
}
