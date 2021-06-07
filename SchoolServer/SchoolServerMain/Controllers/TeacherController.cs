namespace SchoolServerMain.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using School.Abstract;
    using School.BL.Professor;
    using School.Database;
    using School.Dto;
    using School.Dto.Teachers;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class TeacherController : CrudController<CreateTeacherDto, TeacherDto, Teacher>
    {
        /// <summary>
        /// КОнчтруктор.
        /// </summary>
        public TeacherController(IMapper mapper, TeacherService service)
            : base(mapper, service)
        {
        }

        /// <summary>
        /// Добавить предмет учителю.
        /// </summary>
        /// <param name="teacherId">Идентификатор учителя.</param>
        /// <param name="subjectId">Идентификатор предмета.</param>
        /// <returns></returns>
        [HttpPost("{teacherId}/subjects")]
        public Task AddSubjectAsync(Guid teacherId, [FromBody] Guid subjectId)
        {
            return (_service as TeacherService).AddSubjectAsync(teacherId, subjectId);
        }

        /// <summary>
        /// Удалить предмет из списка.
        /// </summary>
        /// <param name="teacherId">Идентифкатор учителя.</param>
        /// <param name="subjectId">Идентификатор предмета.</param>
        /// <returns></returns>
        [HttpDelete("{teacherId}/subjects/{subjectId}")]
        public Task DeleteSubjectAsync(Guid teacherId, Guid subjectId)
        {
            return (_service as TeacherService).DeleteSubjectAsync(teacherId, subjectId);
        }
    }
}