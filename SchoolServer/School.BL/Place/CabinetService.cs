namespace School.BL.Place
{
    using System;
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
        public override async Task<string> CreateAsync(Cabinete model)
        {
            var alreadyContains =
                await Context.Cabinetes.AnyAsync(x => x.Name.Equals(model.Name, StringComparison.CurrentCultureIgnoreCase));
            if (alreadyContains)
                throw new ApplicationException("Кабинет с таким наименованием уже существует");

            model.Id = Guid.NewGuid().ToString();
            Context.Add(model);
            await Context.SaveChangesAsync();
            return model.Id;
        }

        /// <inheritdoc cref="DeleteAsync"/>
        public override async Task DeleteAsync(string id)
        {
            var cabinet = await Context.Cabinetes.SingleOrDefaultAsync(x => x.Id == id);
            if (cabinet == default)
                throw new ApplicationException("Кабинет с таким идентификатором не существует.");

            Context.Remove(cabinet);
            await Context.SaveChangesAsync();
        }

        /// <inheritdoc cref="ReadAsync"/>
        public override async Task<Cabinete> ReadAsync(string id)
        {
            var cabinet = await Context.Cabinetes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            if (cabinet == default)
                throw new ApplicationException("Кабинет с таким идентификатором не существует.");

            return cabinet;
        }

        /// <inheritdoc cref="UpdateAsync"/>
        public override Task UpdateAsync(Cabinete model)
        {
            throw new NotImplementedException();
        }
    }
}