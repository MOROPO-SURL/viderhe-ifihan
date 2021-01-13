using System.Linq;

namespace SmartSolucionesCuba.Videre.Support.Extend.Runtime.Factories
{
    public static class VidereExtensionDependencyContextFactory
    {
        public static Microsoft.Extensions.DependencyModel.DependencyContext BuildForCloud(Microsoft.Extensions.DependencyModel.TargetInfo targetInfo, System.IO.DirectoryInfo extensionRootDirectoryInfo)
        {
            var runtimeLibraries = new System.Collections.Generic.List<Microsoft.Extensions.DependencyModel.RuntimeLibrary>();

            var extensionDirectoryInfos = extensionRootDirectoryInfo.GetDirectories();

            foreach (var extensionDirectoryInfo in extensionDirectoryInfos)
            {
                var libraryFileInfos = extensionDirectoryInfo.GetFiles("*.dll", System.IO.SearchOption.TopDirectoryOnly);

                if (libraryFileInfos.Length <= 0) continue;

                var extensionDescriptionLibraryFileInfo = libraryFileInfos.First();

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

                foreach (var libraryFileInfo in targetLibraryFileInfos)
                {
                    var assembly = System.Reflection.Assembly.LoadFrom(libraryFileInfo.FullName);

                    var assemblyName = assembly.GetName();

                    runtimeLibraries.Add(new Microsoft.Extensions.DependencyModel.RuntimeLibrary(
                        "project", 
                        assemblyName.Name, 
                        assemblyName.Version.ToString(), 
                        null,
                        new Microsoft.Extensions.DependencyModel.RuntimeAssetGroup[] { },
                        new Microsoft.Extensions.DependencyModel.RuntimeAssetGroup[] { },
                        Enumerable.Empty<Microsoft.Extensions.DependencyModel.ResourceAssembly>(),
                        Enumerable.Empty<Microsoft.Extensions.DependencyModel.Dependency>(), 
                        false));
                }
            }

            return new Microsoft.Extensions.DependencyModel.DependencyContext(
                targetInfo, 
                Microsoft.Extensions.DependencyModel.CompilationOptions.Default, 
                Enumerable.Empty<Microsoft.Extensions.DependencyModel.CompilationLibrary>(), 
                runtimeLibraries,
                new Microsoft.Extensions.DependencyModel.RuntimeFallbacks[] { });
        }
    }
}
