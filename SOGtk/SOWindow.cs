using Gtk;

using System;
using System.Linq;

namespace SOGtk
{
    public class SOWindow : Window
    {
        public SOWindow(IntPtr raw) : base(raw)
        {
            SetupInternal();
        }

        public SOWindow(WindowType type) : base(type)
        {
            SetupInternal();
        }

        public SOWindow(string title) : base(title)
        {
            SetupInternal();
        }

        public SOWindow(Func<IntPtr> builder)
            : base(builder())
        {
            SetupInternal();
        }

        private void SetupInternal()
        {
            AppSettings.ActiveWindows.Add(this);
            DeleteEvent += (_, __) =>
            {
                AppSettings.ActiveWindows.Remove(this);
                if (!AppSettings.ActiveWindows.Any())
                    Application.Quit();
            };

            if (AppSettings.ApplicationIcon != null)
                Icon = AppSettings.ApplicationIcon;
        }
    }
}
