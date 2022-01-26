using Gtk;

using System;
using System.Linq;
using System.Reflection;

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

        public SOWindow(string gladeFile) : base(IntPtr.Zero)
        {
            var builder = new Builder(Assembly.GetCallingAssembly(), gladeFile, null);
            builder.Autoconnect(this);
            Raw = builder.GetRawOwnedObject("Window");
            SetupInternal();
        }
        public SOWindow(string title, string gladeFile)
            : base(title)
        {
            var builder = new Builder(Assembly.GetCallingAssembly(), gladeFile, null);
            builder.Autoconnect(this);
            Raw = builder.GetRawOwnedObject("Window");
            SetupInternal();
        }
        public SOWindow(string title, string gladeFile, string windowName)
            : base(title)
        {
            var builder = new Builder(Assembly.GetCallingAssembly(), gladeFile, null);
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
        public ResponseType ShowInfoDialog(string message, string title = "Sucesso", ButtonsType buttons = ButtonsType.Ok)
            => SOMessageBox.ShowDialog(this, message, title, MessageType.Info, buttons);

        public ResponseType ShowErrorDialog(string message, string title = "Erro", ButtonsType buttons = ButtonsType.Ok)
            => SOMessageBox.ShowDialog(this, message, title, MessageType.Error, buttons);

        public ResponseType ShowWarnDialog(string message, string title = "Atenção", ButtonsType buttons = ButtonsType.Ok)
            => SOMessageBox.ShowDialog(this, message, title, MessageType.Warning, buttons);

        public ResponseType ShowQuestionDialog(string message, string title, ButtonsType buttons = ButtonsType.Ok)
            => SOMessageBox.ShowDialog(this, message, title, MessageType.Question, buttons);
    }
}
