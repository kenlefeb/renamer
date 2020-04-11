using Divergic.Logging.Xunit;
using Renamer;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class Parser_PathToSeriesFile : VerifyBase
    {
        private readonly ICacheLogger<SceneNameParser> _logger;
        private readonly string _filename;
        private readonly IParseSceneNames _parser;


        public Parser_PathToSeriesFile(ITestOutputHelper output) : base(output)
        {
            // arrange
            _logger = Output.BuildLoggerFor<SceneNameParser>();
            _filename = "My.Show.S01E01.1080p.BDRIP.SCENE-REPACK";
            _parser = new SceneNameParser(_logger);
        }

        [Fact]
        public Task ParsesFileName()
        {
            // act
            var actual = _parser.Parse(_filename);

            // assert
            return Verify(actual);
        }

        [Theory]
        [MemberData(nameof(TestFiles))]
        public Task ParsesTestFileNames(IFileSystem filesystem, string path)
        {
            // arrange
            var fileinfo = filesystem.FileInfo.FromFileName(path);
            
            // act
            var actual = _parser.Parse(fileinfo.Name);
            
            // assert
            return Verify(actual);
        }

        public static IEnumerable<object[]> TestFiles()
        {
            var files = TestData.BuildDownloadsFolder();
            foreach (var path in files.AllFiles.Take(3))
            {
                yield return new object[] {files, path};
            }
        }
    }
}
