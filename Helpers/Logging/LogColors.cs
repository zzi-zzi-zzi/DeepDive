using System.Reflection;
using System.Windows.Media;

namespace Deep.Logging
{
    internal static class LogColors
    {
        internal static Color Error => Colors.Red;

        internal static Color Info => Colors.DeepSkyBlue;

        internal static Color Verbose => Colors.Green;

        internal static Color Warn => Colors.HotPink;
    }
}