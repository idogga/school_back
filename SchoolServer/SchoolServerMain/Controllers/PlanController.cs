using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Abstract;
using School.BL.Studying.Plan;
using School.Database;
using School.Dto.Plans;

namespace SchoolServerMain.Controllers
{
    /// <summary>
    /// Контроллер для работы с планами.
    /// </summary>
    [Route("api/[controller]")]
    public class PlanController : CrudController<CreatePlanDto, PlanDto, PlanClass>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public PlanController(IMapper mapper, PlanService service)
            : base(mapper, service)
        {
        }
    }
}