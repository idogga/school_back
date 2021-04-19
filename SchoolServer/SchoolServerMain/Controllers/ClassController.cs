namespace SchoolServerMain.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using School.Abstract;
    using School.BL.Pupil;
    using School.Database;
    using School.Dto;

    [Route("api/[controller]")]
    public class ClassController : CrudController<ClassDto, Class>
    {
        public ClassController(ClassMapper mapper, ClassService service)
            : base(mapper, service)
        {
        }
    }
}