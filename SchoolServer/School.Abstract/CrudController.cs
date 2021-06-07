namespace School.Abstract
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// ffffff
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public abstract class CrudController<CTDto, TDto, TModel> : ControllerBase
    {
        protected readonly IMapper _mapper;

        protected readonly CrudService<TModel> _service;

        public CrudController(IMapper mapper, CrudService<TModel> service)
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
        public virtual Task<Guid> CreateAsync(CTDto dto)
        {
            var model = _mapper.Map<TModel>(dto);
            return _service.CreateAsync(model);
        }

        /// <summary>
        /// Удалить.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }

        /// <summary>
        /// Считать.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual async Task<TDto> ReadAsync(Guid id)
        {
            var model = await _service.ReadAsync(id);
            return _mapper.Map<TDto>(model);
        }

        /// <summary>
        /// Обновить.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public virtual async Task UpdateAsync(TDto dto)
        {
            var modelToUpdate = _mapper.Map<TModel>(dto);
            await _service.UpdateAsync(modelToUpdate);
        }
    }
}