using System.Linq;
using Mancala.Entities.Interface;

namespace Mancala.Entities.Impl
{
    class RulesEngine2 : IRulesEngine
    {
        public string Name
        {
            get { return "Rules Engine 2"; }
        }

        public bool MoveIsLegal(IBoard board, ICup cup)
        {
            return ((cup.Seeds > 0) && (cup.Owner == board.Turn));
        }

        public bool GetToGoAgain(IBoard board, ICup landingCup)
        {
            return landingCup.Owner == board.Turn && landingCup is GoalCup;
        }

        public void HandleRemainingSeeds(IBoard board)
        {
            Player otherPlayer = this.otherPlayer(board.Turn);
            ICup cup = board.Goal(otherPlayer);
            cup.Seeds += board.SeedsLeft(otherPlayer);
            foreach (ICup c in board.Cups.Where(x => !(x is GoalCup)))
                c.Seeds = 0;
        }

        public void ApplyPostMoveRules(IBoard board, ICup cup)
        {
            ICup crossCup = board.CrossCup(cup);
            ICup goal = board.Goal(board.Turn);
            if (!(cup is GoalCup)
                && cup.Owner == board.Turn
                && cup.Seeds == 1
                && crossCup.Seeds > 0)
            {
                goal.Seeds += (cup.Seeds + crossCup.Seeds);
                cup.Seeds = 0;
                crossCup.Seeds = 0;
            }
        }

        public bool ShouldSowSeed(IBoard board, ICup cup)
        {
            return cup.Owner == board.Turn || !(cup is GoalCup);
        }

        private Player otherPlayer(Player player)
        {
            return player == Player.Player1
                       ? Player.Player2
                       : Player.Player1;
        }
    }
}