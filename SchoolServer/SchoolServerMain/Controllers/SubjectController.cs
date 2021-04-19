namespace SchoolServerMain.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using School.Abstract;
    using School.BL.Studying;
    using School.Database;
    using School.Dto;

    [Route("api/[controller]")]
    public class SubjectController : CrudController<SubjectDto, Subject>
    {
        public SubjectController(SubjectMapper mapper, SubjectService service)
            : base(mapper, service)
        {
        }
    }
}