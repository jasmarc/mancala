using System.Collections.Generic;
using System.Linq;

namespace Mancala.Entities
{
    public class Board : IBoard
    {
        public LinkedList<ICup> Cups { get; set; }
        public IList<Player> Players { get; set; }
        public Player Turn { get; set; }

        public Board()
        {
            Turn = Player.Player1;
            Cups = new LinkedList<ICup>(new List<ICup>
                                            {
                                                new Cup {IsGoal = false, Owner = Player.Player1,  Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Player.Player1,  Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Player.Player1,  Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Player.Player1,  Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Player.Player1,  Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Player.Player1,  Seeds = 4},
                                                new Cup {IsGoal = true, Owner  = Player.Player1, Seeds = 0},
                                                new Cup {IsGoal = false, Owner = Player.Player2,  Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Player.Player2,  Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Player.Player2,  Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Player.Player2,  Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Player.Player2,  Seeds = 4},
                                                new Cup {IsGoal = false, Owner = Player.Player2,  Seeds = 4},
                                                new Cup {IsGoal = true, Owner  = Player.Player2, Seeds = 0}
                                            });
        }

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