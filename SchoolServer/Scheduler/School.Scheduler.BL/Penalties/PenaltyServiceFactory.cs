using System;
namespace School.Scheduler.BL.Penalties
{
    public class PenaltyServiceFactory
    {
        public static PenaltyService Generate()
        {
            var userPenaltyService = new PenaltyUserService();
            var lessonService = new PenaltyLessonServices();
            var penaltyService = new PenaltyService(lessonService, userPenaltyService);

            return penaltyService;
        }
    }
}
