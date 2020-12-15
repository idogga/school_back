namespace School.BL
{
    using Microsoft.Extensions.DependencyInjection;

    using School.BL.Place;
    using School.BL.Professor;
    using School.BL.Pupil;
    using School.BL.Studying;

    public static class ServiceExtension
    {
        public static void AddBLService(this IServiceCollection collection)
        {
            collection.AddScoped<CabinetService>();
            collection.AddScoped<SubjectService>();
            collection.AddScoped<ClassService>();
            collection.AddScoped<TeacherService>();
        }

        public static void AddMappers(this IServiceCollection collection)
        {
            collection.AddScoped<CabineteMapper>();
            collection.AddScoped<SubjectMapper>();
            collection.AddScoped<ClassMapper>();
            collection.AddScoped<TeacherMapper>();
        }
    }
}