using Tests;

namespace Renamer
{
    public abstract class MediaItem
    {
    }

    public class Movie : MediaItem
    {

    }

    public class Episode : MediaItem
    {
        public string Title { get; set; } = string.Empty;
        public string Quality { get; set; } = string.Empty;
        public string Encoding { get; set; } = string.Empty;
        public string Container { get; set; } = string.Empty;
        public string Remainder { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public EpisodeNumber Number { get; set; } = new EpisodeNumber("S00E00");
    }
}