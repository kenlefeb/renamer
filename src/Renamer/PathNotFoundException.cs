// /* This Source Code Form is subject to the terms of the Mozilla Public
//  * License, v. 2.0. If a copy of the MPL was not distributed with this
//  * file, You can obtain one at https://mozilla.org/MPL/2.0/.
//  */

using System;

namespace Renamer
{
    public class PathNotFoundException : Exception
    {
        public PathNotFoundException(string path) : base($"The file or folder \"{path}\" was not found.") { }
    }

    public class FileNotFoundException : Exception
    {
        public FileNotFoundException(string path) : base($"The file \"{path}\" was not found.") { }
    }

    public class FolderNotFoundException : Exception
    {
        public FolderNotFoundException(string path) : base($"The folder \"{path}\" was not found.") { }
    }
}