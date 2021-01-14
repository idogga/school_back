namespace School.Scheduler.BL
{
    using System.Linq;

    using School.Scheduler.BL.Penalties;
    using School.Scheduler.Database;

    public class SwarmService
    {
        private readonly PenaltyService _penaltyService;

        public SwarmService()
        {
            _penaltyService = PenaltyServiceFactory.Generate();
        }

        private int _currentScore =>
            _penaltyService.Penalties.Select(x => x.PenaltyType.CalculateScore()).Aggregate((x, y) => x + y);

        private bool _isFullPenalties => _currentScore > 127;

        private void FindPostPenalties()
        {
            _penaltyService.PostCalculate();
        }

        private void FindPrePenalties()
        {
            _penaltyService.PreCalculate();
        }

        private void ResetScore()
        {
            _penaltyService.Reset();
        }
    }
}