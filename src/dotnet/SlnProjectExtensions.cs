﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.IO;

namespace Microsoft.DotNet.Tools.Common
{
    internal static class SlnProjectExtensions
    {
        public static IList<string> GetSolutionFoldersFromProjectPath(string projectFilePath)
        {
            var solutionFolders = new List<string>();

            if (IsPathInTreeRootedAtSolutionDirectory(projectFilePath))
            {
                var currentDirString = $".{Path.DirectorySeparatorChar}";
                if (projectFilePath.StartsWith(currentDirString))
                {
                    projectFilePath = projectFilePath.Substring(currentDirString.Length);
                }

                var projectDirectoryPath = TrimProject(projectFilePath);
                if (!string.IsNullOrEmpty(projectDirectoryPath))
                {
                    var solutionFoldersPath = TrimProjectDirectory(projectDirectoryPath);
                    if (!string.IsNullOrEmpty(solutionFoldersPath))
                    {
                        solutionFolders.AddRange(solutionFoldersPath.Split(Path.DirectorySeparatorChar));
                    }
                }
            }

            return solutionFolders;
        }

        private static bool IsPathInTreeRootedAtSolutionDirectory(string path)
        {
            return !path.StartsWith("..");
        }

        private static string TrimProject(string path)
        {
            return Path.GetDirectoryName(path);
        }

        private static string TrimProjectDirectory(string path)
        {
            return Path.GetDirectoryName(path);
        }
    }
}
