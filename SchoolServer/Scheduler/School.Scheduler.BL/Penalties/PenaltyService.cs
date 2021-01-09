using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace School.Scheduler.BL.Penalties
{
    using School.Scheduler.Database;

    public class PenaltyService: IPenaltyService
    {
        private readonly List<IPenaltyService> _penaltyServices = new List<IPenaltyService>();

        public PenaltyService(PenaltyLessonServices lessonServices,
            PenaltyUserService userService)
        {
            _penaltyServices.Add(userService);
            _penaltyServices.Add(lessonServices);
        }

        public List<Penalty> Penalties => _penaltyServices.SelectMany(x => x.Penalties).ToList();

        public void PostCalculate()
        {
            _penaltyServices.ForEach(x => x.PostCalculate());
        }

        public void PreCalculate()
        {
            _penaltyServices.ForEach(x => x.PreCalculate());
        }

        public void Reset()
        {
            _penaltyServices.ForEach(x => x.Penalties.Clear());
        }
    }
}
