using System;
using System.Runtime.InteropServices;

namespace OhMyOS;

public static class Mouse
{
    public static void Click(int x, int y)
    {
        switch (OS.Platform)
        {
            case Platform.Windows:
                OhMyOS.Windows.Mouse.Click(x, y);
                break;
            case Platform.MacOS:
                OhMyOS.MacOS.Mouse.Click(x, y);
                break;
            case Platform.Linux:
                OhMyOS.Linux.Mouse.Click(x, y);
                break;
            default:
                throw new NotSupportedException("Unsupported platform");
        }
    }
    public static void Move(int x, int y)
    {
        switch (OS.Platform)
        {
            case Platform.Windows:
                OhMyOS.Windows.Mouse.Move(x, y);
                break;
            case Platform.MacOS:
                OhMyOS.MacOS.Mouse.Move(x, y);
                break;
            case Platform.Linux:
                OhMyOS.Linux.Mouse.Move((uint)x, (uint)y);
                break;
            default:
                throw new NotSupportedException("Unsupported platform");
        }
    }
}
