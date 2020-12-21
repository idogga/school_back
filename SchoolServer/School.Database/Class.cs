namespace School.Database
{
    /// <summary>
    /// Класс.
    /// </summary>
    public class Class : BaseModel
    {
        /// <summary>
        /// Уровень.
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Литера.
        /// </summary>
        public char Litera { get; set; }
    }
}