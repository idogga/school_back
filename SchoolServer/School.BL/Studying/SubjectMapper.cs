namespace School.BL.Studying
{
    using System;

    using School.AbstractService;
    using School.Dto;

    public class SubjectMapper : MapperService<SubjectDto, Subject>
    {
        public override SubjectDto ConvertToDto(Subject model)
        {
            throw new NotImplementedException();
        }

        public override Subject ConvertToModel(SubjectDto dto)
        {
            throw new NotImplementedException();
        }
    }
}