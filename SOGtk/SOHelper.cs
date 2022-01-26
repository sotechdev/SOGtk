using System.IO;
using System.Reflection;

namespace SOGtk
{
    internal class SOHelper
    {
        public static void ApplyTheme(string themeName = null, bool isDark = false)
        {
            // Based on this Link http://awesome.naquadah.org/wiki/Better_Font_Rendering

            // Get the Global Settings
            var setts = Gtk.Settings.Default;
            // This enables clear text on Win32, makes the text look a lot less crappy
            setts.XftRgba = "rgb";
            // This enlarges the size of the controls based on the dpi
            //setts.XftDpi = 96;
            // By Default Anti-aliasing is enabled, if you want to disable it for any reason set this value to 0
            //setts.XftAntialias = 0
            // Enable text hinting
            setts.XftHinting = 1;
            //setts.XftHintstyle = "hintslight"
            setts.XftHintstyle = "hintfull";

            // Load the Theme
            Gtk.CssProvider css_provider = new Gtk.CssProvider();
            var theme = string.IsNullOrWhiteSpace(themeName) ? "Dark" : themeName;
            var cssfile = isDark ? "gtk-dark.css" : "gtk.css";
            var resourceName = $"SOGtk.Assets.Themes.{theme}.gtk_3._0.{cssfile}";
            var resource = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName));
            string text = resource.ReadToEnd();
            css_provider.LoadFromData(text);
            Gtk.StyleContext.AddProviderForScreen(Gdk.Screen.Default, css_provider, 800);
        }
    }
}
