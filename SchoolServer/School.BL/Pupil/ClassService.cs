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

        public override Task<Guid> CreateAsync(Class model)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<Class> ReadAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(Class model)
        {
            throw new NotImplementedException();
        }
    }
}