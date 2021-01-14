namespace School.Scheduler.Database
{
    using System;

    public enum PenaltyType
    {
        NotLessons,

        TooMuchLessonsOnWeek,

        TooMuchLessonsOnDay
    }

    public static class PenaltyTypeExtension
    {
        public static int CalculateScore(this PenaltyType type)
        {
            switch (type)
            {
                case PenaltyType.NotLessons:
                    return 15;

                case PenaltyType.TooMuchLessonsOnWeek:
                case PenaltyType.TooMuchLessonsOnDay:
                    return 20;

                default:
                    throw new ArgumentOutOfRangeException("Не удалось определить тип ошибки");
            }
        }
    }
}