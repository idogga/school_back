namespace School.Scheduler.BL.Penalties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using School.Scheduler.Database;

    public class PenaltyUserService
    {
        private readonly List<TimeLesson> _lessons;

        public PenaltyUserService(List<TimeLesson> lessons)
        {
            _lessons = lessons;
        }

        public List<Penalty> CalculatePenalty(string userId)
        {
            var result = new List<Penalty>();
            var lessonsCount = _lessons.Count(x => x.TeacherId == userId);
            
            if (lessonsCount == 0)
                result.Add(Penalty.Generate(string.Empty, PenaltyType.NotLessons));

            // TODO: Добавить план для каждого учителя
            if (lessonsCount > 25)
                result.Add(Penalty.Generate($"Текущее колличество: {lessonsCount}", PenaltyType.TooMuchLessonsOnWeek));

            return result;
        }

        //private Tuple<int, DateTime> GetMaxLessonsOnDay(string userId)
        //{
        //    _lessons.Where(x=>x.TeacherId == userId)
        //            .GroupBy(x=> x.Time.Start.DayOfYear)
                    
        //}
    }
}
