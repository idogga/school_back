namespace School.Database
{
    using Microsoft.EntityFrameworkCore;

    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Cabinete> Cabinetes { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Subject> SubjectsPget { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}