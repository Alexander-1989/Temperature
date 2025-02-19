using System;

namespace Temperature
{
    internal static class Extension
    {
        public static T First<T>(this T[] items, T defaultValue = default)
        {
            return (items == null || items.Length == 0) ? defaultValue : items[0];
        }

        public static T Last<T>(this T[] items, T defaultValue = default)
        {
            return (items == null || items.Length == 0) ? defaultValue : items[items.Length - 1];
        }

        public static string IsNotEmpty(this string str, string defaultValue)
        {
            return (str == null || str.Length == 0) ? defaultValue : str;
        }

        public static bool Contains<T>(this T[] items, T value) where T : IEquatable<T>
        {
            foreach (T item in items)
            {
                if (item.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}