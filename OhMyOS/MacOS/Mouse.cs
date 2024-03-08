using System;
using System.Runtime.InteropServices;

namespace OhMyOS.MacOS;

public static class Mouse
{
    public static void Click(int x, int y)
    {
        IntPtr mouseDownRef = CGEventCreateMouseEvent(
            IntPtr.Zero,
            CGEventType.LeftMouseDown,
            new CGPoint(x, y),
            CGMouseButton.Left);
        IntPtr mouseUpRef = CGEventCreateMouseEvent(
            IntPtr.Zero,
            CGEventType.LeftMouseUp,
            new CGPoint(x, y),
            CGMouseButton.Left);

        CGEventPost(CGEventTapLocation.Session, mouseDownRef);
        CFRelease(mouseDownRef);
        CGEventPost(CGEventTapLocation.Session, mouseUpRef);
        CFRelease(mouseUpRef);
    }
    public static void Move(int x, int y)
    {
        CGPoint newCursorPosition = new CGPoint(x, y);
        CGWarpMouseCursorPosition(newCursorPosition);
    }

    [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
    private static extern IntPtr CGEventCreateMouseEvent(
        IntPtr mouseEventSource,
        CGEventType mouseType,
        CGPoint mouseCursorPosition,
        CGMouseButton mouseButton);

    [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
    private static extern void CGEventPost(CGEventTapLocation tap, IntPtr evt);

    [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
    private static extern void CFRelease(IntPtr cf);

    [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
    private static extern void CGWarpMouseCursorPosition(CGPoint newCursorPosition);
}