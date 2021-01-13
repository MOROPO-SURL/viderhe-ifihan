using System.Linq;
using System.Reflection;

namespace SmartSolucionesCuba.Videre.Support.Extend.Runtime
{
    public class AssemblyLoader : System.Runtime.Loader.AssemblyLoadContext
    {
        private readonly string extensionDirectoryPath;

        public AssemblyLoader(string extensionDirectoryPath)
        {
            this.extensionDirectoryPath = extensionDirectoryPath;
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            var dependencyContext = Microsoft.Extensions.DependencyModel.DependencyContext.Default;

            var res = dependencyContext.CompileLibraries.Where(d => d.Name.Contains(assemblyName.Name)).ToList();
            
            if (res.Count > 0)
            {
                return Assembly.Load(new AssemblyName(res.First().Name));
            }
            else
            {
                var apiApplicationFileInfo = new System.IO.FileInfo($"{extensionDirectoryPath}{System.IO.Path.DirectorySeparatorChar}{assemblyName.Name}.dll");

                if (System.IO.File.Exists(apiApplicationFileInfo.FullName))
                {
                    var dependencyLoader = new AssemblyLoader(apiApplicationFileInfo.DirectoryName);

                    return dependencyLoader.LoadFromAssemblyPath(apiApplicationFileInfo.FullName);
                }
            }
            return Assembly.Load(assemblyName);
        }
    }
}
