namespace School.BL.Professor
{
    using AutoMapper;
    using School.Abstract;
    using School.Database;
    using School.Dto;
    using System.Linq;

    public class TeacherMapper : Profile, IMapperBuilder
    {
        public TeacherMapper()
        {
            CreateMap<Teacher, TeacherDto>()
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.Subjects.Select(s => s.Id)));

            CreateMap<TeacherDto, Teacher>();
        }

        public Profile Build()
        {
            return this;
        }
    }
}