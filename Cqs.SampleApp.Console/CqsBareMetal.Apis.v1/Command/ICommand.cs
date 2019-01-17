using System;

namespace CqsBareMetal.Apis.v1
{
    /// <summary>
    /// Marker interface to mark a command. Needed to switch on command types.
    /// </summary>
    public interface ICommand
    {
        Guid Id { get; }
    }
}