using System;
using System.Runtime.InteropServices;

namespace OhMyOS;

public static class Mouse
{
    public static void Click(int x, int y, bool moveThere = true)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            OhMyOS.Windows.Mouse.Click(x, y, moveThere);
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            OhMyOS.MacOS.Mouse.Click(x, y);
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            OhMyOS.Linux.Mouse.Click(x, y);
        else
            throw new NotSupportedException("Unsupported platform");
    }
    public static void Move(int x, int y)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            OhMyOS.Windows.Mouse.Move(x, y);
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            OhMyOS.MacOS.Mouse.Move(x, y);
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            OhMyOS.Linux.Mouse.Move((uint)x, (uint)y);
        else
            throw new NotSupportedException("Unsupported platform");
    }
}
