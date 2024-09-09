using System.Runtime.InteropServices;

namespace DemoOnWin32
{
    internal class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd,string text,string caption,uint type);
        static void Main(string[] args)
        {
            MessageBox(IntPtr.Zero,"I am a test asdasd","Heading some dummy text",0);
        }
    }
}
