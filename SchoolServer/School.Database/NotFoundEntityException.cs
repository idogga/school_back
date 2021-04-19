using System;

namespace School.Database
{
    /// <summary>
    /// Ошибка не найдена сущность.
    /// </summary>
    public sealed class NotFoundEntityException: ApplicationException
    {
        /// <summary>
        /// Контруктор.
        /// </summary>
        public NotFoundEntityException(Type type, string id):base($"Не найдена {type.Name} с идентификатором {id}")
        {

        }
    }
}
