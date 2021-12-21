using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

public partial class Events
{
    public static event Action<KeyboardKeyEventArgs> KeyDown;
    public static event Action<KeyboardKeyEventArgs> KeyUp;


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
}