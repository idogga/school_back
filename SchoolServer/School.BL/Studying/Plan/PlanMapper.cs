using School.Abstract;
using School.Database;
using School.Dto.Plans;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BL.Studying.Plan
{
    /// <summary>
    /// Маппер для перегона файлов в <see cref="PlanClass"/>.
    /// </summary>
    public class PlanMapper : MapperService<PlanDto, PlanClass>
    {
        /// <inheritdoc/>
        public override PlanDto ConvertToDto(PlanClass model)
        {
            return new PlanDto
            {
                ClassId = model.Class.Id,
                Id = model.Id,
                SubjectPlanIds = model.SubjectPlans.Select(x => x.Id).ToList()
            };
        }

        /// <inheritdoc/>
        public override PlanClass ConvertToModel(PlanDto dto)
        {
            var list = dto.SubjectPlanIds.Select(x => new SubjectPlan { Id = x }).ToList();
            return new PlanClass
            {
                Id = dto.Id,
                SubjectPlans = new Collection<SubjectPlan>(list)
            };
        }
    }
}
