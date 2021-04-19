namespace School.Dto.Plans
{
    using System;

    public class LessonPlanDto : BaseDto
    {
        public string CabineteId { get; set; }

        public string ClassId { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime StartDate { get; set; }

        public string SubjectId { get; set; }

        public string TeacherId { get; set; }
    }
}