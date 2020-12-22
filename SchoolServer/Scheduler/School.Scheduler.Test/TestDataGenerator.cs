namespace School.Scheduler.Test
{
    using School.Scheduler.Database;

    public class TestDataGenerator
    {
        private readonly ScheduleContext _context;

        public TestDataGenerator(ScheduleContext context)
        {
            _context = context;
        }

        public void Generate()
        {
            _context.SaveChanges();
        }
    }
}