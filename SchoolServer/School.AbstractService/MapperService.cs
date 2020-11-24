using System;
using System.Collections.Generic;
using System.Text;

namespace School.AbstractService
{
    public abstract class MapperService<TDto, TModel>
    {
        public abstract TDto ConvertToDto(TModel model);

        public abstract TModel ConvertToModel(TDto dto);
    }
}
