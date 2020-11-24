using System;
using System.Collections.Generic;
using System.Text;

namespace School.BL
{
    using School.AbstractService;
    using School.Dto;

    public class CabineteMapper: MapperService<CabineteDto, Cabinete>
    {
        public override CabineteDto ConvertToDto(Cabinete model)
        {
            return new CabineteDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public override Cabinete ConvertToModel(CabineteDto dto)
        {
            return new Cabinete
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
