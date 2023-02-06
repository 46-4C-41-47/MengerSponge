using System.Runtime.InteropServices;

namespace MengerSponge;

static class Program
{
    [DllImport( "kernel32.dll" )]
    private static extern bool AttachConsole( int dwProcessId );
    private const int ATTACH_PARENT_PROCESS = -1;
    
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        AttachConsole(ATTACH_PARENT_PROCESS);
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}