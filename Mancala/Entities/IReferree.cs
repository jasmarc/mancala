using System;
using System.Linq;
using System.Text;

namespace Mancala.Entities
{
    public interface IReferree
    {
        // Methods
        void ApplyMove(ICup cup);
        void DeclareWinner();
        bool GameIsOver();
        bool MoveIsLegal(ICup cup);
        void ReceivedMove(object sender, EventArgs e);

        // Properties
        IBoard Board { get; set; }
    }
}
