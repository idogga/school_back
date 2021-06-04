namespace School.Database
{
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    /// <summary>
    /// Контекст для работы с данными.
    /// </summary>
    public class SchoolContext : DbContext
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Кабинеты.
        /// </summary>
        public DbSet<Cabinete> Cabinetes => Set<Cabinete>();

        /// <summary>
        /// Классы.
        /// </summary>
        public DbSet<Class> Classes => Set<Class>();

        /// <summary>
        /// Планы для класса.
        /// </summary>
        public DbSet<PlanClass> PlanClasses => Set<PlanClass>();

        /// <summary>
        /// Планы для предметов.
        /// </summary>
        public DbSet<SubjectPlan> SubjectPlans => Set<SubjectPlan>();

        /// <summary>
        /// Предметы.
        /// </summary>
        public DbSet<Subject> Subjects => Set<Subject>();

        /// <summary>
        /// Учителя.
        /// </summary>
        public DbSet<Teacher> Teachers => Set<Teacher>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var keysProperties = modelBuilder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).
                                              SelectMany(x => x.Properties);
            foreach (var property in keysProperties)
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
            }
        }
    }
}