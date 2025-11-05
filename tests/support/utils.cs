// Support/Utils.cs
using System.Text.RegularExpressions;

namespace MyTests.Support;

public static class Utils
{
    /// <summary>
    /// Converts a product name like "Sauce Labs Backpack"
    /// into a slug like "sauce-labs-backpack".
    /// </summary>
    public static string ProductSlug(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return string.Empty;

        // Lowercase and trim
        name = name.ToLowerInvariant().Trim();

        // Replace whitespace (and similar) with hyphens
        name = Regex.Replace(name, @"\s+", "-");

        return name;
    }
}
