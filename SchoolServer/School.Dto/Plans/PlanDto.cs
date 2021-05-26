using System;
using System.Collections.Generic;

namespace School.Dto.Plans
{
    /// <summary>
    /// ДТО
    /// </summary>
    public class PlanDto: BaseDto
    {
        /// <summary>
        /// Класс.
        /// </summary>
        public Guid ClassId { get; set; }

        /// <summary>
        /// Планы предметов.
        /// </summary>
        public IList<Guid> SubjectPlanIds { get; set; } = new List<Guid>();
    }
}
