using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estudo_dotnet.Data.Context;
using estudo_dotnet.Data.Seed;

namespace estudo_dotnet.Data
{
    internal static class DbInitializerExtension
    {
        public static IApplicationBuilder Seeder(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<EstudoContext>();
                DbInitializer.Initialize(context);
            }
            catch (System.Exception)
            {
                
            }
            return app;
        }
    }
}