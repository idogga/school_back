namespace School.Scheduler.Test
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.DependencyInjection;

    using School.Scheduler.Database;

    public static class DIContainer
    {
        private static readonly IDictionary<string, InMemoryDatabaseRoot> DbRootsCache =
            new ConcurrentDictionary<string, InMemoryDatabaseRoot>();

        static DIContainer()
        {
            var services = new ServiceCollection();
            const string dbName = " aaaaaaaaaaaaa";

            services.AddDbContext<ScheduleContext>(
                options =>
                    options.UseInMemoryDatabase(dbName, GetOrCreateRoot(dbName)).
                            ConfigureWarnings(x => Debug.WriteLine($"Ошибка БД: {x}")));

            ServiceProvider = services.BuildServiceProvider();
            MigrateDatabase(ServiceProvider);
        }

        public static IServiceProvider ServiceProvider { get; }

        /// <summary>
        ///     Создание или взятие из кэша корня инмемори БД.
        /// </summary>
        /// <param name="dbName"> Имя БД. </param>
        /// <returns></returns>
        private static InMemoryDatabaseRoot GetOrCreateRoot(string dbName)
        {
            if (!DbRootsCache.TryGetValue(dbName, out _))
                DbRootsCache.TryAdd(dbName, new InMemoryDatabaseRoot());

            return DbRootsCache[dbName];
        }

        /// <summary>
        /// Миграция БД.
        /// </summary>
        /// <param name="serviceProvider">Провайдер сервисов.</param>
        private static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<ScheduleContext>();
                if (dbContext.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
                    return;

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