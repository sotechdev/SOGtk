﻿using Gtk;

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
        public SOWindow(string title, string gladeFile, string windowName)
            : base(title)
        {
            var builder = new Builder(gladeFile);
            builder.Autoconnect(this);
            Raw = builder.GetRawOwnedObject(windowName);
            SetupInternal();
        }
        public SOWindow(Builder builder)
            : base(builder.GetRawOwnedObject("Window"))
        {
            builder.Autoconnect(this);
            SetupInternal();
        }
        public SOWindow(Builder builder, string windowName)
            : base(builder.GetRawOwnedObject(windowName))
        {
            builder.Autoconnect(this);
            SetupInternal();
        }

        public SOWindow(Builder builder, string windowName, string title)
            : base(builder.GetRawOwnedObject(windowName))
        {
            builder.Autoconnect(this);
            Title = title;
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
