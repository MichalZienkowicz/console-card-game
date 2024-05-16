using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class RunGame
    {
        public GameSegments gameS;
        public TableSide side1;
        public TableSide side2;
        private TextElementsDisplayer ted;
        public int turns;
        public RunGame(List<Deck> givenDecks=null)
        {
            ted = new TextElementsDisplayer();
            gameS = new GameSegments(givenDecks);
            turns = 0;
        }
        public void Run()
        {
            gameS.CreateDecks();
            Player player1 = gameS.InitiatePlayer();
            side1 = new TableSide(player1);
            Player player2 = gameS.InitiatePlayer();
            side2 = new TableSide(player2);
            gameS.FirstTour(side1, side2);
            gameS.FirstTour(side2, side1);
            turns++;

            while (true)
            {
                turns++;
                gameS.ChooseNextAction(side1, side2);
                if (side2.player.health <= 0)
                {
                    ted.DisplayWinscreen(side1.player.Name, turns);
                    break;
                }
                gameS.ChooseNextAction(side2, side1);
                if (side1.player.health <= 0)
                {
                    ted.DisplayWinscreen(side2.player.Name, turns);
                    break;
                }
                if (side1.DrawCondition() == true && side2.DrawCondition() == true) 
                {
                    ted.DisplayDrawScreen();
                    break;
                }
            }
        }        
    }
}
