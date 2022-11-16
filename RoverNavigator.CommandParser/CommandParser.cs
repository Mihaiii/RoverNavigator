using RoverNavigator.CommandParser.Commands;
using RoverNavigator.CommandParser.Factory;
using RoverNavigator.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RoverNavigator.CommandParser
{
    public class CmdParser : ICommandParserValidator
    {
        public string Commands { get; set; }
        public string Error { get; set; }
        public List<ICommand> ProcessedCommands { get; set; } = new List<ICommand>();
        public CmdParser(string commands)
        {
            Commands = commands;
        }

        public List<ICommand> Parse()
        {
            var factory = new CommandFactory();
            foreach (char command in Commands)
            {
                ICommand cmd = factory.GetCommand(command);
                ProcessedCommands.Add(cmd);
            }
            return ProcessedCommands;
        }

        public bool Validate()
        {
            if (ProcessedCommands.Any(z => z is EmptyCommand))
            {
                Error = $"Command unkown in {Commands}";
                return false;
            }
            return true;
        }
    }
}
