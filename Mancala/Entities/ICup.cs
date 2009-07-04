using System.ComponentModel;

namespace Mancala.Entities
{
    public interface ICup : INotifyPropertyChanged
    {
        Player Owner { get; set; }
        int Seeds { get; set; }
        void Reset();
    }
}
