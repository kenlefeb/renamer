using System;
using Microsoft.Extensions.Logging;

namespace Console.Commands.Rename
{
    public class Command
    {
        private readonly ILogger<Command> _logger;

        public Command(ILogger<Command> logger)
        {
            _logger = logger;
        }

        public ErrorLevel Invoke(Options options)
        {
            _logger.LogDebug("Invoked Rename.Command for {path}", options.Path);
            return ErrorLevel.Success;
        }
    }
}
