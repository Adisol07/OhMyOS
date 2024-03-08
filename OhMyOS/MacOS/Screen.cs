using System.Runtime.InteropServices;

namespace OhMyOS.MacOS;

public static class Screen
{
    public static int Width 
    {
        get {
            int width = 0;
            GetScreenSize(out width, out _);
            return width;
        }
    }
    public static int Height 
    {
        get {
            int height = 0;
            GetScreenSize(out _, out height);
            return height;
        }
    }

    private static void GetScreenSize(out int width, out int height)
    {
        IntPtr mainDisplayID = CGMainDisplayID();
        CGRect bounds = CGDisplayBounds(mainDisplayID);

        width = (int)bounds.width;
        height = (int)bounds.height;
    }

    [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
    private static extern IntPtr CGMainDisplayID();

    [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
    private static extern CGRect CGDisplayBounds(IntPtr displayID);
}