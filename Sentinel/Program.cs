using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Sentinel {

    enum Window : int {
        HIDE = 0,
        SHOWNORMAL = 1,
        SHOW = 5,
        MAXIMISE = 3,
        MAXIMIZE = 3,
        MINIMISE = 6,
        MINIMIZE = 6,
        RESTORE = 9,
        SHOWDEFAULT = 10,
        FORCEMINIMISE = 11,
        FORECEMINIMIZE = 11,
    }
    enum WindowPosition : int {
        NOTOPMOST = -2,
        TOPMOST = -1,
        TOP = 0,
        BOTTOM = 1
    }
    class Win32 {
        public delegate bool CallbackPointer(int hWnd, int lParam);

        static string GetWindowText(int hWnd) {
            int size = GetWindowTextLength(hWnd);
            if (size > 0) {
                var builder = new StringBuilder(size + 1);
                GetWindowText(hWnd, builder, builder.Capacity);
                return builder.ToString();
            }
            return String.Empty;
        }

        [DllImport("User32.dll")]
        public static extern Int32 FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        [DllImport("User32.dll")]
        public static extern Int32 ShowWindow(int hWnd, int nCmdShow);

        [DllImport("User32.dll")]
        public static extern Int32 CloseWindow(int hWnd);

        [DllImport("User32.dll")]
        public static extern Int32 DestroyWindow(int hWnd);

        [DllImport("User32.dll")]
        public static extern int EnumWindows(CallbackPointer callPtr, int lPar);

        [DllImport("User32.dll")]
        public static extern int GetWindowText(int hWnd, StringBuilder strText, int MaxCount);

        [DllImport("User32.dll")]
        private static extern int GetWindowTextLength(int hWnd);

        [DllImport("User32.dll")]
        public static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        [DllImport("Kernel32.dll")]
        public static extern uint GetLastError();
    }
}
