using System;
using Gtk;
using System.Diagnostics;
using System.IO;

namespace Nordvpn_monitor
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            new Monitor().build_window();
        }
    }

    class Monitor
    {
        MainWindow win = new MainWindow();
        public void build_window()
        {
            Application.Run();
        }
    }
}
