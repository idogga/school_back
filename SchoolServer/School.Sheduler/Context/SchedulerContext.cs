namespace School.Sheduler.Context
{
    using Microsoft.EntityFrameworkCore;

    using School.Sheduler.Context.Facts;
    using School.Sheduler.Context.Rules;
    using School.Sheduler.Context.Schedule;

    /// <summary>
    /// Контекст БД для работы с расписанием.
    /// </summary>
    public class SchedulerContext : DbContext
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public SchedulerContext(DbContextOptions<SchedulerContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Правила для работы с классом.
        /// </summary>
        public DbSet<ClassRule> ClassRules { get; set; }

        /// <summary>
        /// Уроки.
        /// </summary>
        public DbSet<FactLesson> Lessons { get; set; }

        /// <summary>
        /// Сетка расписания.
        /// </summary>
        public DbSet<ScheduleLesson> ScheduleLessons { get; set; }

        /// <summary>
        /// Правила для работы с предметом..
        /// </summary>
        public DbSet<SubjectRule> SubjectRules { get; set; }

        /// <summary>
        /// Правила для работы с учителем.
        /// </summary>
        public DbSet<TeacherRule> TeacherRules { get; set; }

        /// <summary>
        /// Логирование действий.
        /// </summary>
        public DbSet<LogRecord> Logs { get; set; }
    }
}