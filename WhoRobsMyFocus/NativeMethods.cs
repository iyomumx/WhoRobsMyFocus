﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace WhoRobsMyFocus
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        private static extern int GetWindowText(IntPtr hWnd, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hwnd, uint wMsg, UIntPtr wParam, IntPtr lParam);
        private const uint WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;
        private static UIntPtr MoveCaption = new UIntPtr(SC_MOVE + HTCAPTION);
        public static void DoCaptionDown(IntPtr hWnd)
        {
            ReleaseCapture();
            SendMessage(hWnd, WM_SYSCOMMAND, MoveCaption, IntPtr.Zero);
        }

        public static LogEntry GetTopWindowInfo()
        {
            IntPtr hWnd = GetForegroundWindow();
            if (hWnd == IntPtr.Zero) return null;
            uint lpdwProcessId;
            if (GetWindowThreadProcessId(hWnd, out lpdwProcessId) == 0) return null;
            Process oProcess = Process.GetProcessById((int)lpdwProcessId);
            int length = GetWindowTextLength(hWnd);
            StringBuilder text = new StringBuilder(length + 1);
            GetWindowText(hWnd, text, text.Capacity);
            return new LogEntry() { ExecName = System.IO.Path.GetFileName(oProcess.MainModule.FileName), WindowName = text.ToString(), PID = (int)lpdwProcessId, LogTime = DateTime.Now };
        }
    }
}
