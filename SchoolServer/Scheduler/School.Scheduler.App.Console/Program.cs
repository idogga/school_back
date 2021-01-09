using System;


namespace School.Scheduler.App.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Write("Start console app");
            try
            {
                AddServices();
            }
            catch(Exception e)
            {
                Logger.Write(e);
            }
        }

        private static void AddServices()
        {
            Logger.Write("Add services");
            var startUp = new Startup(null);
        }
    }
}
