using System.Text.RegularExpressions;

namespace Tests
{
    internal class EpisodeNumber
    {
        public EpisodeNumber(string value)
        {
            var regex = new Regex(@"S(?<season>\d+)[\.\s]?E(?<episode>\d+)");
            if (!regex.IsMatch(value))
                throw new FailedToParseSceneNameException(value);

            var match = regex.Match(value);
            if (int.TryParse(match.Groups["season"].Value, out var season))
                Season = season;
            if (int.TryParse(match.Groups["episode"].Value, out var episode))
                Episode = episode;
        }

        public int Season { get; }
        public int Episode { get; }
    }
}