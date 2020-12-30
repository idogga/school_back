using System;
using System.Collections.Generic;
using System.Text;

namespace School.Scheduler.BL
{
    using School.Scheduler.BL.Penalties;
    using School.Scheduler.Database;

    public class SwarmService
    {
        private readonly ScheduleContext _context;
        private readonly PenaltyService _penaltyService;

        private int _currentScore = 0;

        public SwarmService(ScheduleContext context)
        {
            _context = context;
        }

        public void NextIteraction()
        {
            ResetScore();
            FindPenalties();
            foreach (var e in Empl)
            {
                foreach (Penalty p in e.penalties)
                {
                    switch (p.name)
                    {
                        case "PenaltyAboveNormalHolidayCnt": //запланировано много дней
                            …
                            break;
                        case "PenaltyNo14DaysPart"://одна из частей должна быть не менее 14 дней
                            …
                            break;
                        case "PenaltyBellowNormalHolidayCnt": //запланировано мало дней
                            …                        
                            break;
                        default:
                            Log.WriteLine("Не задан алогритм для штрафа " + p.name);
                            break;
                    }
                }
            }
        }

        private void FindPenalties()
        {

        }

        private void ResetScore()
        {

        }

        private int CalculateScore(bool reCalculate = false)
        {
            if (_currentScore < 127)
                return _currentScore;

            if (reCalculate)
                ResetScore();
            _currentScore = _penaltyService.CalculateScore();
            return _currentScore;
        }

        public bool IsCovarged()
        {
            if (_currentScore < 127)
                return false;
            FindPenalties();
            return _penaltyService.TotalPenalties() != 0;
        }
    }
}
