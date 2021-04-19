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
        public string ClassId { get; set; }

        /// <summary>
        /// Планы предметов.
        /// </summary>
        public IList<string> SubjectPlanIds { get; set; }
    }
}
