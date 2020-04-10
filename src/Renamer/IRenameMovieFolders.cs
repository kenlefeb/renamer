using System.IO.Abstractions;

namespace Renamer
{
    public interface IRenameMovieFolders
    {
        void Rename(IDirectoryInfo folder);
    }
}