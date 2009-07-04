using System;

namespace Mancala.Entities
{
    public interface IReferree
    {
        IBoard Board { get; set; }
        Player? Winner();
        bool MoveIsLegal(ICup cup);
        void ReceivedMove(object sender, EventArgs e);
    }
}
