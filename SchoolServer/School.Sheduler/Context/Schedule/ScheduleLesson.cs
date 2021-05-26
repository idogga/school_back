namespace School.Sheduler.Context.Schedule
{
    using System;

    /// <summary>
    /// Сетка для урока.
    /// </summary>
    public class ScheduleLesson
    {
        /// <summary>
        /// День урока.
        /// </summary>
        public DayOfWeek Day { get; set; }

        /// <summary>
        /// Время окончания.
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Времям начала.
        /// </summary>
        public TimeSpan StartTime { get; set; }
        
        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Day} {StartTime}-{EndTime}";
        }
    }
}