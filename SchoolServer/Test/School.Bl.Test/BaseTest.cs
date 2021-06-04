namespace School.Bl.Test
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.EntityFrameworkCore.Storage;

    using NUnit.Framework;

    using School.Database;

    public abstract class BaseTest
    {
        private static readonly IDictionary<string, InMemoryDatabaseRoot> DbRootsCache =
            new ConcurrentDictionary<string, InMemoryDatabaseRoot>();

        protected SchoolContext Context { get; private set; }

        public virtual void StartAllServices()
        {
            var dbName = Guid.NewGuid().ToString();

            var opts = new DbContextOptionsBuilder<SchoolContext>()
                .UseInMemoryDatabase(dbName, GetOrCreateRoot(dbName))
                .EnableServiceProviderCaching(false)
                .ConfigureWarnings(b =>
                    b.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning));

            Context = new SchoolContext(opts.Options);
            Context.Database.EnsureCreated();
        }

        [TearDown]
        public void StopAllServices()
        {
            Context?.Database.EnsureDeleted();
            Context?.Dispose();
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
    }
}