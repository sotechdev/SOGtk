using SOGtk;

using System;
using System.Reflection;

namespace TestApp
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new SOApplication("org.TestApp.TestApp");
            app.SetIcon(Assembly.GetExecutingAssembly(), "icons8_request_service_128.png");
            var win = new MainWindow();
            app.AddMainWindow(win);
            app.Run();
        }
    }
}
