using RoverNavigator.Contracts;
using RoverNavigator.Entities;
using RoverNavigator.Enums;
using System;
using RoverNavigator.CommandParser;
using RoverNavigator.MovementEngine;

namespace RoverNavigator.Main
{
    public class RoverNavigator
    {
        static void Main(string[] args)
        {
            IPlateau plateau = new Plateau(4, 4);
            IMachine rover1 = new Rover()
            {
                Location = new Location(1, 2),
                Direction = Direction.North
            };

            IMachine rover2 = new Rover()
            {
                Location = new Location(2, 3),
                Direction = Direction.East
            };

            ICommandParserValidator cmdParser = new CmdParser("LMLMLMLMM");
            var processedCmd1 = cmdParser.Parse();
            if (!cmdParser.Validate())
            {
                Console.WriteLine(cmdParser.Error);
                return;
            }

            ICommandParserValidator cmdParser2 = new CmdParser("MMRMMRMRRM");
            var processedCmd2 = cmdParser2.Parse();
            if (!cmdParser.Validate())
            {
                Console.WriteLine(cmdParser2.Error);
                return;
            }

            IMovementEngine engine = new Engine(plateau);
            engine.AddMachine(rover1, processedCmd1);
            engine.AddMachine(rover2, processedCmd2);
            engine.RunInSequence();

            Console.WriteLine("rover1.Location.X: {0}", rover1.Location.X);
            Console.WriteLine("rover1.Location.Y: {0}", rover1.Location.Y);
            Console.WriteLine("rover1.Direction: {0}", rover1.Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("rover2.Location.X: {0}", rover2.Location.X);
            Console.WriteLine("rover2.Location.Y: {0}", rover2.Location.Y);
            Console.WriteLine("rover2.Direction: {0}", rover2.Direction.ToString());

            Console.ReadLine();
        }
    }
}
