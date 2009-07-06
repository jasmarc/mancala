using System.Collections.Generic;
using System.Linq;
using Mancala.Entities.Impl;
using Mancala.Entities.Interface;

namespace Mancala.Entities.Impl
{
    public class Referree : IReferree
    {
        public IBoard Board { get; set; }
        public IView View { get; set; }

        public void ReceiveMove(ICup cup)
        {
            if (moveIsLegal(cup))
            {
                ICup landingCup = sowSeeds(cup);
                if (Board.SeedsLeft(Board.Turn) == 0)
                {
                    scoopUpAllRemaining();
                    declareWinner();
                }
                else
                {
                    if (getToGoAgain(landingCup))
                    {
                        View.DisplayMessage("You get to go again!");
                    }
                    else
                    {
                        Board.Turn = otherPlayer(Board.Turn);
                        View.SetPlayer(Board.Turn);
                    }
                }
            }
            else
            {
                View.DisplayMessage("Illegal Move");
            }
        }

        public void AcknowledgeMessage(string message)
        {
            Board.Reset();
        }

        private bool moveIsLegal(ICup cup)
        {
            return ((cup.Seeds > 0) && (cup.Owner == Board.Turn));
        }

        private bool getToGoAgain(ICup landingCup)
        {
            // go again if you end up in your own goal OR if you end up in one of your
            // own cups such that you result in two seeds
            return landingCup.Owner == Board.Turn && ((landingCup is GoalCup) || landingCup.Seeds == 2);
        }

        private ICup sowSeeds(ICup cup)
        {
            ICup landingCup = null;
            for (LinkedListNode<ICup> nextNode = Board.Cups.Find(cup).Next
                                                 ?? Board.Cups.First;
                 cup.Seeds > 0;
                 nextNode = nextNode.Next ?? Board.Cups.First)
            {
                landingCup = nextNode.Value;
                // skip your opponent's goal cup
                if (landingCup.Owner == Board.Turn || !(landingCup is GoalCup))
                {
                    cup.Seeds--;
                    landingCup.Seeds++;
                }
            }
            return landingCup;
        }

        private void declareWinner()
        {
            int p1 = Board.SeedsGained(Player.Player1);
            int p2 = Board.SeedsGained(Player.Player2);
            if (p1 == p2)
                View.DisplayModalMessage("tie!");
            else
            {
                Player winner = p1 > p2
                                    ? Player.Player1
                                    : Player.Player2;
                View.DisplayModalMessage(winner + " won!");
            }
        }

        private void scoopUpAllRemaining()
        {
            ICup cup = Board.Goal(Board.Turn);
            Player otherPlayer = this.otherPlayer(Board.Turn);
            cup.Seeds += Board.SeedsLeft(otherPlayer);
            foreach (ICup c in Board.Cups.Where(x => !(x is GoalCup)))
                c.Seeds = 0;
        }

        private Player otherPlayer(Player player)
        {
            return player == Player.Player1
                       ? Player.Player2
                       : Player.Player1;
        }
    }
}