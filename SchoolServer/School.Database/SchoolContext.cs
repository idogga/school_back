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
        public DbSet<Cabinete> Cabinetes { get; set; }

        /// <summary>
        /// Классы.
        /// </summary>
        public DbSet<Class> Classes { get; set; }

        /// <summary>
        /// Планы для класса.
        /// </summary>
        public DbSet<PlanClass> PlanClasses { get; set; }

        /// <summary>
        /// Планы для предметов.
        /// </summary>
        public DbSet<SubjectPlan> SubjectPlans{ get; set; }

        /// <summary>
        /// Предметы.
        /// </summary>
        public DbSet<Subject> Subjects { get; set; }

        /// <summary>
        /// Учителя.
        /// </summary>
        public DbSet<Teacher> Teachers { get; set; }

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