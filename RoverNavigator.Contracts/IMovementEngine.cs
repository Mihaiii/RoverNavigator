using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverNavigator.Contracts
{
    public interface IMovementEngine
    {
        IPlateau Plateau { get; set; }
        Dictionary<IMachine, List<ICommand>> Rules { get; set; }
        IMachine CurrentMachine { get; set; }
        void AddMachine(IMachine machine, List<ICommand> commands);
        void RunInSequence();

    }
}
