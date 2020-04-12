using Divergic.Logging.Xunit;
using Renamer;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Verify;
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
        private static MockFileSystem _filesystem = TestData.BuildDownloadsFolder();

        public Parser_PathToSeriesFile(ITestOutputHelper output) : base(output)
        {
            // arrange
            _logger = Output.BuildLoggerFor<SceneNameParser>();
            _filename = "My.Show.S01E01.1080p.BDRIP.SCENE-REPACK.mkv";
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
        [InlineData("/home/ken/downloads/Talking.Dead.S09E14.Talking.Dead.on.Look.at.the.Flowers.1080p.HDTV.x264-CRiMSON/Talking.Dead.S09E14.Talking.Dead.on.Look.at.the.Flowers.1080p.HDTV.x264-CRiMSON.mkv")]
        [InlineData("/home/ken/downloads/Better.Call.Saul.S05E07.1080p.WEB.H264-XLF/better.call.saul.s05e07.1080p.web.h264-xlf.mkv")]
        [InlineData("/home/ken/downloads/Our.Cartoon.President.S03E08.G-7.720p.AMZN.WEB-DL.DD+2.0.H.264-monkee/Our.Cartoon.President.S03E08.G-7.720p.AMZN.WEB-DL.DD+2.0.H.264-monkee.mkv")]
        public Task ParsesTestFileNames(string path)
        {
            // arrange
            var fileinfo = _filesystem.FileInfo.FromFileName(path);
            
            // act
            var actual = _parser.Parse(fileinfo.Name);
            
            // assert
            return Verify(actual);
        }

        public static IEnumerable<object[]> TestFiles()
        {
            var regex = new Regex(@"^(?<series>.*)\.(?<number>S\d+E\d+)\.(?<tags>.*)(?<extension>\.(mkv|avi|mp4|divx|mov|vob|wmv|xvid))$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
            foreach (var path in _filesystem.AllFiles.Where(f => regex.IsMatch(f)).Take(3))
            {
                yield return new object[] {path};
            }
        }
    }
}
