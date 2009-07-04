using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mancala.Entities
{
    public class Referree : IReferree
    {
        public void ApplyMove(ICup cup)
        {
            for (LinkedListNode<ICup> nextNode = Board.Cups.Find(cup).Next ?? Board.Cups.First;
                 cup.Seeds > 0;
                 nextNode = nextNode.Next ?? Board.Cups.First)
            {
                cup.Seeds--;
                ICup local1 = nextNode.Value;
                local1.Seeds++;
            }
        }

        public void DeclareWinner()
        {
            throw new NotImplementedException();
        }

        public bool GameIsOver()
        {
            throw new NotImplementedException();
        }

        public bool MoveIsLegal(ICup cup)
        {
            return ((cup.Seeds > 0) && (cup.Owner == Board.Turn));
        }

        public void ReceivedMove(object sender, EventArgs e)
        {
            var cup = (ICup) ((Button) sender).Tag;
            ApplyMove(cup);
        }

        public IBoard Board { get; set; }
    }
}