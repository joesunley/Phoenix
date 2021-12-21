using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

public partial class Events
{
    public static void Init(ref GameWindow gameWindow)
    {
        gameWindow.KeyDown += WindowKeyDown;
        gameWindow.KeyUp += WindowKeyUp;
        gameWindow.MouseDown += WindowMouseDown;
        gameWindow.MouseUp += WindowMouseUp;
        gameWindow.MouseMove += WindowMouseMove;
        gameWindow.MouseWheel += WindowMouseWheel;
    }
}