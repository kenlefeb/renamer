using System.IO.Abstractions;

namespace Renamer
{
    public class FolderRenamer : IRenameFolders
    {
        private readonly IParseSceneNames _parser;
        private readonly IFileSystem _filesystem;
        private readonly IRenameMovieFolders _movies;
        private readonly IRenameSeriesFolders _series;

        public FolderRenamer(IParseSceneNames parser, IFileSystem filesystem, IRenameMovieFolders movies, IRenameSeriesFolders series)
        {
            _parser = parser;
            _filesystem = filesystem;
            _movies = movies;
            _series = series;
        }

        public void Rename(string path)
        {
            var folder = _filesystem.DirectoryInfo.FromDirectoryName(path);
            if (!folder.Exists)
                throw new FolderNotFoundException(path);

            if (_parser.IsMovie(folder.Name))
                _movies.Rename(folder);
            else if (_parser.IsEpisode(folder.Name))
                _series.Rename(folder);
            else
                throw new AmbiguousSceneNameException(folder);
        }
    }
}
