using System.Text.RegularExpressions;

namespace Tests
{
    public class EpisodeNumber
    {
        private static Regex ParseSeasonEpisodeNumbers = new Regex(@"S(?<season>\d+)[\.\s]?E(?<episode>\d+)", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
        public EpisodeNumber(string value)
        {
            if (!ParseSeasonEpisodeNumbers.IsMatch(value))
                throw new FailedToParseSceneNameException(value);

            var match = ParseSeasonEpisodeNumbers.Match(value);
            if (int.TryParse(match.Groups["season"].Value, out var season))
                Season = season;
            if (int.TryParse(match.Groups["episode"].Value, out var episode))
                Episode = episode;
        }

        public int Season { get; }
        public int Episode { get; }
    }
}