using SOGtk;

using System;

namespace TestApp
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new SOApplication("org.TestApp.TestApp");

            var win = new MainWindow();
            app.AddMainWindow(win);
            app.Run();
        }
    }
}
