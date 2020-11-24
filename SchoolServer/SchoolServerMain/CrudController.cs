namespace SchoolServerMain
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using School.AbstractService;

    public abstract class CrudController<TDto, TModel> : ControllerBase
    {
        protected readonly MapperService<TDto, TModel> _mapper;

        protected readonly CrudService<TModel> _service;

        public CrudController(MapperService<TDto, TModel> mapper, CrudService<TModel> service)
        {
            _mapper = mapper;
            _service = service;
        }

        public virtual Task<string> CreateAsync(TDto dto)
        {
            var model = _mapper.ConvertToModel(dto);
            return _service.CreateAsync(model);
        }

        public virtual Task DeleteAsync(string id)
        {
            return _service.DeleteAsync(id);
        }

        public virtual async Task<TDto> ReadAsync(string id)
        {
            var model = await _service.ReadAsync(id);
            return _mapper.ConvertToDto(model);
        }

        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            var modelToUpdate = _mapper.ConvertToModel(dto);
            var model = await _service.UpdateAsync(modelToUpdate);
            return _mapper.ConvertToDto(model);
        }
    }
}