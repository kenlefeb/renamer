using System.IO.Abstractions;

namespace Renamer
{
    public interface IRenameSeriesFiles
    {
        void Rename(IFileInfo file);
    }
}