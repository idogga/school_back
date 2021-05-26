namespace School.BL.Professor
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using School.Abstract;
    using School.Database;

    public class TeacherService : CrudService<Teacher>
    {
        public TeacherService(SchoolContext context)
            : base(context)
        {
        }

        public override async Task<Guid> CreateAsync(Teacher model)
        {
            model.Id = Guid.NewGuid();
            if (string.IsNullOrEmpty(model.Name))
                throw new Exception("oh name");

            await Context.Teachers.AddAsync(model);
            await Context.SaveChangesAsync();
            return model.Id;
        }

        public override async Task DeleteAsync(Guid id)
        {
            var entity = await Context.Teachers.FindOrFailAsync(id);

            Context.Teachers.Remove(entity);

            await Context.SaveChangesAsync();
        }

        public override async Task<Teacher> ReadAsync(Guid id)
        {
            var entity = await Context.Teachers
                .Include(t => t.Subjects)
                .FirstOrFail(t => t.Id == id);

            return entity;

        }

        public override async Task UpdateAsync(Teacher model)
        {
            var oldTeacher = await Context.Teachers.FirstOrFail(t => t.Id == model.Id);
            oldTeacher.Name = model.Name;

            await Context.SaveChangesAsync();
        }

        public async Task AddSubjectAsync(Guid teacherId, Guid subjectId)
        {
            var entity = await Context.Teachers
                .Include(t => t.Subjects)
                .FirstOrFail(t => t.Id == teacherId);

            if (entity.Subjects.Any(s => s.Id == subjectId))
                throw new ApplicationException("Предмет с таким идентификатором уже содержится.");

            var subject = await Context.Subjects.FindOrFailAsync(subjectId);
            entity.Subjects.Add(subject);
            await Context.SaveChangesAsync();
        }
    }
}