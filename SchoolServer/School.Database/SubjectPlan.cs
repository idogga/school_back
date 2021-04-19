namespace School.Database
{
    /// <summary>
    /// План предмета.
    /// </summary>
    public class SubjectPlan : BaseModel
    {
        /// <summary>
        /// Колличество уроков.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Предмет.
        /// </summary>
        public Subject Subject { get; set; }
    }
}