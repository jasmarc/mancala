using System.Collections.Generic;

namespace Mancala.Entities
{
    public interface IBoard
    {
        // Methods
        bool GameIsOver();

        // Properties
        LinkedList<ICup> Cups { get; set; }
        IList<Player> Players { get; set; }
        Player Turn { get; set; }
    }
}
