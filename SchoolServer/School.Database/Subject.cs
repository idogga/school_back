﻿namespace School.Database
{
    /// <summary>
    /// Предмет.
    /// </summary>
    public class Subject : BaseModel
    {
        /// <summary>
        /// Максимальное колличество занятий в неделю.
        /// </summary>
        public int MaxPerWeek { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}