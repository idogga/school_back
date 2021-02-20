namespace School.Sheduler.Context.Schedule
{
    using System;

    public class ScheduleLesson
    {
        public DayOfWeek Day { get; set; }

        public TimeSpan EndTime { get; set; }

        public string Id { get; set; }

        public TimeSpan StartTime { get; set; }
    }
}