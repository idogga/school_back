namespace School.Database
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Учитель.
    /// </summary>
    public class Teacher : BaseModel
    {
        public Teacher(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список предметов которые учитель может вести.
        /// </summary>
        public ICollection<Subject> Subjects { get; set; } = new Collection<Subject>();
    }
}