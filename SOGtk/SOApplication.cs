using Gdk;

using GLib;

using System;
using System.IO;
using System.Reflection;

namespace SOGtk
{
    public class SOApplication : Gtk.Application
    {
        public SOApplication(IntPtr raw)
            : base(raw)
        {
            SetupInternal();
        }

        public SOApplication(string application_id, ApplicationFlags flags = GLib.ApplicationFlags.None) 
            : base(application_id, flags)
        {
            SetupInternal();
        }

        private void SetupInternal()
        {
            Init();
            Register(GLib.Cancellable.Current);
            SetIcon(Assembly.GetExecutingAssembly(), "LogoSOTech.png");
            SOHelper.ApplyTheme("Dark");
        }

        public new void Run()
        {
            Gtk.Application.Run();
        }

        public void AddMainWindow(Gtk.Window window)
        {
            AppSettings.MainWindow = window;
            AddWindow(window);
            window.Show();
        }
        public void SetIcon(string resourceName) =>
            SetIcon(new Pixbuf(Assembly.GetCallingAssembly().GetResource(resourceName)));
        public void SetIcon(Gdk.Pixbuf icon) => 
            AppSettings.ApplicationIcon = icon;

        public void SetIcon(Assembly assembly, string resourceName) =>
            SetIcon(new Pixbuf(assembly.GetResource(resourceName)));

        public void SetIcon(Stream iconStream) =>
            SetIcon(new Pixbuf(iconStream));
    }
}
