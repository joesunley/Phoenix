using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

public class Events
{
    public static event Action<KeyboardKeyEventArgs> KeyDown;
    public static event Action<KeyboardKeyEventArgs> KeyUp;

    public static event Action<MouseButtonEventArgs> MouseDown;
    public static event Action<MouseButtonEventArgs> MouseUp;

    public static event Action<MouseMoveEventArgs> MouseMove;

    public static event Action<MouseWheelEventArgs> MouseWheel;


    public static void Init(ref GameWindow gameWindow)
    {
        gameWindow.KeyDown += WindowKeyDown;
        gameWindow.KeyUp += WindowKeyUp;
        gameWindow.MouseDown += WindowMouseDown;
        gameWindow.MouseUp += WindowMouseUp;
        gameWindow.MouseMove += WindowMouseMove;
        gameWindow.MouseWheel += WindowMouseWheel;
    }


    private static void WindowKeyDown(KeyboardKeyEventArgs e)
    {
        Log.Trace("Key Pressed: '{0}'", e.Key.ToString());
        KeyDown?.Invoke(e);
    }
    private static void WindowKeyUp(KeyboardKeyEventArgs e)
    {
        Log.Trace("Key Released: '{0}'", e.Key.ToString());
        KeyUp?.Invoke(e);
    }
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