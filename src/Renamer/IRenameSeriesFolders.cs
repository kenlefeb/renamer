using System.IO.Abstractions;

namespace Renamer
{
    public interface IRenameSeriesFolders
    {
        void Rename(IDirectoryInfo folder);
    }
}