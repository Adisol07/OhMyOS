using System.Runtime.InteropServices;

namespace OhMyOS.MacOS;

[StructLayout(LayoutKind.Sequential)]
public struct CGRect
{
    public double x;
    public double y;
    public double width;
    public double height;
}