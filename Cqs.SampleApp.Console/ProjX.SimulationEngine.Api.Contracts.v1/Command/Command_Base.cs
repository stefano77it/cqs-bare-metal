using System;

namespace ProjX.SimulationEngine.Api.Contracts.v1
{
    public abstract class Command_Base : ICommand
    {
        public Guid Id { get; }  // attributed automatically at Init

        protected Command_Base()  // can't be called directly, only by derived classes
        {
            Id = Guid.NewGuid();
        }
    }
}