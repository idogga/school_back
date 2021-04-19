namespace SchoolServerMain.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using School.Abstract;
    using School.BL.Professor;
    using School.Database;
    using School.Dto;

    [Route("api/[controller]")]
    public class TeacherController : CrudController<TeacherDto, Teacher>
    {
        public TeacherController(TeacherMapper mapper, TeacherService service)
            : base(mapper, service)
        {
        }
    }
}