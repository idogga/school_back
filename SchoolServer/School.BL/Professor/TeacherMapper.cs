namespace School.BL.Professor
{
    using School.Abstract;
    using School.Database;
    using School.Dto;

    public class TeacherMapper : MapperService<TeacherDto, Teacher>
    {
        public override TeacherDto ConvertToDto(Teacher model)
        {
            return new TeacherDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public override Teacher ConvertToModel(TeacherDto dto)
        {
            return new Teacher
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}