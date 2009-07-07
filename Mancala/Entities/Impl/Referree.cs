using System.Collections.Generic;
using Mancala.Entities.Impl;
using Mancala.Entities.Interface;

namespace Mancala.Entities.Impl
{
    public class Referree : IReferree
    {
        public IBoard Board { get; set; }
        public IView View { get; set; }
        public IRulesEngine RulesEngine { get; set; }

        public void ReceiveMove(ICup cup)
        {
            if (moveIsLegal(cup))
            {
                ICup landingCup = sowSeeds(cup);
                applyPostMoveRules(landingCup);
                if (Board.SeedsLeft(Board.Turn) == 0)
                {
                    handleRemainingSeeds();
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

        public void SetRulesEngine(IRulesEngine engine)
        {
            RulesEngine = engine;
            Board.Reset();
        }

        public void ResetGame()
        {
            Board.Reset();
        }

        private bool moveIsLegal(ICup cup)
        {
            return RulesEngine.MoveIsLegal(Board, cup);
        }

        private bool getToGoAgain(ICup landingCup)
        {
            return RulesEngine.GetToGoAgain(Board, landingCup);
        }

        private bool shouldSowSeed(ICup cup)
        {
            return RulesEngine.ShouldSowSeed(Board, cup);
        }

        private void applyPostMoveRules(ICup cup)
        {
            RulesEngine.ApplyPostMoveRules(Board, cup);
        }

        private void handleRemainingSeeds()
        {
            RulesEngine.HandleRemainingSeeds(Board);
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
                if (shouldSowSeed(landingCup))
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

        private Player otherPlayer(Player player)
        {
            return player == Player.Player1
                       ? Player.Player2
                       : Player.Player1;
        }
    }
}