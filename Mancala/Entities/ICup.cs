using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Mancala.Entities
{
    public interface ICup : INotifyPropertyChanged
    {
        // Properties
        bool IsGoal { get; set; }
        Player Owner { get; set; }
        int Seeds { get; set; }
    }
}
