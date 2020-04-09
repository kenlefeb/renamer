// /* This Source Code Form is subject to the terms of the Mozilla Public
//  * License, v. 2.0. If a copy of the MPL was not distributed with this
//  * file, You can obtain one at https://mozilla.org/MPL/2.0/.
//  */

using CommandLine;

namespace Console.Commands.Rename
{
    [Verb("rename", HelpText = "Rename a file or folder representing a single piece of media.")]
    public class Options
    {
        [Value(0)]
        public string Path { get; set; }
    }
}