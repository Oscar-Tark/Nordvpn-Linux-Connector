using System;
using Gtk;
using System.Diagnostics;
using System.IO;

public partial class MainWindow : Gtk.Window
{
    public bool AllowGrow { get; private set; }
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        connect();
        check_NORD();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    public void check_NORD()
    {
        connection_label.Text = "--";
        Process prc = new Process();
        ProcessStartInfo prcs = new ProcessStartInfo("nordvpn", "status");
        prcs.RedirectStandardOutput = true;
        prcs.UseShellExecute = false;
        prc.StartInfo = prcs;
        prc.Start();
        StreamReader sr = prc.StandardOutput;

        string final = "--";
        if (sr.ReadToEnd().ToLower().Contains("disconnected"))
        {
            final = "Disonnected";
            //string country = sr.ReadToEnd().ToLower().Split(new string[] { "country:" }, StringSplitOptions.RemoveEmptyEntries)[0];
            //final += " To" + country;
        }
        else if (sr.ReadToEnd().ToLower().Contains("reconnecting"))
            final = "Reconnecting";
        else
            final = "Connected";
        connection_label.Text = final;
        return;
    }

    public void connect()
    {
        connection_label.Text = "Connecting..";
        Process prc = new Process();
        ProcessStartInfo prcs = new ProcessStartInfo("./vpncon.out");
        prcs.RedirectStandardOutput = true;
        prcs.UseShellExecute = false;
        prc.StartInfo = prcs;
        prc.Exited += Prc_Exited;
        prc.Start();
        StreamReader sr = prc.StandardOutput;
        check_NORD();
    }

    protected void OnButton1Clicked(object sender, EventArgs e)
    {
        connect();
    }

    void Prc_Exited(object sender, EventArgs e)
    {
        check_NORD();
    }


    protected void OnButton2Clicked(object sender, EventArgs e)
    {
        check_NORD();
    }
}
