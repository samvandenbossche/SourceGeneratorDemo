using System.IO;
using System.Reflection;
using System.Text;

namespace ToString.Tests;

public static class AssemblyHelper
{
    /// <summary>
    /// Gets the string from resource file asynchronous.
    /// </summary>
    /// <param name="resourceFile">The resource file name.</param>
    public static string GetStringFromResourceFileAsync(string resourceFile)
    {
        using var reader = new StreamReader($"./Resources/{resourceFile}", Encoding.UTF8);
        return reader.ReadToEnd();
    }
}
