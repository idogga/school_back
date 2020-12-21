namespace SchoolServerMain
{
    using System;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using School.Database;

    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            MigrateDatabase(host.Services);
            host.Run();
        }

        /// <summary>
        /// Миграция БД.
        /// </summary>
        /// <param name="serviceProvider">Провайдер сервисов.</param>
        private static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<SchoolContext>();
                var migrations = dbContext.Database.GetPendingMigrations();

                foreach (var migration in migrations)
                {
                    Console.WriteLine($"[x] Применение миграции: {migration}");
                }

                dbContext.Database.Migrate();
            }
        }
    }
}