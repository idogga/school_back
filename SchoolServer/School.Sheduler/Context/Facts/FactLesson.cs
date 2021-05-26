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
        public Guid ClassId { get; set; }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Запланированный урок.
        /// </summary>
        public ScheduleLesson Lesson { get; set; } = null!;

        /// <summary>
        /// Идентфикатор предмета.
        /// </summary>
        public Guid SubjectId { get; set; }

        /// <summary>
        /// Идентифкатор учителя.
        /// </summary>
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Кабинет.
        /// </summary>
        public Guid Cabinete { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"В {Lesson} {SubjectId}";
        }
    }
}