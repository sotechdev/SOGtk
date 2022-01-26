using System.IO;
using System.Reflection;

namespace SOGtk
{
    public static class AssemblyExtensions
    {
        public static Stream GetResource(this Assembly assembly, string resourceName)
        {
            var fileName = $"{assembly.GetName().Name}.Assets.{resourceName}";
            return assembly.GetManifestResourceStream(fileName);
        }
    }
}
