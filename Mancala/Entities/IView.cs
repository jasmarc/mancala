using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mancala.Entities
{
    public interface IView
    {
        // Properties
        IReferree referree { get; set; }
    }
}
