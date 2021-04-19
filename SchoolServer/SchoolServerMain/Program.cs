namespace SchoolServerMain
{
    using System;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using School.Database;
    using School.Sheduler.Context;

    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            MigrateDatabase<SchoolContext>(host.Services);
            MigrateDatabase<SchedulerContext>(host.Services);
            host.Run();
        }

        /// <summary>
        /// �������� ��.
        /// </summary>
        /// <param name="serviceProvider">��������� ��������.</param>
        private static void MigrateDatabase<TDatabase>(IServiceProvider serviceProvider) where TDatabase: DbContext
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<TDatabase>();
                var migrations = dbContext.Database.GetPendingMigrations();

                foreach (var migration in migrations)
                {
                    Console.WriteLine($"[x] ���������� ��������: {migration}");
                }

                dbContext.Database.Migrate();
            }
        }
    }
}