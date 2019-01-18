using System;

namespace ProjX.SimulationEngine.Api.Contracts.v1
{
    /// <summary>
    /// Marker interface to mark a command. Needed to switch on command types.
    /// </summary>
    public interface ICommand
    {
        Guid Id { get; }
    }
}