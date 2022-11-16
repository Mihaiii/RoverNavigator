using RoverNavigator.Enums;
using RoverNavigator.Contracts;
using System.Collections.Generic;

namespace RoverNavigator.Entities
{
    public class Plateau : IPlateau
    {
        public int LimitX { get; set; }
        public int LimitY { get; set; }

        public Plateau(int x, int y)
        {
            LimitX = x;
            LimitY = y;
        }
    }
}
