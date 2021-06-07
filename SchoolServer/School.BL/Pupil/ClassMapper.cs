namespace School.BL.Pupil
{
    using AutoMapper;
    using School.Abstract;
    using School.Database;
    using School.Dto;
    using School.Dto.Classes;

    public class ClassMapper : Profile, IMapperBuilder
    {
        public ClassMapper()
        {
            CreateMap<Class, ClassDto>();
            CreateMap<ClassDto, Class>();
            CreateMap<CreateClassDto, Class>();
        }

        public Profile Build()
        {
            return this;
        }
    }
}