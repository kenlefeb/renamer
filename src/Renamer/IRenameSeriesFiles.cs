using System.IO.Abstractions;

namespace Renamer
{
    public interface IRenameSeriesFiles
    {
        IFileInfo Rename(IFileInfo file);
    }
}