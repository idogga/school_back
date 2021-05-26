using System;

namespace School.Database
{
    /// <summary>
    /// Ошибка не найдена сущность.
    /// </summary>
    public sealed class NotFoundEntityException: ApplicationException
    {
        public NotFoundEntityException(Type type, Guid id)
            : base($"Not found {type.Name} with {id}")
        {

        }

        public NotFoundEntityException(Type type, string id)
            : base($"Not found {type.Name} with {id}")
        {

        }

        public NotFoundEntityException(Type type)
            : base($"Not found {type.Name}")
        {

        }
    }
}
