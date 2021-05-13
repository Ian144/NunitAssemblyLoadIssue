using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace ConsoleALC
{
    internal class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver _resolver;

        public CustomAssemblyLoadContext(string assemblyPath)
        {
            _resolver = new AssemblyDependencyResolver(assemblyPath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            var assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
            Console.WriteLine($"CustomAssemblyLoadContext: {assemblyName}");
            return assemblyPath != null ? LoadFromAssemblyPath(assemblyPath) : null;
        }
    }

    class Program
    {
        static void Main( string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += (obj, evArgs) =>
            {
                Console.WriteLine($"AssemblyResolve: {evArgs.Name}");
                return null;
            };

            string assemblyPath = args[0];
            string fullAssemblyPath = Path.GetFullPath(assemblyPath);
            var alc = new CustomAssemblyLoadContext(fullAssemblyPath);
            var assembly = alc.LoadFromAssemblyPath(fullAssemblyPath);
            var ts = assembly.GetTypes(); // will throw ReflectionTypeLoadException here, as AssemblyB cannot be loaded
            foreach( var tt in ts)
                Console.WriteLine(tt);
        }
    }
}
