namespace School.Database
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Учебный план для класса.
    /// </summary>
    public class PlanClass : BaseModel
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public PlanClass()
        {
            SubjectPlans = new Collection<SubjectPlan>();
        }

        /// <summary>
        /// Класс.
        /// </summary>
        public Class Class { get; set; } = null!;

        /// <summary>
        /// Планы предметов.
        /// </summary>
        public Collection<SubjectPlan> SubjectPlans { get; set; }
    }
}