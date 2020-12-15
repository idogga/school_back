namespace School.BL.Pupil
{
    /// <summary>
    /// Класс.
    /// </summary>
    public class Class : BaseModel
    {
        /// <summary>
        /// Литера.
        /// </summary>
        public char Litera { get; set; }

        /// <summary>
        /// Уровень.
        /// </summary>
        public int Grade { get; set; }
    }
}