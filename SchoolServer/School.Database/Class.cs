namespace School.Database
{
    /// <summary>
    /// Класс.
    /// </summary>
    public class Class : BaseModel
    {
        public Class(int grade, char litera)
        {
            Grade = grade;
            Litera = litera;
        }

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