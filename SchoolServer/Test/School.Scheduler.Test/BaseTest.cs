using System;
using System.Collections.Generic;
using System.Text;

namespace School.Scheduler.Test
{
    using System.Collections.Concurrent;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.EntityFrameworkCore.Storage;

    using NUnit.Framework;

    using School.Database;
    using School.Sheduler.Context;

    class BaseTest
    {
        private static readonly IDictionary<string, InMemoryDatabaseRoot> DbRootsCache =
            new ConcurrentDictionary<string, InMemoryDatabaseRoot>();

        protected SchoolContext SchoolContext { get; private set; }
        protected SchedulerContext ScheduleContext { get; private set; }

        [OneTimeSetUp]
        public void StartAllServices()
        {
            var dbName = Guid.NewGuid().ToString();
         
            var schedulerOptions = GenerateContextOptions<SchedulerContext>(dbName);
            ScheduleContext = new SchedulerContext(schedulerOptions.Options);

            var schoolOptions = GenerateContextOptions<SchoolContext>(dbName);
            SchoolContext = new SchoolContext(schoolOptions.Options);
        }

        [OneTimeTearDown]
        public void StopAllServices()
        {
            SchoolContext.Database.EnsureDeleted();
            ScheduleContext.Database.EnsureDeleted();
        }

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

        private DbContextOptionsBuilder<T> GenerateContextOptions<T>(string dbName) where T: DbContext
        {

            return  new DbContextOptionsBuilder<T>().UseInMemoryDatabase(dbName, GetOrCreateRoot(dbName)).
                                                                    ConfigureWarnings(
                                                                        w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }
    }
}
