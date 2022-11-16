using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverNavigator.Contracts
{
    public interface IPlateau
    {
        int LimitX { get; set; }
        int LimitY { get; set; }
    }
}
