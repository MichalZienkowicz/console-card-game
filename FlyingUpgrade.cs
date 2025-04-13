using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class FlyingUpgrade : CardUpgrade
    {
        public FlyingUpgrade(Card card, int bonusHealth, int bonusAttack, int cost)
        {
            UpgradedCard = card;
            UpgradedCard.health += bonusHealth;
            UpgradedCard.attack += bonusAttack;
            UpgradedCard.type += "-Fly";
            this.cost = cost;
        }
        public override List<string> AvaliableAttackFields(Dictionary<string, Dictionary<string, dynamic>> ownBoard, 
            Dictionary<string, Dictionary<string, dynamic>> enemyBoard)
        {
            string column = field[0].ToString();
            string row = field[1].ToString();
            List<string> avaliableFields = new List<string>();
            for (int i = 1; i <= 3; i++)
                if (enemyBoard[column][i.ToString()] != null)
                {
                    avaliableFields.Add(column + i.ToString());
                    if (avaliableFields.Count == 2)
                        break;
                }
            return avaliableFields;
        }
    }
}
