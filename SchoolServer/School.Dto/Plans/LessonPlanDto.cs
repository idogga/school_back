using System;
using System.Collections.Generic;
using System.Text;

namespace School.Dto.Plans
{
    public class LessonPlanDto: BaseDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string CabineteId { get; set; }

        public string SubjectId { get; set; }

        public string TeacherId { get; set; }

        public string ClassId { get; set; }
    }
}
