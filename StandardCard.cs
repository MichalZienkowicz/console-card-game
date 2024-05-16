using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class StandardCard : ICard
    {
        public StandardCard(int attack, int health, int gold)
        {
            this.attack = attack;
            this.health = health;
            this.gold = gold;
            type = "Sta";
        }
        public override List<string> AvaliableAttackFields(Dictionary<string, Dictionary<string, dynamic>> ownBoard,
            Dictionary<string,Dictionary<string,dynamic>> enemyBoard)
        {
            string column = field[0].ToString();
            string row = field[1].ToString();
            List<string> avaliableFields = new List<string>();
            if (row != "1" && ownBoard[column]["1"] != null)
                avaliableFields = null;
            else
                for (int i = 1; i <= 3; i++)
                    if (enemyBoard[column][i.ToString()] != null)
                    {
                        avaliableFields.Add(column + i.ToString());
                        break;
                    }
            return avaliableFields;
        }
    }
}

