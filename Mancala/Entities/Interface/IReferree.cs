using Mancala.Entities.Interface;

namespace Mancala.Entities.Interface
{
    public interface IReferree
    {
        IBoard Board { get; set; }
        IView View { get; set; }
        void ReceiveMove(ICup cup);
        void AcknowledgeMessage(string message);
    }
}