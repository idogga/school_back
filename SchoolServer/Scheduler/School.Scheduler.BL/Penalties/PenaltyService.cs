using System;
using System.Collections.Generic;
using System.Text;

namespace School.Scheduler.BL.Penalties
{
    using School.Scheduler.Database;

    public class PenaltyService
    {
        private readonly PenaltyLessonServices _lessonServices;
        private readonly PenaltyUserService _userServices;

        private List<Penalty> _penalties = new List<Penalty>();

        public int CalculateScore()
        {
            return 0;
        }

        public int TotalPenalties()
        {
            return _penalties.Count;
        }
    }
}
