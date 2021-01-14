namespace School.Scheduler.BL.Penalties
{
    using System.Collections.Generic;

    using School.Scheduler.Database;

    public class PenaltyServiceFactory
    {
        public static PenaltyService Generate()
        {
            var userPenaltyService = new PenaltyUserService(new List<TimeLesson>());
            var lessonService = new PenaltyLessonServices(new List<TimeLesson>());
            var penaltyService = new PenaltyService(lessonService, userPenaltyService);

            return penaltyService;
        }
    }
}