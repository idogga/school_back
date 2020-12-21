namespace School.BL.Studying
{
    using System;
    using System.Threading.Tasks;

    using School.AbstractService;
    using School.Database;

    public class SubjectService : CrudService<Subject>
    {
        public override Task<string> CreateAsync(Subject model)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<Subject> ReadAsync(string id)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(Subject model)
        {
            throw new NotImplementedException();
        }
    }
}