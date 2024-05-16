using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ShooterUpgrade : CardUpgrade
    {
        public ShooterUpgrade(ICard card, int bonusHealth, int bonusAttack, int cost)
        {
            UpgradedCard = card;
            UpgradedCard.health += bonusHealth;
            UpgradedCard.attack += bonusAttack;
            UpgradedCard.type += "-Sho";
            this.cost = cost;
        }
        public override List<string> AvaliableAttackFields(Dictionary<string, Dictionary<string, dynamic>> ownBoard,
            Dictionary<string, Dictionary<string, dynamic>> enemyBoard)
        {
            string column = field[0].ToString();
            List<string> avaliableFields = new List<string>();
            for (int i = 1; i <= 3; i++)
                if (enemyBoard[column][i.ToString()] != null)
                {
                    avaliableFields.Add(column + i.ToString());
                }
            return avaliableFields;
        }
        public override void Attack(Dictionary<string, Dictionary<string, dynamic>> ownBoard,
            Dictionary<string, Dictionary<string, dynamic>> enemyBoard, string chosenField)
        {
            string column = chosenField[0].ToString();
            string row = chosenField[1].ToString();
            if (int.Parse(row) + int.Parse(field[1].ToString()) == 2 || enemyBoard[column][row].type.Contains("Sho"))
            // base.Attack(ownBoard, enemyBoard, chosenField);
            {
                enemyBoard[column][row].health -= attack;
                health -= enemyBoard[column][row].attack;
            }
            else
            {
                enemyBoard[column][row].health -= attack;
            }
        }
    }
}

