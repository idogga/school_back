using Microsoft.Extensions.DependencyInjection;
using School.Sheduler.Context.Facts;
using School.Sheduler.Services.Controller;
using School.Sheduler.Services.Controller.Facts;
using School.Sheduler.Services.CQRS;
using School.Sheduler.Services.Generator;

namespace School.Sheduler
{
    public static class ServiceAdder
    {
         public static void AddSchedulerServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddGenerator();
            serviceCollection.AddListCDQRS<FactLesson, FactLessonService>();
            serviceCollection.AddReadCDQRS<FactLesson, FactLessonService>();
        }

        private static void AddListCDQRS<TResult, TServce>(this IServiceCollection serviceCollection)
            where TServce: class, IQueryHandler<GroupQuery<TResult>, GroupResult<TResult>>
        {
            serviceCollection.AddTransient<IQueryHandler<GroupQuery<TResult>, GroupResult<TResult>>, TServce>();
        }

        private static void AddReadCDQRS<TResult, TServce>(this IServiceCollection serviceCollection)
            where TServce : class, IQueryHandler<InstanceQuery<TResult>, TResult>
        {
            serviceCollection.AddTransient<IQueryHandler<InstanceQuery<TResult>, TResult>, TServce>();
        }

        private static void AddGenerator(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<GeneratorService>();
            serviceCollection.AddTransient<ISchedulerGeneratorService, SchedullerGeneratorService>();

        }
    }
}
