using System;
using Microsoft.Extensions.Logging;
using Renamer;

namespace Console.Commands.Rename
{
    public class Command
    {
        private readonly ILogger<Command> _logger;
        private readonly IRenameFoldersAndFiles _renamer;

        public Command(ILogger<Command> logger, IRenameFoldersAndFiles renamer)
        {
            _logger = logger;
            _renamer = renamer;
            Name = DetermineCommandName(this);
        }

        private string DetermineCommandName(Command command)
        {
            var @namespace = command.GetType().Namespace;
            var period = @namespace.LastIndexOf('.');
            return @namespace.Substring(period + 1);
        }

        public ErrorLevel Invoke(Options options)
        {
            _logger.LogDebug("Invoked Rename.Command for {path}", options.Path);

            try
            {
                _renamer.Rename(options.Path);
                return ErrorLevel.Success;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,"Unexpected error occurred while invoking {Name}", Name);
                return ErrorLevel.UnhandledException;
            }

        }

        public string Name { get; private set; }
    }
}
