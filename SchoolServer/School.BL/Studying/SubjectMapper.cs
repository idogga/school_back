namespace School.BL.Studying
{
    using AutoMapper;
    using School.Abstract;
    using School.Database;
    using School.Dto;
    using School.Dto.Subjects;

    /// <summary>
    /// Маппер для <see cref="Subject"/>.
    /// </summary>
    public class SubjectMapper : Profile, IMapperBuilder
    {
        public SubjectMapper()
        {
            CreateMap<SubjectDto, Subject>();
            CreateMap<CreateSubjectDto, Subject>();
            CreateMap<Subject, SubjectDto>();
        }

        public Profile Build()
        {
            return this;
        }
    }
}