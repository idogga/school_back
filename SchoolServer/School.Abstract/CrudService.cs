namespace School.Abstract
{
    using System.Threading.Tasks;

    using School.Database;

    public abstract class CrudService<T>
    {
        protected CrudService(SchoolContext context)
        {
            Context = context;
        }

        protected SchoolContext Context { get; set; }

        public abstract Task<string> CreateAsync(T model);

        public abstract Task DeleteAsync(string id);

        public abstract Task<T> ReadAsync(string id);

        public abstract Task UpdateAsync(T model);
    }
}