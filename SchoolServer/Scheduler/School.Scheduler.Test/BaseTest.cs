namespace School.Scheduler.Test
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using NUnit.Framework;

    using School.Scheduler.Database;

    public abstract class BaseTest : IDisposable
    {
        public BaseTest()
        {
            Scope = DIContainer.ServiceProvider.CreateScope();
            Context = (ScheduleContext)DIContainer.ServiceProvider.GetService(typeof(ScheduleContext));
        }

        protected ScheduleContext Context { get; }

        protected IServiceScope Scope { get; }

        public virtual void Dispose()
        {
            Scope.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            Context.Cells.Clear();
            Context.Lessons.Clear();
            Context.UserNotes.Clear();
            Context.SaveChanges();
        }
    }

    public static class DbHelper
    {
        public static void Clear<T>(this DbSet<T> dbSet)
            where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}