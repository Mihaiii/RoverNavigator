using RoverNavigator.Enums;
using RoverNavigator.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverNavigator.CommandParser.Commands
{
    public class Rotate90DegreesRight : ICommand
    {
        public IMachine Machine { get; set; }
        public bool NewLocation => false;
        public Rotate90DegreesRight()
        {
        }
        public void Execute(IMachine machine)
        {
            switch (machine.Direction)
            {
                case Direction.North:
                    machine.Direction = Direction.East;
                    break;
                case Direction.East:
                    machine.Direction = Direction.South;
                    break;
                case Direction.South:
                    machine.Direction = Direction.West;
                    break;
                case Direction.West:
                    machine.Direction = Direction.North;
                    break;
            }

        }
    }
}
