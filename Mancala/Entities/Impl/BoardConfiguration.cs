using System.Linq;
using Mancala.Entities.Impl;
using Mancala.Entities.Interface;

namespace Mancala.Entities.Impl
{
    public static class BoardConfiguration
    {
        public static IBoard Create(Player turn, int[] configuration)
        {
            IBoard retVal = new Board()
                                {
                                    Turn = turn
                                };
            for (int i = 0; i < configuration.Count(); i++)
            {
                retVal.Cups.ToArray()[i].Seeds = configuration[i];
            }
            return retVal;
        }

        public static void Set(IBoard dst, IBoard src)
        {
            Set(dst, src.Turn, GetConfiguration(src));
        }

        public static void Set(IBoard b, Player turn, int[] configuration)
        {
            b.Turn = (turn == Player.Player1 ? Player.Player1 : Player.Player2);
            for (int i = 0; i < configuration.Count(); i++)
            {
                b.Cups.ToArray()[i].Seeds = configuration[i];
            }
        }

        public static IBoard Copy(IBoard b)
        {
            IBoard retVal = new Board();
            Set(retVal, b);
            return retVal;
        }

        public static int[] GetConfiguration(IBoard b)
        {
            return b.Cups.Select(x => x.Seeds).ToArray();
        }
    }
}