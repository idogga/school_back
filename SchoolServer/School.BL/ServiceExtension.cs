using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.BL
{
    public static class ServiceExtension
    {
        public static void AddBLService(this IServiceCollection collection)
        {
            collection.AddScoped<CabinetService>();
        }


        public static void AddMappers(this IServiceCollection collection)
        {
            collection.AddScoped<CabineteMapper>();
        }
    }
}
