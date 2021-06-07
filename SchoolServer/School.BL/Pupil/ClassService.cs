namespace School.BL.Pupil
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using School.Abstract;
    using School.Database;

    public class ClassService : CrudService<Class>
    {
        public ClassService(SchoolContext context)
            : base(context)
        {
        }

        public override async Task<Guid> CreateAsync(Class model)
        {
            model.Id = Guid.NewGuid();
            if (model.Grade < 0)
                throw new ApplicationException("Grade must be under 0");

            await Context.Classes.AddAsync(model);
            await Context.SaveChangesAsync();
            return model.Id;
        }

        public override async Task DeleteAsync(Guid id)
        {
            var oldClass = await Context.Classes.FindOrFailAsync(id);
            Context.Classes.Remove(oldClass);
            await Context.SaveChangesAsync();
        }

        public override async Task<Class> ReadAsync(Guid id)
        {
            var oldClass = await Context.Classes.AsNoTracking().FirstOrFail(c => c.Id == id);
            return oldClass;
        }

        public override async Task UpdateAsync(Class model)
        {
            var oldClass = await Context.Classes.FirstOrFail(c => c.Id == model.Id);
            oldClass.Grade = model.Grade;
            oldClass.Litera = model.Litera;
            await Context.SaveChangesAsync();
        }
    }
}