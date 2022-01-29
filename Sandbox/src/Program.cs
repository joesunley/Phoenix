using Phoenix;

namespace Sandbox
{
    public class Program
    {
        static void Main()
        {
            Log.Init(NLog.LogLevel.Trace);
            Application application = new Application();
        }

    }

    

}