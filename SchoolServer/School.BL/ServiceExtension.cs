namespace School.BL
{
    using Microsoft.Extensions.DependencyInjection;

    using School.BL.Place;
    using School.BL.Professor;
    using School.BL.Pupil;
    using School.BL.Studying;
    using School.BL.Studying.Plan;

    public static class ServiceExtension
    {
        /// <summary>
        /// Добавить сервисы с бизнес-логикой.
        /// </summary>
        /// <param name="collection"></param>
        public static void AddBLService(this IServiceCollection collection)
        {
            collection.AddScoped<CabinetService>();
            collection.AddScoped<SubjectService>();
            collection.AddScoped<ClassService>();
            collection.AddScoped<TeacherService>();
            collection.AddScoped<PlanService>();
        }

        /// <summary>
        /// Добавить мапперы.
        /// </summary>
        /// <param name="collection"></param>
        public static void AddMappers(this IServiceCollection collection)
        {
            collection.AddScoped<CabineteMapper>();
            collection.AddScoped<SubjectMapper>();
            collection.AddScoped<ClassMapper>();
            collection.AddScoped<TeacherMapper>();
            collection.AddScoped<PlanMapper>();
        }
    }
}