using System;
using System.Runtime.InteropServices;

namespace ScreenLimiter
{
    public static class NativeMethods
    {
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(
            IntPtr hWnd, IntPtr hWndInsertAfter,
            int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT { public int X; public int Y; }

        public const uint SWP_NOZORDER = 0x0004;
        public const uint SWP_NOACTIVATE = 0x0010;
        public const uint MONITOR_DEFAULTTONULL = 0;
        public const uint MONITOR_DEFAULTTONEAREST = 2;
    }

    public static class ScreenExtensions
    {
        [DllImport("user32.dll")]
        private static extern IntPtr MonitorFromPoint(NativeMethods.POINT pt, uint dwFlags);

        public static IntPtr GetHmonitor(this System.Windows.Forms.Screen screen)
        {
            NativeMethods.POINT pt = new NativeMethods.POINT { X = screen.Bounds.Left, Y = screen.Bounds.Top };
            return MonitorFromPoint(pt, NativeMethods.MONITOR_DEFAULTTONEAREST);
        }
    }
}
