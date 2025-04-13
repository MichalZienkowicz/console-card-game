using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class CardUpgrade : Card
    {
        public Card UpgradedCard;
        public int cost { get; set; }
        public override int health
        {
            get { return UpgradedCard.health; }
            set { UpgradedCard.health = value; }
        }
        public override int attack
        {
            get { return UpgradedCard.attack; }
            set { UpgradedCard.attack = value; }
        }
        public override int gold
        {
            get { return UpgradedCard.gold; }
            set { UpgradedCard.gold = value; }
        }
        public override string type
        {
            get { return UpgradedCard.type; }
            set { UpgradedCard.type = value; }
        }
        public override string field
        {
            get { return UpgradedCard.field; }
            set { UpgradedCard.field = value; }
        }
        public void ReplaceCardInUpgrade(Card card)
        {
            int bonusHealth = health;
            int bonusAttack = attack;
            string extraType = type.Substring(type.Length - 3);
            UpgradedCard = card;
            UpgradedCard.health += bonusHealth;
            UpgradedCard.attack += bonusAttack;
            if(UpgradedCard.type.Contains(extraType) == false)
                UpgradedCard.type += "-" + extraType;
        }
    }
}
