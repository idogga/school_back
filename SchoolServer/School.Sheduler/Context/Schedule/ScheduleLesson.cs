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
        public string Id { get; set; }

        /// <summary>
        /// Времям начала.
        /// </summary>
        public TimeSpan StartTime { get; set; }
        
        public override string ToString()
        {
            return $"{Day} {StartTime:HH:mm:ss}-{EndTime:HH:mm:ss}";
        }
    }
}