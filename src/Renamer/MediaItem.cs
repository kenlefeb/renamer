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
        public string Title { get; internal set; }
        public string Quality { get; internal set; }
        public string Encoding { get; internal set; }
        public string Container { get; internal set; }
        public string Remainder { get; internal set; }
        public string FileName { get; internal set; }
        internal EpisodeNumber Number { get; set; }
    }
}