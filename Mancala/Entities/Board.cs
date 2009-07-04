using System;
using System.Collections.Generic;

namespace Mancala.Entities
{
    public class Board : IBoard
    {
        public Board()
        {
            Players = new List<Player>
                          {
                              Player.Player1,
                              Player.Player2
                          };
            Turn = Players[0];
            Cups = new LinkedList<ICup>(new List<ICup>
                                            {
                                                new Cup {IsGoal = false, Owner = Players[0], Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Players[0], Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Players[0], Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Players[0], Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Players[0], Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Players[0], Seeds = 4},
                                                new Cup {IsGoal = true, Owner = Players[0], Seeds = 0},
                                                new Cup {IsGoal = false, Owner = Players[1], Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Players[1], Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Players[1], Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Players[1], Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Players[1], Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Players[1], Seeds = 4},
                                                new Cup {IsGoal = true, Owner = Players[1], Seeds = 0}
                                            });
        }

        public bool GameIsOver()
        {
            throw new NotImplementedException();
        }

        public LinkedList<ICup> Cups { get; set; }
        public IList<Player> Players { get; set; }
        public Player Turn { get; set; }

        public override string ToString()
        {
            string retVal = "";
            foreach (ICup cup in Cups)
            {
                retVal = retVal + string.Format("{0}\r\n", cup);
            }
            return retVal;
        }
    }
}