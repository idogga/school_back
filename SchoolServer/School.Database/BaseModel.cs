using System;

namespace School.Database
{
    /// <summary>
    /// Базовая модель данных.
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }
    }
}