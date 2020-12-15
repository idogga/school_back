namespace School.BL.Professor
{
    using System;

    using School.AbstractService;
    using School.Dto;

    public class TeacherMapper : MapperService<TeacherDto, Teacher>
    {
        public override TeacherDto ConvertToDto(Teacher model)
        {
            throw new NotImplementedException();
        }

        public override Teacher ConvertToModel(TeacherDto dto)
        {
            throw new NotImplementedException();
        }
    }
}