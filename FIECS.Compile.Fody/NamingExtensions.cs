using System;
using System.Linq;

namespace FIECS.Compile.Fody
{
    public static class NamingExtensions
    {
        public static string ToCamelCase(this string text, bool underscores = false)
        {
            return text.ChangeCase(false, false);
        }

        public static string ToPascalCase(this string text, bool underscores = false)
        {
            return text.ChangeCase(true, false);
        }

        private static string ChangeCase(this string text, bool firstCharacterUpperCase, bool underscores = false)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var stringArray = text.Trim().ToCharArray();

            if (!underscores)
            {
                stringArray = stringArray.Where(c => c != '_').ToArray();
            }

            if (stringArray.Length == 0)
                throw new ArgumentException("No valid characters", nameof(text));

            if (firstCharacterUpperCase)
                stringArray[0] = char.ToUpperInvariant(stringArray[0]);
            else
                stringArray[0] = char.ToLowerInvariant(stringArray[0]);

            var converted = new string(stringArray).Trim();

            return converted;
        }
    }
}
