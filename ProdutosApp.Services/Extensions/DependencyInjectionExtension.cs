using ProdutosApp.Data.Repositories;
using ProdutosApp.Domain.Interfaces;
using ProdutosApp.Domain.Services;

namespace ProdutosApp.Services.Extensions
{
    /// <summary>
    /// Classe de extensão para configurarmos as injeções
    /// de dependência do sistema (interfaces/classes)
    /// </summary>
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IProdutoDomainService, ProdutoDomainService>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
