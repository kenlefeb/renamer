// /* This Source Code Form is subject to the terms of the Mozilla Public
//  * License, v. 2.0. If a copy of the MPL was not distributed with this
//  * file, You can obtain one at https://mozilla.org/MPL/2.0/.
//  */

using System;
using System.IO.Abstractions;

namespace Renamer
{
    public class SeriesFileRenamer : IRenameSeriesFiles
    {
        private IParseSceneNames _parser;
        private IPopulateMetadataForEpisodes _populator;
        private IMoveMediaFiles _mover;

        public SeriesFileRenamer(IParseSceneNames parser, IPopulateMetadataForEpisodes populator, IMoveMediaFiles mover)
        {
            _parser = parser;
            _populator = populator;
            _mover = mover;
        }

        public IFileInfo Rename(IFileInfo file)
        {
            if (!_parser.IsEpisode(file.Name))
                throw new BadEpisodeFileException(nameof(file), file.Name);

            var item = _parser.Parse(file.Name);
            item = _populator.Populate(item);
            return _mover.Move(file, item);
        }
    }
}