using System.Collections.Generic;

namespace Mancala.Entities
{
    public class Board : IBoard
    {
        public bool GameIsOver()
        {
            Players = new List<Player>()
                          {
                              Player.Player1,
                              Player.Player2
                          };
            Turn = Players[0];
            Cups = new LinkedList<ICup>(new List<ICup>()
                                            {
                                                new Cup() {}
                                            });
        }

        public LinkedList<ICup> Cups { get; set; }
        public IList<Player> Players { get; set; }
        public Player Turn { get; set; }
    }
}