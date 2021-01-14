namespace School.Scheduler.BL.Penalties
{
    using System.Collections.Generic;
    using System.Linq;

    using School.Scheduler.Database;

    public class PenaltyUserService : IPenaltyService
    {
        private readonly List<TimeLesson> _lessons;

        public PenaltyUserService(List<TimeLesson> lessons)
        {
            _lessons = lessons;
            Penalties = new List<Penalty>();
        }

        public List<Penalty> Penalties { get; }

        public void PostCalculate()
        {
            var teacherLessons = _lessons.GroupBy(x => x.TeacherId).Select(gr => new { TeacherId = gr.Key, Count = gr.Count() }).
                                          OrderByDescending(l => l.Count);
            if (teacherLessons.Min(x => x.Count) == 0)
                Penalties.Add(Penalty.Generate(string.Empty, PenaltyType.NotLessons));

            // TODO: Добавить план для каждого учителя
            var maxLessons = teacherLessons.Max(x => x.Count);
            if (maxLessons > 25)
                Penalties.Add(Penalty.Generate($"Текущее колличество: {maxLessons}", PenaltyType.TooMuchLessonsOnWeek));
        }

        public void PreCalculate()
        {
        }
    }
}