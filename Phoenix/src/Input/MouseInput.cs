using OpenTK.Windowing.Common;


public partial class Events
{
    public static event Action<MouseButtonEventArgs>? MouseDown;
    public static event Action<MouseButtonEventArgs>? MouseUp;
    public static event Action<MouseMoveEventArgs>? MouseMove;
    public static event Action<MouseWheelEventArgs>? MouseWheel;


    private static void WindowMouseDown(MouseButtonEventArgs e)
    {
        Log.Trace("Mouse Down: '{0}'", e.Button.ToString());
        MouseDown?.Invoke(e);
    }
    private static void WindowMouseUp(MouseButtonEventArgs e)
    {
        Log.Trace("Mouse Button Released: '{0}", e.Button.ToString());
        MouseUp?.Invoke(e);
    }
    private static void WindowMouseMove(MouseMoveEventArgs e)
    {
        Log.Trace("Mouse Moved. New Position: {0}, {1}", e.X, e.Y);
        MouseMove?.Invoke(e);
    }
    private static void WindowMouseWheel(MouseWheelEventArgs e)
    {
        Log.Trace("Mouse Wheel Moved: X: {0}, Y: {0}", e.OffsetX, e.OffsetY);
        MouseWheel?.Invoke(e);
    }
}