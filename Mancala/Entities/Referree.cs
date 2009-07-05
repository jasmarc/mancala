using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mancala.Entities
{
    public class Referree : IReferree
    {
        public Player? Winner()
        {
            Player? winner = null;
            if (SeedsLeft(Player.Player1) == 0
                || SeedsLeft(Player.Player2) == 0)
            {
                winner = SeedsGained(Player.Player1) > SeedsGained(Player.Player2)
                             ? Player.Player1
                             : Player.Player2;
            }
            return winner;
        }

        private int SeedsLeft(Player player)
        {
            return Board.Cups
                .Where(x => !(x is GoalCup)
                            && x.Owner == player)
                .Select(x => x.Seeds)
                .Sum();
        }

        private int SeedsGained(Player player)
        {
            return Board.Cups
                .Where(x => x is GoalCup
                            && x.Owner == player)
                .Select(x => x.Seeds).Single();
        }

        public bool MoveIsLegal(ICup cup)
        {
            return ((cup.Seeds > 0) && (cup.Owner == Board.Turn));
        }

        public void ReceivedMove(object sender, EventArgs e)
        {
            var cup = (ICup) ((Button) sender).Tag;
            if (MoveIsLegal(cup))
            {
                ICup nextCup = null;
                for (LinkedListNode<ICup> nextNode = Board.Cups.Find(cup).Next
                                                     ?? Board.Cups.First;
                     cup.Seeds > 0;
                     nextNode = nextNode.Next ?? Board.Cups.First)
                {
                    nextCup = nextNode.Value;
                    if (nextCup.Owner == Board.Turn || !(nextCup is GoalCup))
                    {
                        cup.Seeds--;
                        nextCup.Seeds++;
                    }
                }
                if(SeedsLeft(Board.Turn) == 0)
                {
                    ScoopUpAllRemaining();
                    Console.WriteLine(Board);
                    DeclareWinner();
                    Board.Reset();
                }
                else if (nextCup.Owner != Board.Turn || (!(nextCup is GoalCup) && nextCup.Seeds != 2))
                {
                    Board.Turn = Board.Turn == Player.Player1
                                     ? Player.Player2
                                     : Player.Player1;
                }
            }
            else
            {
                MessageBox.Show("Illegal Move");
            }
        }

        private void DeclareWinner()
        {
            Player winner = SeedsGained(Player.Player1) > SeedsGained(Player.Player2)
                             ? Player.Player1
                             : Player.Player2;
            MessageBox.Show(winner + " won!");
        }

        private void ScoopUpAllRemaining()
        {
            ICup cup = Goal(Board.Turn);
            Player otherPlayer = OtherPlayer(Board.Turn);
            cup.Seeds += SeedsLeft(otherPlayer);
            foreach (ICup c in Board.Cups.Where(x => !(x is GoalCup)))
                c.Seeds = 0;
        }

        private ICup Goal(Player player)
        {
            return Board.Cups.Where(x => x is GoalCup && x.Owner == player).Single();
        }

        private Player OtherPlayer(Player player)
        {
            return player == Player.Player1
                       ? Player.Player2
                       : Player.Player1;
        }

        public IBoard Board { get; set; }
    }
}