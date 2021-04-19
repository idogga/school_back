using Microsoft.EntityFrameworkCore;
using School.Abstract;
using School.Database;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace School.BL.Studying.Plan
{
    /// <summary>
    /// Сервис для работы с <see cref="PlanClass"/>.
    /// </summary>
    public class PlanService : CrudService<PlanClass>
    {
        /// <summary>
        /// Консруктор.
        /// </summary>
        public PlanService(SchoolContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public override async Task<string> CreateAsync(PlanClass model)
        {
            var guid = Guid.NewGuid().ToString();
            model.Id = guid;

            var clas = await Context.Classes.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (clas == default)
                throw new NotFoundEntityException(typeof(Class), model.Id);

            model.Class = clas;

            var plans = await Context.SubjectPlans.Where(plan => model.SubjectPlans.Any(exists => exists.Id == plan.Id)).ToListAsync();
            if (!plans.Any())
                throw new NotFoundEntityException(typeof(SubjectPlan), $"{string.Join(", ", model.SubjectPlans.Select(x => x.Id))}");

            model.SubjectPlans = new Collection<SubjectPlan>(plans);
            
            Context.Add(model);
            await Context.SaveChangesAsync();

            return guid;
        }

        /// <inheritdoc/>
        public override async Task DeleteAsync(string id)
        {
            var model = await Context.PlanClasses.FirstOrDefaultAsync(x => x.Id == id);
            if (model == default)
                throw new NotFoundEntityException(typeof(PlanClass), id);

            Context.Remove(model);
            await Context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public override async Task<PlanClass> ReadAsync(string id)
        {
            var model = await Context.PlanClasses
                .Include(x => x.Class)
                .Include(x => x.SubjectPlans)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == default)
                throw new NotFoundEntityException(typeof(PlanClass), id);

            return model;
        }

        /// <inheritdoc/>
        public override Task UpdateAsync(PlanClass model)
        {
            throw new NotImplementedException();
        }
    }
}
