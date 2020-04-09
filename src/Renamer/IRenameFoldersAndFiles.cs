// /* This Source Code Form is subject to the terms of the Mozilla Public
//  * License, v. 2.0. If a copy of the MPL was not distributed with this
//  * file, You can obtain one at https://mozilla.org/MPL/2.0/.
//  */

namespace Renamer
{
    public interface IRenameFoldersAndFiles
    {
        void Rename(string path);
    }

    public interface IRenameFolders
    {
        void Rename(string path);
    }

    public interface IRenameFiles
    {
        void Rename(string path);
    }
}