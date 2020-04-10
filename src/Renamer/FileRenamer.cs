using System.IO.Abstractions;

namespace Renamer
{
    public class FileRenamer : IRenameFiles
    {
        private readonly IParseSceneNames _parser;
        private readonly IFileSystem _filesystem;
        private readonly IRenameMovieFiles _movies;
        private readonly IRenameSeriesFiles _series;

        public FileRenamer(IParseSceneNames parser, IFileSystem filesystem, IRenameMovieFiles movies, IRenameSeriesFiles series)
        {
            _parser = parser;
            _filesystem = filesystem;
            _movies = movies;
            _series = series;
        }
        public void Rename(string path)
        {
            var file = _filesystem.FileInfo.FromFileName(path);
            if (!file.Exists)
                throw new FileNotFoundException(path);

            if (_parser.IsMovie(file.Name))
                _movies.Rename(file);
            else if (_parser.IsEpisode(file.Name))
                _series.Rename(file);
            else
                throw new AmbiguousSceneNameException(file);
        }
    }
}
