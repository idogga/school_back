using System.Collections.Generic;

namespace School.Dto
{
    /// <summary>
    /// Объект для передачи списка с <see cref="TDto"/>.
    /// </summary>
    /// <typeparam name="TDto">Тип ДТО.</typeparam>
    public class ListDto<TDto> where TDto: BaseDto
    {
        /// <summary>
        /// Список объектов.
        /// </summary>
        public List<TDto> Results { get; set; }

        /// <summary>
        /// Обещее число элементов.
        /// </summary>
        public long TotalCount { get; set; }
    }
}
