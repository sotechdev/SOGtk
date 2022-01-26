using Gtk;

namespace SOGtk
{
    public static class SOMessageBox
    {
        public static ResponseType ShowDialog(Gtk.Window window, string message, string title, MessageType messageType, ButtonsType buttons = ButtonsType.Ok)
        {
            var md = new MessageDialog(window, DialogFlags.DestroyWithParent, messageType, buttons, message)
            {
                Title = title
            };
            var result = (ResponseType)md.Run();
            md.Destroy();
            return result;
        }

        public static ResponseType ShowInfoDialog(string message, string title = "Sucesso", ButtonsType buttons = ButtonsType.Ok)
            => ShowDialog(AppSettings.MainWindow, message, title, MessageType.Info, buttons);

        public static ResponseType ShowErrorDialog(string message, string title = "Erro", ButtonsType buttons = ButtonsType.Ok)
            => ShowDialog(AppSettings.MainWindow, message, title, MessageType.Error, buttons);

        public static ResponseType ShowWarnDialog(string message, string title = "Atenção", ButtonsType buttons = ButtonsType.Ok)
            => ShowDialog(AppSettings.MainWindow, message, title, MessageType.Warning, buttons);

        public static ResponseType ShowQuestionDialog(string message, string title, ButtonsType buttons = ButtonsType.Ok)
            => ShowDialog(AppSettings.MainWindow, message, title, MessageType.Question, buttons);
    }
}
