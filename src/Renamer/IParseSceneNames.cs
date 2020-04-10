using System.IO.Abstractions;

namespace Renamer
{
    public interface IParseSceneNames
    {
        bool IsMovie(string path);
        bool IsEpisode(string path);
        MediaItem Parse(string path);
    }
}