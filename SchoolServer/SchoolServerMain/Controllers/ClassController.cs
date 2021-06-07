namespace SchoolServerMain.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using School.Abstract;
    using School.BL.Pupil;
    using School.Database;
    using School.Dto;
    using School.Dto.Classes;

    [Route("api/[controller]")]
    public class ClassController : CrudController<CreateClassDto, ClassDto, Class>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public ClassController(IMapper mapper, ClassService service)
            : base(mapper, service)
        {
        }
    }
}