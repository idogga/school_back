using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using School.Database;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class QueryExtension
    {
        public static async Task<T> FirstOrFail<T>(
               this DbSet<T> query,
               Expression<Func<T, bool>> predicate)
               where T : class
        {
            var result = await query.FirstOrDefaultAsync(predicate);

            if (result == default)
            {
                throw new NotFoundEntityException(typeof(T));
            }

            return result;
        }

        public static async Task<T> FirstOrFail<T, TProperty>(
            this IIncludableQueryable<T, TProperty> query,
            Expression<Func<T, bool>> predicate)
            where T : class
        {
            var result = await query.FirstOrDefaultAsync(predicate);

            if (result == default)
            {
                throw new NotFoundEntityException(typeof(T));
            }

            return result;
        }

        public static async Task<T> FirstOrFail<T>(
           this IQueryable<T> query,
           Expression<Func<T, bool>> predicate)
           where T : class
        {
            var result = await query.FirstOrDefaultAsync(predicate);

            if (result == default)
            {
                throw new NotFoundEntityException(typeof(T));
            }

            return result;
        }

        public static T FirstOrFail<T>(
            this IEnumerable<T> query,
            Func<T, bool> predicate)
            where T : class
        {
            var result = query.FirstOrDefault(predicate);

            if (result == default)
            {
                throw new NotFoundEntityException(typeof(T));
            }

            return result;
        }

        public static async Task<T> FindOrFailAsync<T>(
            this DbSet<T> query,
            Guid id)
            where T : class
        {
            var result = await query.FindAsync(id);

            if (result == default)
            {
                throw new NotFoundEntityException(typeof(T), id);
            }

            return result;
        }

        public static async Task<T> FindOrFailAsync<T>(
            this DbSet<T> query,
            string id)
            where T : class
        {
            var result = await query.FindAsync(id);

            if (result == default)
            {
                throw new NotFoundEntityException(typeof(T), id);
            }

            return result;
        }
    }


}
