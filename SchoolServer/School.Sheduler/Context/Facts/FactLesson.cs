namespace School.Sheduler.Context.Facts
{
    using School.Sheduler.Context.Schedule;

    public class FactLesson
    {
        public string ClassId { get; set; }

        public string Id { get; set; }

        public ScheduleLesson Lesson { get; set; }

        public string SubjectId { get; set; }

        public string TeacherId { get; set; }

        /// <summary>
        /// Кабинет.
        /// </summary>
        public string Cabinete { get; set; }

        public override string ToString()
        {
            return $"В {Lesson} {SubjectId}";
        }
    }
}