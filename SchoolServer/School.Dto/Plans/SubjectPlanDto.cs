namespace School.Dto.Plans
{
    using System;
    using System.Collections.Generic;

    public class SubjectPlanDto : BaseDto
    {
        public List<AdditionalSubjectPlanDto> Addtionals { get; set; } = new List<AdditionalSubjectPlanDto>();

        public DateTime EndPeriod { get; set; }

        public DateTime StartPeriod { get; set; }

        public string SubjectId { get; set; }

        public int TotalCountPerPeriod { get; set; }
    }
}