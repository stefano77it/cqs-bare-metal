using System;

namespace CqsBareMetal.Apis.v1
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