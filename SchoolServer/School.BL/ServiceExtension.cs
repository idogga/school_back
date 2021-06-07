namespace School.BL
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using School.Abstract;
    using School.BL.Place;
    using School.BL.Professor;
    using School.BL.Pupil;
    using School.BL.Studying;
    using School.BL.Studying.Plan;
    using System;
    using System.Linq;

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
            var mappers = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IMapperBuilder).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                foreach(var mapperType in mappers)
                {
                    var instance = Activator.CreateInstance(mapperType) ?? throw new ArgumentNullException("Не удалось создать маппер");
                    if (!(instance is IMapperBuilder mapper))
                        throw new TypeAccessException("Не правильный тип данных");

                    mc.AddProfile(mapper.Build());
                }
            });

            var mapper = mapperConfig.CreateMapper();
            collection.AddSingleton(mapper);

        }
    }
}