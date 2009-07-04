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
            if (Board.Cups
                    .Where(x => !x.IsGoal
                                && x.Owner == Player.Player1)
                    .Select(x => x.Seeds)
                    .Sum() == 0)
            {
                winner = Player.Player1;
            }
            else if (Board.Cups
                         .Where(x => !x.IsGoal
                                     && x.Owner == Player.Player2)
                         .Select(x => x.Seeds)
                         .Sum() == 0)
            {
                winner = Player.Player2;
            }
            return winner;
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
                for (LinkedListNode<ICup> nextNode = Board.Cups.Find(cup).Next ?? Board.Cups.First;
                     cup.Seeds > 0;
                     nextNode = nextNode.Next ?? Board.Cups.First)
                {
                    cup.Seeds--;
                    ICup local1 = nextNode.Value;
                    local1.Seeds++;
                }
                Board.Turn = Board.Turn == Player.Player1
                                 ? Player.Player2
                                 : Player.Player1;
            }
            else
            {
                MessageBox.Show("Illegal Move");
            }
        }

        public IBoard Board { get; set; }
    }
}