using OpenTK;
using OpenTK.Graphics;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Phoenix
{
    public class Application
    {
        //private NativeWindowSettings _nativeSettings;
        //private GameWindowSettings _windowSettings;

        public Application()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 600),
                Title = "LearnOpenTK - Creating a Window",
                // This is needed to run on macos
                Flags = ContextFlags.ForwardCompatible,
            };

            GameWindow window = new(GameWindowSettings.Default, nativeWindowSettings);
            
            Events.Init(ref window);
            window.Run();
        }

        
    }

    
}
