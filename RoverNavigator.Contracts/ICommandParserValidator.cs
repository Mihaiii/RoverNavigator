﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverNavigator.Contracts
{
    public interface ICommandParserValidator : ICommandParser, IValidator
    {
    }
}
