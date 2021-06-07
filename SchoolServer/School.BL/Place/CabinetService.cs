namespace School.BL.Place
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using School.Abstract;
    using School.Database;

    public class CabinetService : CrudService<Cabinete>
    {
        public CabinetService(SchoolContext context)
            : base(context)
        {
        }

        /// <inheritdoc cref="CreateAsync"/>
        public override async Task<Guid> CreateAsync(Cabinete model)
        {
            var alreadyContains =
                await Context.Cabinetes.AnyAsync(x => x.Name.Equals(model.Name));
            if (alreadyContains)
                throw new ApplicationException("Кабинет с таким наименованием уже существует");

            model.Id = Guid.NewGuid();
            Context.Add(model);
            await Context.SaveChangesAsync();
            return model.Id;
        }

        /// <inheritdoc cref="DeleteAsync"/>
        public override async Task DeleteAsync(Guid id)
        {
            var cabinet = await Context.Cabinetes.FirstOrFail(x => x.Id == id);
            
            Context.Remove(cabinet);
            await Context.SaveChangesAsync();
        }

        /// <inheritdoc cref="ReadAsync"/>
        public override async Task<Cabinete> ReadAsync(Guid id)
        {
            var cabinet = await Context.Cabinetes.AsNoTracking().FirstOrFail(x => x.Id == id);
            
            return cabinet;
        }

        /// <inheritdoc cref="UpdateAsync"/>
        public override async Task UpdateAsync(Cabinete model)
        {
            var cabinet = await Context.Cabinetes.FirstOrFail(x => x.Id == model.Id);
            cabinet.Name = model.Name;
            await Context.SaveChangesAsync();
        }
    }
}