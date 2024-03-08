using System.Runtime.InteropServices;

namespace OhMyOS;

public static class OS
{
    public static Platform Platform
    {
        get {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return Platform.Windows;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return Platform.Linux;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return Platform.MacOS;
            else
                return Platform.Unknown;
        }
    }
}