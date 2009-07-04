using System.Collections.Generic;

namespace Mancala.Entities
{
    public interface IBoard
    {
        LinkedList<ICup> Cups { get; set; }
        Player Turn { get; set; }
    }
}
