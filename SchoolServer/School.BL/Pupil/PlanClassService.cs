namespace School.BL.Pupil
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using School.Abstract;
    using School.Database;

    public class PlanClassService : CrudService<PlanClass>
    {
        public PlanClassService(SchoolContext context)
            : base(context)
        {
        }

        /// <inheritdoc cref="CreateAsync"/>
        public override async Task<string> CreateAsync(PlanClass model)
        {
            var id = Guid.NewGuid().ToString();
            Context.Add(model);
            await Context.SaveChangesAsync();
            return id;
        }

        /// <inheritdoc cref="DeleteAsync"/>
        public override async Task DeleteAsync(string id)
        {
            var planClass = await Context.PlanClasses.SingleOrDefaultAsync(x => x.Id == id);
            if (planClass == default)
                throw new ApplicationException("Не удалось найти организацию.");

            Context.Remove(planClass);
            await Context.SaveChangesAsync();
        }

        /// <inheritdoc cref="ReadAsync"/>
        public override async Task<PlanClass> ReadAsync(string id)
        {
            var planClass = await Context.PlanClasses.AsNoTrackingWithIdentityResolution().Include(x => x.Class).
                                          Include(x => x.SubjectPlans).SingleOrDefaultAsync(x => x.Id == id);
            if (planClass == default)
                throw new ApplicationException("Не удалось найти организацию.");

            return planClass;
        }

        /// <inheritdoc cref="UpdateAsync"/>
        public override Task UpdateAsync(PlanClass model)
        {
            throw new NotImplementedException();
        }
    }
}