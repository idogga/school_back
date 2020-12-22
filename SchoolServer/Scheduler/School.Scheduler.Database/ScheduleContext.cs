namespace School.Scheduler.Database
{
    using Microsoft.EntityFrameworkCore;

    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options)
            : base(options)
        {
        }

        public DbSet<TimeCell> Cells { get; set; }

        public DbSet<TimeLesson> Lessons { get; set; }

        public DbSet<UserNote> UserNotes { get; set; }
    }
}