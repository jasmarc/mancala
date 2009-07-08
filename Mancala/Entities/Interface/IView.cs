using Mancala.Entities.Impl;
using Mancala.Entities.Interface;

namespace Mancala.Entities.Interface
{
    public interface IView
    {
        IReferree referree { get; set; }
        bool UndoEnabled { get; set; }
        bool RedoEnabled { get; set; }
        void SetPlayer(Player player);
        void DisplayMessage(string message);
        void DisplayModalMessage(string message);
    }
}