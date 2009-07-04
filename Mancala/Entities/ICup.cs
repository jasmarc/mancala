﻿using System.ComponentModel;

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
