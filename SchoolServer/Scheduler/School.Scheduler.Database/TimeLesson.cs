namespace School.Scheduler.Database
{
    public class TimeLesson : BaseEntity
    {
        public string ClassId { get; set; }

        public string SubjectId { get; set; }

        public string TeacherId { get; set; }

        public TimeCell Time { get; set; }
    }
}