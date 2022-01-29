using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
namespace Phoenix
{
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


            gameWindow.UpdateFrame += WindowUpdateFrame;
            gameWindow.Load += WindowLoad;
            gameWindow.Unload += WindowClose;
            gameWindow.Resize += WindowResize;
        }

        public static event Action<FrameEventArgs> UpdateFrame;
        public static event Action Load;
        public static event Action Close;
        public static event Action<ResizeEventArgs> Resize;


        private static void WindowUpdateFrame(FrameEventArgs e)
        {
            UpdateFrame?.Invoke(e);
        }
        private static void WindowLoad()
        {
            Log.Trace("Window Loaded");
            Load?.Invoke();
        }
        private static void WindowClose()
        {
            Log.Trace("Window Closed");
            Close?.Invoke();
            
        }
        private static void WindowResize(ResizeEventArgs e)
        {
            Log.Trace("Window Resized - Width: {0}, Height: {1}", e.Width.ToString(), e.Height.ToString());
            Resize?.Invoke(e);
        }
    }
}


