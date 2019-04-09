using Livraria.Infra.Data.Context;
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
            dependencies.AddScoped<LivrariaContext>();
            #endregion

            #region Services 

            #endregion region

            #region Business 

            #endregion region
        }
    }
}