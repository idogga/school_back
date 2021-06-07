using AutoMapper;
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
    public class PlanMapper : Profile, IMapperBuilder
    {
        public PlanMapper()
        {
            CreateMap<PlanClass, PlanDto>()
                .ForMember(dest => dest.SubjectPlanIds, opt => opt.MapFrom(src => src.SubjectPlans.Select(s => s.Id)))
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.Class.Id));
            CreateMap<PlanDto, PlanClass>();
        }

        public Profile Build()
        {
            return this;
        }
    }
}
