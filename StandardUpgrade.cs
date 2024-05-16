using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class StandardUpgrade : CardUpgrade
    {
        public StandardUpgrade(ICard card, int bonusHealth, int bonusAttack, int cost)
        {
            UpgradedCard = card;
            UpgradedCard.health += bonusHealth;
            UpgradedCard.attack += bonusAttack;
            UpgradedCard.type += "-Sta"; 
            this.cost = cost;
        }
        public override List<string> AvaliableAttackFields(Dictionary<string, Dictionary<string, dynamic>> ownBoard, 
            Dictionary<string, Dictionary<string, dynamic>> enemyBoard)
        {
            return UpgradedCard.AvaliableAttackFields(ownBoard, enemyBoard);
        }
    }
}
