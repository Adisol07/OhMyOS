using System.Runtime.InteropServices;

namespace OhMyOS.Windows;

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
        IntPtr hdc = GetDC(IntPtr.Zero);
        width = GetSystemMetrics(SM_CXSCREEN);
        height = GetSystemMetrics(SM_CYSCREEN);
        ReleaseDC(IntPtr.Zero, hdc);
    }

    [DllImport("user32.dll")]
    private static extern IntPtr GetDC(IntPtr hwnd);

    [DllImport("user32.dll")]
    private static extern int GetSystemMetrics(int nIndex);

    [DllImport("user32.dll")]
    private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

    private const int SM_CXSCREEN = 0;
    private const int SM_CYSCREEN = 1;
}