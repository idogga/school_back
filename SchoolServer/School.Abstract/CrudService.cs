namespace School.Abstract
{
    using System;
    using System.Threading.Tasks;

    using School.Database;

    public abstract class CrudService<T>
    {
        protected CrudService(SchoolContext context)
        {
            Context = context;
        }

        protected SchoolContext Context { get; set; }

        public abstract Task<Guid> CreateAsync(T model);

        public abstract Task DeleteAsync(Guid id);

        public abstract Task<T> ReadAsync(Guid id);

        public abstract Task UpdateAsync(T model);
    }
}