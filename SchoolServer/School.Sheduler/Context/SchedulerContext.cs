namespace School.Sheduler.Context
{
    using Microsoft.EntityFrameworkCore;

    using School.Sheduler.Context.Facts;
    using School.Sheduler.Context.Rules;
    using School.Sheduler.Context.Schedule;

    public class SchedulerContext : DbContext
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public SchedulerContext(DbContextOptions<SchedulerContext> options)
            : base(options)
        {
        }

        public DbSet<ClassRule> ClassRules { get; set; }

        public DbSet<FactLesson> Lessons { get; set; }

        public DbSet<ScheduleLesson> ScheduleLessons { get; set; }

        public DbSet<SubjectRule> SubjectRules { get; set; }

        public DbSet<TeacherRule> TeacherRules { get; set; }
    }
}