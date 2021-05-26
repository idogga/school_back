namespace School.BL.Studying
{
    using System;
    using System.Threading.Tasks;

    using School.Abstract;
    using School.Database;

    public class SubjectService : CrudService<Subject>
    {
        public SubjectService(SchoolContext context)
            : base(context)
        {
        }

        public override Task<Guid> CreateAsync(Subject model)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<Subject> ReadAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(Subject model)
        {
            throw new NotImplementedException();
        }
    }
}