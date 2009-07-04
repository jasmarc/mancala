using System.Collections.Generic;
using System.ComponentModel;

namespace Mancala.Entities
{
    public interface IBoard
    {
        LinkedList<ICup> Cups { get; set; }
        Player Turn { get; set; }
        void Reset();
        event PropertyChangedEventHandler PropertyChanged;
    }
}
