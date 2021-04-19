namespace School.Abstract
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// ffffff
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public abstract class CrudController<TDto, TModel> : ControllerBase
    {
        protected readonly MapperService<TDto, TModel> _mapper;

        protected readonly CrudService<TModel> _service;

        public CrudController(MapperService<TDto, TModel> mapper, CrudService<TModel> service)
        {
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual Task<string> CreateAsync(TDto dto)
        {
            var model = _mapper.ConvertToModel(dto);
            return _service.CreateAsync(model);
        }

        /// <summary>
        /// Удалить.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpDelete]
        public virtual Task DeleteAsync(string id)
        {
            return _service.DeleteAsync(id);
        }

        /// <summary>
        /// Считать.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<TDto> ReadAsync(string id)
        {
            var model = await _service.ReadAsync(id);
            return _mapper.ConvertToDto(model);
        }

        /// <summary>
        /// Обновить.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public virtual async Task UpdateAsync(TDto dto)
        {
            var modelToUpdate = _mapper.ConvertToModel(dto);
            await _service.UpdateAsync(modelToUpdate);
        }
    }
}