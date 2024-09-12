using System;
using System.Runtime.InteropServices;

namespace DemoOnWin32
{
    internal class Class2
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateWindowEx(int exStyle, string className, string windowName,
            int style, int x, int y, int width, int height, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr RegisterClass(ref WNDCLASS lpWndClass);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint GetLastError();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int FormatMessage(int dwFlags, IntPtr lpSource, uint dwMessageId, int dwLanguageId,
            [Out] System.Text.StringBuilder lpBuffer, int nSize, IntPtr Arguments);

        private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;

        private const int WS_OVERLAPPEDWINDOW = 0x00CF0000;
        private const int SW_SHOW = 5;

        [StructLayout(LayoutKind.Sequential)]
        public struct WNDCLASS
        {
            public uint style;
            public IntPtr lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
        }

        static IntPtr WindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            return DefWindowProc(hWnd, msg, wParam, lParam);
        }

        static void Main(string[] args)
        {
            // Get the module handle
            IntPtr hInstance = GetModuleHandle(null);
            if (hInstance == IntPtr.Zero)
            {
                Console.WriteLine("Failed to get module handle");
                return;
            }

            // Define the window class structure
            WNDCLASS windowClass = new WNDCLASS
            {
                lpfnWndProc = Marshal.GetFunctionPointerForDelegate((WndProc)WindowProc),
                hInstance = hInstance,
                lpszClassName = "MainWinClass" // Ensure this class name is unique and matches CreateWindowEx
            };

            // Register the window class
            IntPtr classAtom = RegisterClass(ref windowClass);
            if (classAtom == IntPtr.Zero)
            {
                Console.WriteLine("Failed to register window class");
                return;
            }

            // Create the main window
            IntPtr hwndMain = CreateWindowEx(
                0,                             // No extended styles
                "MainWinClass",                // Must match the class name registered earlier
                "Main Window",                 // Title of the window
                WS_OVERLAPPEDWINDOW,           // Window style
                100, 100, 800, 600,            // x, y, width, height
                IntPtr.Zero,                   // No parent window
                IntPtr.Zero,                   // No menu
                hInstance,                     // Module instance
                IntPtr.Zero);                  // No additional parameters

            if (hwndMain == IntPtr.Zero)
            {
                // Get the last error
                uint errorCode = GetLastError();
                string errorMessage = GetFormattedErrorMessage(errorCode);
                Console.WriteLine($"Failed to create the main window. Error Code: {errorCode}, Message: {errorMessage}");
                return;
            }

            // Show the window
            ShowWindow(hwndMain, SW_SHOW);
            UpdateWindow(hwndMain);

            Console.WriteLine("Window created successfully.");
        }

        private static string GetFormattedErrorMessage(uint errorCode)
        {
            // Buffer to hold the message
            System.Text.StringBuilder buffer = new System.Text.StringBuilder(256);
            FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, IntPtr.Zero, errorCode, 0, buffer, buffer.Capacity, IntPtr.Zero);
            return buffer.ToString();
        }

        private delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}
