using System.Runtime.InteropServices;

namespace OhMyOS.Linux;

[Obsolete("Linux is currently unsupported")]
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
        IntPtr display = XOpenDisplay(IntPtr.Zero);
        if (display == IntPtr.Zero)
        {
            throw new Exception("Failed to open XDisplay.");
        }

        int screenNumber = XDefaultScreen(display);
        IntPtr screen = XScreenOfDisplay(display, screenNumber);

        width = XWidthOfScreen(screen);
        height = XHeightOfScreen(screen);

        XCloseDisplay(display);
    }

    [DllImport("libX11")]
    private static extern IntPtr XOpenDisplay(IntPtr display_name);

    [DllImport("libX11")]
    private static extern int XCloseDisplay(IntPtr display);

    [DllImport("libX11")]
    private static extern int XDefaultScreen(IntPtr display);

    [DllImport("libX11")]
    private static extern IntPtr XScreenOfDisplay(IntPtr display, int screen_number);

    [DllImport("libX11")]
    private static extern int XWidthOfScreen(IntPtr screen);

    [DllImport("libX11")]
    private static extern int XHeightOfScreen(IntPtr screen);
}