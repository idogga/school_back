namespace Schhol.DataBase
{
    using Microsoft.EntityFrameworkCore;

    public class SchoolContext: DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
