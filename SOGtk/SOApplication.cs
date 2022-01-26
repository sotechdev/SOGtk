using GLib;

using System;

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
        }

        public new void Run()
        {
            Gtk.Application.Run();
        }
    }
}
