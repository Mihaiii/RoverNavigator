using RoverNavigator.CommandParser.Commands;
using RoverNavigator.Contracts;

namespace RoverNavigator.CommandParser.Factory
{
    public class CommandFactory : ICommandFactory
    {
        public CommandFactory()
        {
        }
        public ICommand GetCommand(char command)
        {
            switch (command)
            {
                case 'L':
                    return new Rotate90DegreesLeft();
                case 'R':
                    return new Rotate90DegreesRight();
                case 'M':
                    return new MoveForward(1);
                default:
                    return new EmptyCommand();
            }
        }
    }
}
