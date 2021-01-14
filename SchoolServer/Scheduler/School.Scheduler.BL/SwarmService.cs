using System;
using System.Collections.Generic;
using System.Text;

namespace School.Scheduler.BL
{
    using School.Scheduler.BL.Penalties;
    using School.Scheduler.Database;
    using System.Linq;

    public class SwarmService
    {
        private readonly PenaltyService _penaltyService;

        private int _currentScore => _penaltyService.Penalties
            .Select(x=>x.PenaltyType.CalculateScore())
            .Aggregate((x,y)=> x+y);

        private bool _isFullPenalties => _currentScore > 127;

        public SwarmService()
        {
            _penaltyService = PenaltyServiceFactory.Generate();
        }

        private void FindPrePenalties()
        {
            _penaltyService.PreCalculate();
        }

        private void FindPostPenalties()
        {
            _penaltyService.PostCalculate();
        }

        private void ResetScore()
        {
            _penaltyService.Reset();
        }
    }
}
