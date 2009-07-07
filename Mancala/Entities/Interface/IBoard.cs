using System.Collections.Generic;
using System.ComponentModel;
using Mancala.Entities.Impl;

namespace Mancala.Entities.Interface
{
    public interface IBoard : INotifyPropertyChanged
    {
        LinkedList<ICup> Cups { get; set; }
        Player Turn { get; set; }
        int SeedsLeft(Player player);
        int SeedsGained(Player player);
        ICup Goal(Player player);
        ICup CrossCup(ICup cup);
        void Reset();
    }
}