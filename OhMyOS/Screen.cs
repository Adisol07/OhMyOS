using System;
using System.Runtime.InteropServices;

namespace OhMyOS;

public static class Screen
{
    public static int Width
    {
        get {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OhMyOS.Windows.Screen.Width;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OhMyOS.Linux.Screen.Width;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OhMyOS.MacOS.Screen.Width;
            }
            else
            {
                throw new NotSupportedException("Unsupported platform");
            }
        }
    }
    public static int Height
    {
        get {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OhMyOS.Windows.Screen.Height;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OhMyOS.Linux.Screen.Height;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OhMyOS.MacOS.Screen.Height;
            }
            else
            {
                throw new NotSupportedException("Unsupported platform");
            }
        }
    }
}