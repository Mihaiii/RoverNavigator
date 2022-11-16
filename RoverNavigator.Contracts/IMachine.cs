using RoverNavigator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverNavigator.Contracts
{
    public interface IMachine
    {
        ILocation Location { get; set; }
        Direction Direction { get; set; }
    }
}
