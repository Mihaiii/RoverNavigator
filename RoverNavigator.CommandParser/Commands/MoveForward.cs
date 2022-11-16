using RoverNavigator.Enums;
using RoverNavigator.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverNavigator.CommandParser.Commands
{
    public class MoveForward : ICommand
    {
        public bool NewLocation => true;
        public int NrSteps { get; set; }
        public MoveForward(int nrSteps)
        {
            NrSteps = nrSteps;
        }
        public void Execute(IMachine machine)
        {
            switch (machine.Direction)
            {
                case Direction.North:
                    machine.Location.Y = machine.Location.Y + NrSteps;
                    break;
                case Direction.East:
                    machine.Location.X = machine.Location.X + NrSteps;
                    break;
                case Direction.South:
                    machine.Location.Y = machine.Location.Y - NrSteps;
                    break;
                case Direction.West:
                    machine.Location.X = machine.Location.X - NrSteps;
                    break;
            }
        }
    }
}
