using System;
using System.Collections.Generic;
using System.Text;

namespace School.Dto.Plans
{
    public class SubjectPlanDto: BaseDto
    {
        public int TotalCountPerPeriod { get; set; }

        public DateTime StartPeriod { get; set; }

        public DateTime EndPeriod { get; set; }

        public string SubjectId { get; set; }

        public List<AdditionalSubjectPlanDto> Addtionals { get; set; } = new List<AdditionalSubjectPlanDto>();
    }
}
