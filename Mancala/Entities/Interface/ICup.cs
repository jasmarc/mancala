using System.ComponentModel;
using Mancala.Entities.Impl;

namespace Mancala.Entities.Interface
{
    public interface ICup : INotifyPropertyChanged
    {
        Player Owner { get; set; }
        int Seeds { get; set; }
        void Reset();
    }
}