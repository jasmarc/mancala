using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Mancala.Entities.Interface;

namespace Mancala.Entities.Impl
{
    public class Board : IBoard
    {
        public LinkedList<ICup> Cups { get; set; }
        private Player turn;
        public Player Turn
        {
            get { return turn; }
            set
            {
                turn = value;
                NotifyPropertyChanged("Turn");
            }
        }

        public Board()
        {
            Turn = Player.Player1;
            Cups = new LinkedList<ICup>(new List<ICup>
                                            {
                                                new Cup(Player.Player1),
                                                new Cup(Player.Player1),
                                                new Cup(Player.Player1),
                                                new Cup(Player.Player1),
                                                new Cup(Player.Player1),
                                                new Cup(Player.Player1),
                                                new GoalCup(Player.Player1),
                                                new Cup(Player.Player2),
                                                new Cup(Player.Player2),
                                                new Cup(Player.Player2),
                                                new Cup(Player.Player2),
                                                new Cup(Player.Player2),
                                                new Cup(Player.Player2),
                                                new GoalCup(Player.Player2)
                                            });
        }

        public int SeedsLeft(Player player)
        {
            return Cups
                .Where(x => !(x is GoalCup)
                            && x.Owner == player)
                .Select(x => x.Seeds)
                .Sum();
        }

        public int SeedsGained(Player player)
        {
            return Cups
                .Where(x => x is GoalCup
                            && x.Owner == player)
                .Select(x => x.Seeds).Single();
        }

        public ICup Goal(Player player)
        {
            return Cups.Where(x => x is GoalCup && x.Owner == player).Single();
        }

        public ICup CrossCup(ICup cup)
        {
            if(!Cups.Contains(cup))
                throw new ApplicationException("Cup not in collection.");

            LinkedListNode<ICup> cupNode = Cups.First;
            int i = 0;
            while (cupNode.Value != cup)
            {
                cupNode = cupNode.Next;
                i++;
            }
            return Cups.ToArray()[Math.Abs(i - 12)];
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

        public void Reset()
        {
            Turn = Player.Player1;
            foreach (ICup cup in Cups)
                cup.Reset();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}