namespace School.Scheduler.Database
{
    using System;

    public class TimeCell : BaseEntity
    {
        public DateTime End { get; set; }

        public int Order { get; set; }

        public DateTime Start { get; set; }
    }
}