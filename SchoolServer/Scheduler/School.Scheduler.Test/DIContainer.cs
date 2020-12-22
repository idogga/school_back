namespace School.Scheduler.Test
{
    using System;
    using System.Diagnostics;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using School.Scheduler.Database;

    public static class DIContainer
    {
        static DIContainer()
        {
            var services = new ServiceCollection();
            const string sqlConnectionString =
                "User ID=postgres;Password=550248qweR;Host=localhost;Port=5432;Database=test_schedule;Pooling=true;";

            services.AddDbContext<ScheduleContext>(
                options =>
                    options.UseNpgsql(sqlConnectionString).ConfigureWarnings(x => Debug.WriteLine($"Ошибка БД: {x}")));

            ServiceProvider = services.BuildServiceProvider();
            MigrateDatabase(ServiceProvider);
        }

        public static IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Миграция БД.
        /// </summary>
        /// <param name="serviceProvider">Провайдер сервисов.</param>
        private static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<ScheduleContext>();
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