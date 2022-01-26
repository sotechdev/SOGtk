using Gdk;

using System.Collections.Generic;

namespace SOGtk
{
    internal class AppSettings
    {
        public static List<SOWindow> ActiveWindows = new List<SOWindow>();

        public static Pixbuf ApplicationIcon { get; internal set; }
    }
}
