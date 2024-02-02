namespace financial_management_api.Api.Utilities
{
    public class Logger
    {
        private static readonly object LockObject = new object();

        public static void LogInfo(string message)
        {
            Log(ConsoleColor.Green, "INFO", message);
        }

        public static void LogWarning(string message)
        {
            Log(ConsoleColor.Yellow, "WARNING", message);
        }

        public static void LogError(string message)
        {
            Log(ConsoleColor.Red, "ERROR", message);
        }

        public static void LogException(Exception ex)
        {
            LogError($"Exception: {ex.Message}\nStackTrace: {ex.StackTrace}");
        }

        private static void Log(ConsoleColor color, string logLevel, string message)
        {
            lock (LockObject)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{DateTime.Now} [{logLevel}]: {message}");
                Console.ResetColor();
            }
        }
    }
}
