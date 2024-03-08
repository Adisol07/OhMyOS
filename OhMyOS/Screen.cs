using System;
using System.Runtime.InteropServices;

namespace OhMyOS;

public static class Screen
{
    public static int Width
    {
        get {
            switch (OS.Platform)
            {
                case Platform.Windows:
                    return OhMyOS.Windows.Screen.Width;
                case Platform.MacOS:
                    return OhMyOS.MacOS.Screen.Width;
                case Platform.Linux:
                    return OhMyOS.Linux.Screen.Width;
                default:
                    throw new NotSupportedException("Unsupported platform");
            }
        }
    }
    public static int Height
    {
        get {
            switch (OS.Platform)
            {
                case Platform.Windows:
                    return OhMyOS.Windows.Screen.Height;
                case Platform.MacOS:
                    return OhMyOS.MacOS.Screen.Height;
                case Platform.Linux:
                    return OhMyOS.Linux.Screen.Height;
                default:
                    throw new NotSupportedException("Unsupported platform");
            }
        }
    }
}