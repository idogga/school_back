namespace School.BL.Professor
{
    using System;
    using System.Threading.Tasks;

    using School.AbstractService;

    public class TeacherService : CrudService<Teacher>
    {
        public override Task<string> CreateAsync(Teacher model)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<Teacher> ReadAsync(string id)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(Teacher model)
        {
            throw new NotImplementedException();
        }
    }
}