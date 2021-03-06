﻿using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divergic.Logging.Xunit;
using FakeItEasy;
using Renamer;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class Renamer_PathToSeriesFile
    {
        private readonly ITestOutputHelper _output;
        private readonly ICacheLogger<Renamer.Renamer> _logger;
        private readonly IRenameFoldersAndFiles _renamer;
        private IRenameFolders _folders;
        private IRenameFiles _files;
        private IFileSystem _filesystem;

        public Renamer_PathToSeriesFile(ITestOutputHelper output)
        {
            _output = output;
            _logger = _output.BuildLoggerFor<Renamer.Renamer>();
            _folders = A.Fake<IRenameFolders>();
            _files = A.Fake<IRenameFiles>();
            _filesystem = new System.IO.Abstractions.TestingHelpers.MockFileSystem(new Dictionary<string, MockFileData>
            {
                { "/home/ken/downloads/My.Show.S01.E01.Episode.Title.1080p.BDRIP.SCENE-REPACK",new MockFileData("1234567890") },
            }, "");

            _renamer = new Renamer.Renamer(_logger, _folders, _files, _filesystem);
            Path = "/home/ken/downloads/My.Show.S01.E01.Episode.Title.1080p.BDRIP.SCENE-REPACK";
        }

        private string Path { get; }

        [Fact]
        public void InvokesFileRenamer()
        {
            // act
            _renamer.Rename(Path);

            // assert
            A.CallTo(() => _files.Rename(A<string>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _folders.Rename(A<string>.Ignored)).MustNotHaveHappened();
        }
    }
}
