using RoverNavigator.Enums;
using RoverNavigator.Contracts;
using System.Collections.Generic;

namespace RoverNavigator.Entities
{
    public class Rover : IMachine
    {
        public ILocation Location { get; set; }
        public Direction Direction { get; set; }
    }
}
