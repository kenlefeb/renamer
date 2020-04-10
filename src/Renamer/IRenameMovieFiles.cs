using System.IO.Abstractions;

namespace Renamer
{
    public interface IRenameMovieFiles
    {
        void Rename(IFileInfo file);
    }
}