using System;
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
        static void Main()
        {
            string assemblyPath = @"C:\Users\Ian\Documents\GitHub\NunitDummy\NunitDummy\bin\Debug\netcoreapp3.1\NunitDummy.dll";
            var alc = new CustomAssemblyLoadContext(assemblyPath);
            var assembly = alc.LoadFromAssemblyPath(assemblyPath);
            var ts = assembly.GetTypes();
            foreach( var tt in ts)
                Console.WriteLine(tt);
        }
    }
}
