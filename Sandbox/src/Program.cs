using OpenTK.Windowing.Desktop;

namespace Sandbox
{
    public class Program
    {
        static void Main()
        {
            GameWindow window = new (GameWindowSettings.Default, NativeWindowSettings.Default);

            Log.Init(NLog.LogLevel.Trace);
            Events.Init(ref window);

            window.Run();
        }
    }
}