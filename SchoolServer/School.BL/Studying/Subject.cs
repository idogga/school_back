namespace School.BL.Studying
{
    /// <summary>
    /// Предмет.
    /// </summary>
    public class Subject : BaseModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        public int MaxPerWeek { get; set; }
    }
}