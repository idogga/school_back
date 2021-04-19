namespace School.Sheduler.Context.Facts
{
    using School.Sheduler.Context.Schedule;
    using System;

    /// <summary>
    /// Фактический урок.
    /// </summary>
    public class FactLesson
    {
        /// <summary>
        /// Идентификатор класса.
        /// </summary>
        public string ClassId { get; set; }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Запланированный урок.
        /// </summary>
        public ScheduleLesson Lesson { get; set; }

        /// <summary>
        /// Идентфикатор предмета.
        /// </summary>
        public string SubjectId { get; set; }

        /// <summary>
        /// Идентифкатор учителя.
        /// </summary>
        public string TeacherId { get; set; }

        /// <summary>
        /// Кабинет.
        /// </summary>
        public string Cabinete { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"В {Lesson} {SubjectId}";
        }
    }
}