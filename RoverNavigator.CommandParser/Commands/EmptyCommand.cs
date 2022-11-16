using RoverNavigator.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverNavigator.CommandParser.Commands
{
    public class EmptyCommand : ICommand
    {
        public bool NewLocation => false;
        public EmptyCommand()
        {
        }
        public void Execute(IMachine machine)
        {

        }
    }
}
