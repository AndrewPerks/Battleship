using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Battleship.Objects.Windows
{
    public class Window
    {

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        public void Maximise()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
        }
    }
}
