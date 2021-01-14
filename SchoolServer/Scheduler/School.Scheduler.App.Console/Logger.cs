namespace School.Scheduler.App.Console
{
    using System;

    public class Logger
    {
        public static void Write(string message, string tag = null)
        {
            tag = tag ?? "MSG";
            Console.WriteLine($"{tag}: {message}");
        }

        public static void Write(Exception exception)
        {
            var oldColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERRS: {exception}");
            Console.BackgroundColor = oldColor;
        }
    }
}