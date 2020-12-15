using System;
using System.Collections.Generic;
using System.Text;

namespace School.AbstractService
{
    using System.Threading.Tasks;

    public abstract class CrudService<T>
    {
        public abstract Task<string> CreateAsync(T model);

        public abstract Task<T> ReadAsync(string id);

        public abstract Task UpdateAsync(T model);

        public abstract Task DeleteAsync(string id);
    }
}
