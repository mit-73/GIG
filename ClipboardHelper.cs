using System;
using System.Runtime.InteropServices;

namespace GIG
{
    public class ClipboardHelper
    {
        [DllImport("user32.dll")]
        private static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll")]
        private static extern bool CloseClipboard();

        [DllImport("user32.dll")]
        private static extern bool SetClipboardData(uint uFormat, IntPtr data);
        
        public static void SetText(string text)
        {
            var data = Marshal.StringToHGlobalUni(text);
            OpenClipboard(IntPtr.Zero);
            SetClipboardData(13, data);
            CloseClipboard();
            Marshal.FreeHGlobal(data);
        }
    }
}