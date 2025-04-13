using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Card 
    {
        public virtual int health { get; set; }
        public virtual int attack { get; set; }
        public virtual int gold { get; set; }
        public virtual string field { get; set; }
        public virtual string type { get; set; }

        public virtual List<string> AvaliableAttackFields(Dictionary<string, Dictionary<string, dynamic>> ownBoard, 
            Dictionary<string, Dictionary<string, dynamic>> enemyBoard)
        {
            return new List<string>();
        }
        public virtual void Attack(Dictionary<string, Dictionary<string, dynamic>> ownBoard,
            Dictionary<string, Dictionary<string, dynamic>> enemyBoard, string chosenField)
        {
            string column = chosenField[0].ToString();
            string row = chosenField[1].ToString();
            enemyBoard[column][row].health -= attack;
            health -= enemyBoard[column][row].attack;
        }
    }
}
