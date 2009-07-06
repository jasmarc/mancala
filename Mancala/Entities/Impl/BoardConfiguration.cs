using System.Linq;
using Mancala.Entities.Impl;
using Mancala.Entities.Interface;

namespace Mancala.Entities.Impl
{
    public static class BoardConfiguration
    {
        public static IBoard Create(int[] configuration)
        {
            IBoard retVal = new Board();
            for (int i = 0; i < configuration.Count(); i++)
            {
                retVal.Cups.ToArray()[i].Seeds = configuration[i];
            }
            return retVal;
        }

        public static void Set(IBoard b, int[] configuration)
        {
            for (int i = 0; i < configuration.Count(); i++)
            {
                b.Cups.ToArray()[i].Seeds = configuration[i];
            }
        }
    }
}