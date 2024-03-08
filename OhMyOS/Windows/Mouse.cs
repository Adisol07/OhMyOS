using System;
using System.Runtime.InteropServices;
using OhMyOS.MacOS;

namespace OhMyOS.Windows;

public static class Mouse
{
    public static void Click(int x, int y, bool moveThere = true)
    {
        POINT last;
        GetCursorPos(out last);
        SetCursorPos(x, y);
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        if (!moveThere)
        {
            SetCursorPos(last.X, last.Y);
        }
    }
    public static void Move(int x, int y)
    {
        SetCursorPos(x, y);
    }

    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int X, int Y);

    [DllImport("user32.dll")]
    private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetCursorPos(out POINT lpPoint);

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }
}