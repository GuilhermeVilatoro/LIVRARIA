using Livraria.Application.Services;
using Livraria.Application.Services.Interfaces;
using Livraria.Domain.Business;
using Livraria.Domain.Business.Interfaces;
using Livraria.Domain.Repository.Interfaces;
using Livraria.Infra.Data.Context;
using Livraria.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.Infra.CrossCutting.IOC
{
    public static class InjectionDependencies
    {
        /// <summary>
        /// Responsável por realizar o registro das dependências.
        /// </summary>
        /// <param name="dependencies">Lista a qual será adicionada as dependências</param>
        public static void RegisterDependencies(IServiceCollection dependencies)
        {
            #region Repository    
            dependencies.AddScoped<IAutorRepository, AutorRepository>();
            dependencies.AddScoped<ILivroRepository, LivroRepository>();            
            dependencies.AddScoped<LivrariaContext>();
            #endregion

            #region Services 
            dependencies.AddScoped<IAutorService, AutorService>();
            dependencies.AddScoped<ILivroService, LivroService>();
            dependencies.AddScoped<IVinculacaoAutorLivroService, VinculacaoAutorLivroService>();
            #endregion region

            #region Business 
            dependencies.AddScoped<IVinculacaoAutorNoLivroBusiness, VinculacaoAutorNoLivroBusiness>();
            #endregion region
        }
    }
}