using System.IO.Abstractions;
using Microsoft.Extensions.Logging;

namespace Renamer
{
    public class Renamer : IRenameFoldersAndFiles
    {
        private readonly ILogger<Renamer> _logger;
        private readonly IRenameFolders _folders;
        private readonly IRenameFiles _files;
        private readonly IFileSystem _filesystem;

        public Renamer(ILogger<Renamer> logger, IRenameFolders folders, IRenameFiles files, IFileSystem filesystem)
        {
            _logger = logger;
            _folders = folders;
            _files = files;
            _filesystem = filesystem;
        }

        public void Rename(string path)
        {
            if (isFile(path))
                _files.Rename(path);
            else if (isFolder(path))
                _folders.Rename(path);
            else
                throw new PathNotFoundException(path);
        }

        private bool isFolder(string path)
        {
            return _filesystem.Directory.Exists(path);
        }

        private bool isFile(string path)
        {
            return _filesystem.File.Exists(path);
        }
    }
}
