namespace School.BL.Place
{
    using AutoMapper;
    using School.Abstract;
    using School.Database;
    using School.Dto;
    using School.Dto.Cabinetes;

    public class CabineteMapper : Profile, IMapperBuilder
    {
        public CabineteMapper()
        {
            CreateMap<Cabinete, CabineteDto>();
            CreateMap<CabineteDto, Cabinete>();
            CreateMap<CreateCabineteDto, Cabinete>();
        }

        public Profile Build()
        {
            return this;
        }
    }
}