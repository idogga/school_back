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
        public string Id { get; set; }
    }
}