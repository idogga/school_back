namespace School.BL.Pupil
{
    using System;
    using System.Threading.Tasks;

    using School.Abstract;
    using School.Database;

    public class ClassService : CrudService<Class>
    {
        public ClassService(SchoolContext context)
            : base(context)
        {
        }

        public override Task<string> CreateAsync(Class model)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<Class> ReadAsync(string id)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(Class model)
        {
            throw new NotImplementedException();
        }
    }
}