using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverNavigator.Contracts
{
    public interface IValidator
    {
        bool Validate();
        string Error { get; set; }
    }
}
