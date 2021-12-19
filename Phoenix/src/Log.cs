public static class Log
{
    private static NLog.Logger? s_logger;
    private static bool s_initalised = false;

    public static void Init(NLog.LogLevel? minConsoleLevel = null, NLog.LogLevel? minFileLevel = null)
    {
        var config = new NLog.Config.LoggingConfiguration();
        var logFile = new NLog.Targets.FileTarget("logFile")
        {
            FileName = "log.txt",
            Layout = "[${longdate}] ${message}\t ${stacktrace}",

        };

        var logConsole = new NLog.Targets.ColoredConsoleTarget("logConsole")
        {
            Layout = "[${time}] ${stacktrace} \t: ${message}",
            UseDefaultRowHighlightingRules = true,
        };

        config.AddTarget(logFile);
        config.AddTarget(logConsole);

        config.AddRule(minConsoleLevel ?? NLog.LogLevel.Debug, NLog.LogLevel.Fatal, "logConsole");
        config.AddRule(minFileLevel ?? NLog.LogLevel.Info, NLog.LogLevel.Fatal, "logFile");

        NLog.LogManager.Configuration = config;

        s_initalised = true;
        s_logger = NLog.LogManager.GetCurrentClassLogger();

    }

#pragma warning disable CS8602 // Dereference of a possibly null reference.

    public static void Trace(string format, params object?[] args)
    {
        if (s_initalised)
            s_logger.Trace(format, args);
    }
    public static void Debug(string format, params object?[] args)
    {
        if (s_initalised)
            s_logger.Debug(format, args);
    }
    public static void Info(string format, params object?[] args)
    {
        if (s_initalised)
            s_logger.Info(format, args);
    }
    public static void Warn(string format, params object?[] args)
    {
        if (s_initalised)
            s_logger.Warn(format, args);
    }
    public static void Error(string format, params object?[] args)
    {
        if (s_initalised)
            s_logger.Error(format, args);
    }
    public static void Fatal(string format, params object?[] args)
    {
        if (s_initalised)
            s_logger.Fatal(format, args);
    }

#pragma warning restore CS8602 // Dereference of a possibly null reference.

}