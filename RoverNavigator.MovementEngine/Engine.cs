using RoverNavigator.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RoverNavigator.MovementEngine
{
    public class Engine : IValidator, IMovementEngine
    {
        public IPlateau Plateau { get; set; }
        public Dictionary<IMachine, List<ICommand>> Rules { get; set; } = new Dictionary<IMachine, List<ICommand>>();
        public string Error { get; set; }
        public IMachine CurrentMachine { get; set; }
        public Engine(IPlateau plateau)
        {
            Plateau = plateau;
        }

        public void AddMachine(IMachine machine, List<ICommand> commands)
        {
            Rules.Add(machine, commands);
            this.CurrentMachine = machine;
            if (!Validate())
            {
                return;
            }
        }

        public void RunInSequence()
        {
            foreach (KeyValuePair<IMachine, List<ICommand>> pair in Rules)
            {
                CurrentMachine = pair.Key;
                foreach (ICommand cmd in pair.Value)
                {
                    cmd.Execute(pair.Key);
                    if (cmd.NewLocation)
                    {
                        if (!Validate())
                        {
                            return;
                        }
                    }
                }
            }
        }
        public bool Validate()
        {
            if (!ValidateMachineOnPlateau())
            {
                Error = "Machine not on plateau.";
                return false;
            }

            if (!ValidateNoCrash())
            {
                Error = "Machine crush.";
                return false;
            }
            return true;
        }

        private bool ValidateNoCrash()
        {
            return !Rules.Keys.Any(z => z != CurrentMachine && z.Location.X == CurrentMachine.Location.X && z.Location.Y == CurrentMachine.Location.Y);
        }

        private bool ValidateMachineOnPlateau()
        {
            return CurrentMachine.Location.X >= 0
                && CurrentMachine.Location.X <= Plateau.LimitX
                && CurrentMachine.Location.Y >= 0
                && CurrentMachine.Location.Y <= Plateau.LimitY;
        }
    }
}
