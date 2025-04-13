using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Tradesman
    {
        public List<CardUpgrade> avaliableCardUpgrades;
        public Tradesman()
        {
            avaliableCardUpgrades = new List<CardUpgrade>() { null, null, null };
        }
        public CardUpgrade CreateNewUpgrade()
        {
            Card emptyCard = new StandardCard(0, 0, 0);
            Random rand = new Random();
            CardUpgrade upgrade;
            int bonusHealth = rand.Next(rand.Next(3, 10));
            int bonusAttack = rand.Next(rand.Next(3, 10));
            int cost = bonusHealth + bonusAttack - rand.Next((bonusHealth + bonusAttack) / 4);
            if (rand.Next(10) < 4)
                upgrade = new StandardUpgrade(emptyCard, bonusHealth, bonusAttack, cost);
            else if (rand.Next(10) < 7)
            {
                cost += 2;
                upgrade = new FlyingUpgrade(emptyCard, bonusHealth, bonusAttack, cost);

            }
            else
            {
                cost += 3;
                upgrade = new ShooterUpgrade(emptyCard, bonusHealth, bonusAttack, cost);
            }
            return upgrade;
        }
        public void UpdateAvaliableCardUpgrades() 
        {
            CardUpgrade upgrade = CreateNewUpgrade();
            avaliableCardUpgrades.Insert(0, upgrade);
            if (avaliableCardUpgrades.Count > 3)
                avaliableCardUpgrades.RemoveAt(3);
        }
        public CardUpgrade SellUpgradeToPlayer(int index)
        {
            CardUpgrade chosenUpgrade = avaliableCardUpgrades[index];
            avaliableCardUpgrades[index] = null;
            return chosenUpgrade;
        }
    }
}
