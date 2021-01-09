using System;
using System.Collections.Generic;
using System.Text;

namespace School.Scheduler.BL.Penalties
{
    using School.Scheduler.Database;

    public class PenaltyLessonServices: IPenaltyService
    {
        private readonly List<TimeLesson> _lessons;

        public PenaltyLessonServices(List<TimeLesson> lessons)
        {
            _lessons = lessons;
            Penalties = new List<Penalty>();
        }

        public List<Penalty> Penalties { get; } 

        public void PostCalculate()
        {
        }

        public void PreCalculate()
        {
        }
    }
}
