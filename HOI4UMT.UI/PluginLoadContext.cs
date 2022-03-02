using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace HOI4UMT.UI;

internal class PluginLoadContext : AssemblyLoadContext {
    private AssemblyDependencyResolver Resolver { get; }

    internal PluginLoadContext(string pluginPath) {
        Resolver = new AssemblyDependencyResolver(pluginPath);
    }

    protected override Assembly Load(AssemblyName assemblyName) {
        Option<string> assemblyPath = Resolver.ResolveAssemblyToPath(assemblyName) ?? Option<string>.None;

        return assemblyPath.MatchUnsafe(path => LoadFromAssemblyPath(path), () => null);
    }

    protected override IntPtr LoadUnmanagedDll(string unmanagedDllName) {
        Option<string> libraryPath = Resolver.ResolveUnmanagedDllToPath(unmanagedDllName) ?? Option<string>.None;

        return libraryPath.Match(path => LoadUnmanagedDllFromPath(path), () => IntPtr.Zero);
    }
}
