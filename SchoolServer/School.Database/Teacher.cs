namespace School.Database
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Учитель.
    /// </summary>
    public class Teacher : BaseModel
    {
        public Teacher()
        {
            Subjects = new List<Subject>();
        }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список предметов которые учитель может вести.
        /// </summary>
        public IList<Subject> Subjects { get; set; }
    }
}