namespace School.BL.Professor
{
    using System;
    using System.Threading.Tasks;

    using School.Abstract;
    using School.Database;

    public class TeacherService : CrudService<Teacher>
    {
        private readonly SchoolContext _context;

        public TeacherService(SchoolContext context)
        {
            _context = context;
        }

        public override async Task<string> CreateAsync(Teacher model)
        {
            if (!string.IsNullOrEmpty(model.Id))
                throw new Exception("oh id");
            model.Id = Guid.NewGuid().ToString();
            if (string.IsNullOrEmpty(model.Name))
                throw new Exception("oh name");

            await _context.Teachers.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.Id;
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