using OpenTK.Windowing.Desktop;

namespace Phoenix
{
    public class GameWindow : OpenTK.Windowing.Desktop.GameWindow
    {
        public GameWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {

        }
    }
}
