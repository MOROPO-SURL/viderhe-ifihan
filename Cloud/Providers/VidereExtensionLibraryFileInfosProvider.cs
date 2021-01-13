using System.Linq;

namespace SmartSolucionesCuba.Videre.Cloud.Providers
{
    internal static class VidereExtensionLibraryFileInfosProvider
    {
        internal static System.Collections.Generic.IEnumerable<System.IO.FileInfo> GetRelevantToCloud(System.IO.DirectoryInfo extensionDirectoryInfo)
        {
            var libraryFileInfos = extensionDirectoryInfo.GetFiles("*.dll", System.IO.SearchOption.TopDirectoryOnly);

            if (libraryFileInfos.Length <= 0) return Enumerable.Empty<System.IO.FileInfo>();

            var extensionDescriptionLibraryFileInfo = libraryFileInfos.First(item => System.Text.RegularExpressions.Regex.IsMatch(item.Name, ".+\\.Videre\\.Extend\\.[a-zA-Z0-9|\\.]+\\.dll"));

            var extensionBaseLibraryFilePath = System.IO.Path.GetFileNameWithoutExtension(extensionDescriptionLibraryFileInfo.Name);

            var motionDescriptionLibraryFileInfo = new System.IO.FileInfo(System.IO.Path.Combine(extensionDirectoryInfo.FullName, string.Format("{0}.Motion.dll", extensionBaseLibraryFilePath)));

            var overlayingDescriptionLibraryFileInfo = new System.IO.FileInfo(System.IO.Path.Combine(extensionDirectoryInfo.FullName, string.Format("{0}.Overlaying.dll", extensionBaseLibraryFilePath)));

            var templatingDescriptionLibraryFileInfo = new System.IO.FileInfo(System.IO.Path.Combine(extensionDirectoryInfo.FullName, string.Format("{0}.Templating.dll", extensionBaseLibraryFilePath)));

            var targetLibraryFileInfos = new System.Collections.Generic.List<System.IO.FileInfo>
            {
                extensionDescriptionLibraryFileInfo
            };

            if (motionDescriptionLibraryFileInfo.Exists)
            {
                targetLibraryFileInfos.Add(motionDescriptionLibraryFileInfo);
            }

            if (overlayingDescriptionLibraryFileInfo.Exists)
            {
                targetLibraryFileInfos.Add(overlayingDescriptionLibraryFileInfo);
            }

            if (templatingDescriptionLibraryFileInfo.Exists)
            {
                targetLibraryFileInfos.Add(templatingDescriptionLibraryFileInfo);
            }

            return targetLibraryFileInfos;
        }

        internal static System.Collections.Generic.IEnumerable<System.IO.FileInfo> GetRelevantToDashboard(System.IO.DirectoryInfo extensionDirectoryInfo)
        {
            var targetLibraryFileInfos = extensionDirectoryInfo.GetFiles("*.dll", System.IO.SearchOption.TopDirectoryOnly);

            if (targetLibraryFileInfos.Length <= 0) return Enumerable.Empty<System.IO.FileInfo>();

            return targetLibraryFileInfos;
        }

        internal static System.Collections.Generic.IEnumerable<System.IO.FileInfo> GetRelevantToPlayer(System.IO.DirectoryInfo extensionDirectoryInfo)
        {
            var targetLibraryFileInfos = extensionDirectoryInfo.GetFiles("*.dll", System.IO.SearchOption.TopDirectoryOnly).ToList();

            if (targetLibraryFileInfos.Count <= 0) return Enumerable.Empty<System.IO.FileInfo>();

            targetLibraryFileInfos.RemoveAll(item => item.Name.Contains("Dashboard"));

            return targetLibraryFileInfos;
        }
    }
}
