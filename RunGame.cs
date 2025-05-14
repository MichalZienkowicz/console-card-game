using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class RunGame
    {
        public GameSegments gameSegments;
        public TableSide side1;
        public TableSide side2;
        private TextElementsDisplayer textDisplayer;
        public int turns;
        public RunGame(List<Deck> givenDecks=null)
        {
            textDisplayer = new TextElementsDisplayer();
            gameSegments = new GameSegments(givenDecks);
            turns = 0;
        }
        public void Run()
        {
            gameSegments.CreateDecks();
            Player player1 = gameSegments.InitiatePlayer();
            side1 = new TableSide(player1);
            Player player2 = gameSegments.InitiatePlayer();
            side2 = new TableSide(player2);
            gameSegments.FirstTurn(side1, side2);
            gameSegments.FirstTurn(side2, side1);
            turns++;

            while (true)
            {
                turns++;
                gameSegments.ChooseNextAction(side1, side2);
                if (side2.player.health <= 0)
                {
                    textDisplayer.DisplayWinscreen(side1.player.Name, turns);
                    break;
                }
                gameSegments.ChooseNextAction(side2, side1);
                if (side1.player.health <= 0)
                {
                    textDisplayer.DisplayWinscreen(side2.player.Name, turns);
                    break;
                }
                if (side1.CheckForDrawCondition() == true && side2.CheckForDrawCondition() == true) 
                {
                    textDisplayer.DisplayDrawScreen();
                    break;
                }
            }
        }        
    }
}
