using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WhoRobsMyFocus
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;

        public static void DoCaptionDown(IntPtr hWnd)
        {
            ReleaseCapture();
            SendMessage(hWnd, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        public static LogEntry GetTopWindowInfo()
        {
            IntPtr hWnd = GetForegroundWindow();
            if (hWnd == IntPtr.Zero) return null;
            uint lpdwProcessId;
            GetWindowThreadProcessId(hWnd, out lpdwProcessId);
            Process oProcess = Process.GetProcessById((int)lpdwProcessId);
            int length = GetWindowTextLength(hWnd);
            StringBuilder text = new StringBuilder(length + 1);
            GetWindowText(hWnd, text, text.Capacity);
            return new LogEntry() { ExecName = System.IO.Path.GetFileName(oProcess.MainModule.FileName), WindowName = text.ToString(), PID = (int)lpdwProcessId, LogTime = DateTime.Now };
        }
    }
}
