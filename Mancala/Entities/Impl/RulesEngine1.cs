using System.Linq;
using Mancala.Entities.Interface;

namespace Mancala.Entities.Impl
{
    public class RulesEngine1 : IRulesEngine
    {
        public string Name
        {
            get { return "Rules Engine 1"; }
        }

        public bool MoveIsLegal(IBoard board, ICup cup)
        {
            return ((cup.Seeds > 0) && (cup.Owner == board.Turn));
        }

        public bool GetToGoAgain(IBoard board, ICup landingCup)
        {
            // go again if you end up in your own goal OR if you end up in one of your
            // own cups such that you result in two seeds
            return landingCup.Owner == board.Turn && ((landingCup is GoalCup) || landingCup.Seeds == 2);
        }

        public void HandleRemainingSeeds(IBoard board)
        {
            ICup cup = board.Goal(board.Turn);
            Player otherPlayer = this.otherPlayer(board.Turn);
            cup.Seeds += board.SeedsLeft(otherPlayer);
            foreach (ICup c in board.Cups.Where(x => !(x is GoalCup)))
                c.Seeds = 0;
        }

        public void ApplyPostMoveRules(IBoard board, ICup cup)
        {
            ;
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