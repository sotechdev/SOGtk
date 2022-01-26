using Gtk;

using SOGtk;

using System;

using UI = Gtk.Builder.ObjectAttribute;

namespace TestApp
{
    internal class MainWindow : SOWindow
    {
        [UI] private Label _label1 = null;
        [UI] private Button _button1 = null;

        private int _counter;
        public MainWindow()
            : base(new Builder("MainWindow.glade"))
        {
            _button1.Clicked += Button1_Clicked;
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            _counter++;
            _label1.Text = "Hello World! This button has been clicked " + _counter + " time(s).";
        }
    }
}
