using Livraria.Domain.Models;
using Livraria.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.WebApi.Extensions
{
    public static class MigrationExtensions
    {
        public static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<LivrariaContext>())
                {
                    context.Database.Migrate();

                    if (context.Usuarios == null || !context.Usuarios.Any())
                    {
                        context.UpdateRange(new List<object>
                        {
                            new Usuario { Nome = "admin", Senha = "admin"},
                            new Usuario { Nome = "sysdba", Senha = "masterkey" }
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}