using RoverNavigator.Enums;
using RoverNavigator.Contracts;
using System.Collections.Generic;

namespace RoverNavigator.Entities
{
    public class Location : ILocation
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
