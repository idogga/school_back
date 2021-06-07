namespace SchoolServerMain.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using School.Abstract;
    using School.BL.Studying;
    using School.Database;
    using School.Dto;
    using School.Dto.Subjects;

    [Route("api/[controller]")]
    public class SubjectController : CrudController<CreateSubjectDto, SubjectDto, Subject>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public SubjectController(IMapper mapper, SubjectService service)
            : base(mapper, service)
        {
        }
    }
}