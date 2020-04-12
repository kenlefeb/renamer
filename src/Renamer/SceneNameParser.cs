using Microsoft.Extensions.Logging;
using Renamer;
using System;
using System.IO.Abstractions;
using System.Text.RegularExpressions;

namespace Tests
{
    /// <summary>
    /// The rules for input names are best documented here:
    /// http://scenegrouplist.com/scene_info_About_releases_hdarll.php
    /// 
    /// </summary>
    public class SceneNameParser : IParseSceneNames
    {
        private static Regex ParseEpisodeFile = new Regex(@"^(?<series>.*)\.(?<number>S\d+E\d+)\.(?<tags>.*)(?<extension>\.(mkv|avi|mp4|divx|mov|vob|wmv|xvid))$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
        
        private ILogger<SceneNameParser> logger;

        public SceneNameParser(ILogger<SceneNameParser> logger)
        {
            this.logger = logger;
        }

        public bool IsMovie(string name)
        {
            var movie = Parse(name) as Movie;
            return movie != null;
        }
        public bool IsEpisode(string name)
        {
            var episode = Parse(name) as Episode;
            return episode != null;
        }

        public MediaItem Parse(string name)
        {
            if (ParseEpisodeFile.IsMatch(name))
                return ParseEpisode(name);
            throw new FailedToParseSceneNameException(name);
        }

        private Episode ParseEpisode(string name)
        {
            var match = ParseEpisodeFile.Match(name);
            return new Episode
            {
                Title = match.Groups["series"].Value,
                Number = new EpisodeNumber(match.Groups["number"].Value),
                Extension = match.Groups["extension"].Value,
                Tags = match.Groups["tags"].Value,
                FileName = name,
            };
        }
    }
}