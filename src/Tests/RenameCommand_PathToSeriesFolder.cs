using System;
using System.Linq;
using Console;
using Console.Commands.Rename;
using Divergic.Logging.Xunit;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Renamer;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class RenameCommand_PathToSeriesFolder
    {
        private readonly ITestOutputHelper _output;
        private readonly ICacheLogger<Command> _logger;
        private readonly IRenameFoldersAndFiles _renamer;
        private readonly Console.Commands.Rename.Options _options;
        private readonly Console.Commands.Rename.Command _command;

        public RenameCommand_PathToSeriesFolder(ITestOutputHelper output)
        {
            // arrange
            _output = output;
            _logger = _output.BuildLoggerFor<Console.Commands.Rename.Command>();
            _options = new Console.Commands.Rename.Options
            {
                Path = "~/downloads/My.Show.S01.E01.Episode.Title.1080p.BDRIP.SCENE-REPACK/",
            };
            _renamer = A.Fake<IRenameFoldersAndFiles>();
            _command = new Console.Commands.Rename.Command(_logger, _renamer);
        }

        [Fact]
        public void LogsToConsole()
        {
            // act
            var actual = _command.Invoke(_options);

            // assert
            actual.Should().Be(ErrorLevel.Success);
            _logger.Entries.Any(e => e.Message == $"Invoked Rename.Command for {_options.Path}").Should().BeTrue();
        }

        [Fact]
        public void InvokesRenamer()
        {
            // act
            var actual = _command.Invoke(_options);

            // assert
            A.CallTo(() => _renamer.Rename(A<string>.Ignored)).MustHaveHappened();

        }
    }
}
