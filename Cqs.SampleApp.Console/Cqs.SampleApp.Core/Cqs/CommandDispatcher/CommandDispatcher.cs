using System;

namespace CqsBareMetal.Server
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private ApplicationDbContext _Context { get; }

        public CommandDispatcher(ApplicationDbContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IResult Dispatch(ICommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            switch (command)
            {
                case SaveBookCommand cmd:
                    SaveBookCommandHandler handler = new SaveBookCommandHandler(_Context);
                    return handler.Handle(cmd);
                default:  // if the value is not recognized
                    throw new ArgumentException(nameof(command));
            }
        }
    }
}