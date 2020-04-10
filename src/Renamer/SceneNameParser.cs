﻿using Microsoft.Extensions.Logging;
using Renamer;
using System;
using System.IO.Abstractions;
using System.Text.RegularExpressions;

namespace Tests
{
    public class SceneNameParser : IParseSceneNames
    {
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
            var regex = new Regex(@"(?<title>.+?)(?<episode>S\d+E\d+)[\-\.\s]((?<quality>(720|1080)[pi]?)[\-\.\s])?((?<encoding>(BluRay|HEVC|HDTV|BDRIP|DVDRIP))[\.\s])?((?<container>(MKV|x265|x264|XviD))[\-\.\s])?(?<remainder>.*)");
            if (regex.IsMatch(name))
                return ParseEpisode(name);
            throw new FailedToParseSceneNameException(name);
        }

        private Episode ParseEpisode(string name)
        {
            var regex = new Regex(@"(?<title>.+?)(?<episode>S\d+E\d+)[\-\.\s]((?<quality>(720|1080)[pi]?)[\-\.\s])?((?<encoding>(BluRay|HEVC|HDTV|BDRIP|DVDRIP))[\.\s])?((?<container>(MKV|x265|x264|XviD))[\-\.\s])?(?<remainder>.*)");
            var match = regex.Match(name);
            return new Episode
            {
                Title = match.Groups["title"].Value,
                Number = ParseEpisodeNumber(match.Groups["episode"].Value),
                Quality = match.Groups["quality"].Value,
                Encoding = match.Groups["encoding"].Value,
                Container = match.Groups["container"].Value,
                Remainder = match.Groups["remainder"].Value,
                FileName = name,
            };
        }

        private EpisodeNumber ParseEpisodeNumber(string text)
        {
            return new EpisodeNumber(text);
        }
    }
}