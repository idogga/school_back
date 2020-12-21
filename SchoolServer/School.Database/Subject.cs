namespace School.Database
{
    /// <summary>
    /// Предмет.
    /// </summary>
    public class Subject : BaseModel
    {
        public int MaxPerWeek { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}