using System;
using System.Runtime.InteropServices;

namespace OhMyOS.Linux;

[Obsolete("Linux is currently unsupported")]
public static class Mouse
{
    public static void Click(int x, int y)
    {
        IntPtr display = XOpenDisplay(IntPtr.Zero);
        XWarpPointer(display, IntPtr.Zero, IntPtr.Zero, 0, 0, 0, 0, x, y);
        XCloseDisplay(display);
        XTestFakeButtonEvent(display, 1, true, 0);
        XTestFakeButtonEvent(display, 1, false, 0);
    }
    public static void Move(uint x, uint y)
    {
        IntPtr display = XOpenDisplay(IntPtr.Zero);
        XWarpPointer(display, IntPtr.Zero, IntPtr.Zero, 0, 0, x, y, 0, 0);
        XFlush(display);
        XCloseDisplay(display);
    }

    private static (int x, int y) GetCursorPosition()
    {
        IntPtr display = XOpenDisplay(IntPtr.Zero);
        IntPtr root;
        int rootX, rootY, winX, winY, mask;
        IntPtr child;
        XQueryPointer(display, IntPtr.Zero, out root, out child, out rootX, out rootY, out winX, out winY, out mask);
        XCloseDisplay(display);
        return (rootX, rootY);
    }

    [DllImport("libX11")]
    private static extern int XFlush(IntPtr display);

    [DllImport("libX11")]
    private static extern IntPtr XOpenDisplay(IntPtr display);

    [DllImport("libX11")]
    private static extern int XCloseDisplay(IntPtr display);

    [DllImport("libX11")]
    private static extern bool XQueryPointer(IntPtr display, IntPtr w, out IntPtr root, out IntPtr child, out int rootX, out int rootY, out int winX, out int winY, out int mask);

    [DllImport("libX11")]
    private static extern void XWarpPointer(IntPtr display, IntPtr src_w, IntPtr dest_w, int src_x, int src_y, uint src_width, uint src_height, int dest_x, int dest_y);

    [DllImport("libXtst")]
    private static extern void XTestFakeButtonEvent(IntPtr display, uint button, bool is_press, uint delay);
}