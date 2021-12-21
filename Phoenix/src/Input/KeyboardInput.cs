using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

public partial class Events
{
    public static event Action<KeyboardKeyEventArgs> KeyDown;
    public static event Action<KeyboardKeyEventArgs> KeyUp;

    internal static Keys? s_CurrentPressedKey = null;

    private static void WindowKeyDown(KeyboardKeyEventArgs e)
    {
        Log.Trace("Key Pressed: '{0}'", e.Key.ToString());

        s_CurrentPressedKey = e.Key;
        KeyDown?.Invoke(e);
    }
    private static void WindowKeyUp(KeyboardKeyEventArgs e)
    {
        Log.Trace("Key Released: '{0}'", e.Key.ToString());

        s_CurrentPressedKey = null;
        KeyUp?.Invoke(e);
    }
}

namespace Phoenix.Input
{
    public class Keyboard
    {
        public static bool IsKeyPressed(Keys key)
        {
            return (Events.s_CurrentPressedKey != null) ? (key == Events.s_CurrentPressedKey) : false;
        }
        public static bool IsAnyKeyPressed()
        {
            return Events.s_CurrentPressedKey != null;
        }
    }
}