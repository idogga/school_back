using System;
using System.Collections.Generic;
using School.Scheduler.Database;

namespace School.Scheduler.BL.Penalties
{
    public interface IPenaltyService
    {
        void PreCalculate();

        void PostCalculate();

        List<Penalty> Penalties { get; }
    }
}
