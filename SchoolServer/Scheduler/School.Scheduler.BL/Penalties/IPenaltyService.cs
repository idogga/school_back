namespace School.Scheduler.BL.Penalties
{
    using System.Collections.Generic;

    using School.Scheduler.Database;

    public interface IPenaltyService
    {
        List<Penalty> Penalties { get; }

        void PostCalculate();

        void PreCalculate();
    }
}