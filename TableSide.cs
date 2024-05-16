using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TableSide
    {
        public Player player;
        public Dictionary<string, Dictionary<string, dynamic>> boardSide;
        public TableSide(Player player)
        {
            this.player = player;
            boardSide = new Dictionary<string, Dictionary<string, dynamic>>();
            Dictionary<string, dynamic> dictA = new Dictionary<string, dynamic>() { { "1", null }, { "2", null }, { "3", player } };
            Dictionary<string, dynamic> dictB = new Dictionary<string, dynamic>() { { "1", null }, { "2", null }, { "3", player } };
            Dictionary<string, dynamic> dictC = new Dictionary<string, dynamic>() { { "1", null }, { "2", null }, { "3", player } };
            Dictionary<string, dynamic> dictD = new Dictionary<string, dynamic>() { { "1", null }, { "2", null }, { "3", player } };

            boardSide.Add("A",dictA);
            boardSide.Add("B",dictB);
            boardSide.Add("C",dictC);
            boardSide.Add("D",dictD);
        }
        public void ReplaceCardWithUpgrade(string chosenField, CardUpgrade chosenUpgrade) 
        {
            string column = chosenField[0].ToString();
            string row = chosenField[1].ToString();
            //chosenUpgrade.UpgradedCard = boardSide[column][row];
            chosenUpgrade.ReplaceCardInUpgrade(boardSide[column][row]);
            //Console.WriteLine("Upgraded card?  " + chosenUpgrade.UpgradedCard.type + " a:" + chosenUpgrade.UpgradedCard.attack + " h:" + chosenUpgrade.UpgradedCard.health);
            //Console.WriteLine("Upgrade?        " + chosenUpgrade.type + " a:" + chosenUpgrade.attack + " h:" + chosenUpgrade.health);
            //Console.ReadLine();
            boardSide[column][row] = chosenUpgrade;
        }
        public void PlaceCard(ICard chosenCard, string chosenField)
        {
            string column = chosenField[0].ToString();
            string row = chosenField[1].ToString();
            boardSide[column][row] = chosenCard;
            chosenCard.field = chosenField;
            player.Hand.Remove(chosenCard); 

        }
        public void CheckDeadCards(Player enemyPlayer)
        {
            foreach(var kvp in boardSide)
            {
                foreach(var kvp2 in kvp.Value)
                {
                    if (kvp2.Value != null && (kvp2.Key == "1" || kvp2.Key == "2"))
                        if (kvp2.Value.health <= 0)
                        {
                            enemyPlayer.OwnedGold += kvp.Value[kvp2.Key].gold;
                            kvp.Value[kvp2.Key] = null;
                        }      
                }
            }
        }
        public bool DrawCondition()
        {
            bool value = false;
            int emptyFields=0;
            foreach (var kvp in boardSide)
            {
                foreach (var kvp2 in kvp.Value)
                {
                    if (kvp2.Value == null && (kvp2.Key == "1" || kvp2.Key == "2"))
                        emptyFields++;
                }
            }
            int playerDeck = player.Deck.shuffledDeck.Count();
            int playerHand = player.Hand.Count();
            if (emptyFields == 8 && playerDeck == 0 && playerHand == 0)
                value = true;
            return value;
        }
    }
}
