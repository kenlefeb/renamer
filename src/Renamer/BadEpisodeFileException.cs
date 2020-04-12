// /* This Source Code Form is subject to the terms of the Mozilla Public
//  * License, v. 2.0. If a copy of the MPL was not distributed with this
//  * file, You can obtain one at https://mozilla.org/MPL/2.0/.
//  */

using System;

namespace Renamer {
    public class BadEpisodeFileException : ArgumentOutOfRangeException
    {
        public BadEpisodeFileException(string parameterName, string fileName) : base(parameterName,$"The supplied file (\"{fileName}\" does not appear to be an Episode file.") { }
    }
}