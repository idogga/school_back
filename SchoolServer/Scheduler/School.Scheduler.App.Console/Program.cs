namespace School.Scheduler.App.Console
{
    using System;

    internal class Program
    {
        private static void AddServices()
        {
            Logger.Write("Add services");
            var startUp = new Startup(null);
        }

        private static void Main(string[] args)
        {
            Logger.Write("Start console app");
            try
            {
                AddServices();
            }
            catch (Exception e)
            {
                Logger.Write(e);
            }
        }
    }
}