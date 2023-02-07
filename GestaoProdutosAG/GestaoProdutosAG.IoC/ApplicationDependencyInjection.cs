using GestaoProdutosAG.Application;
using GestaoProdutosAG.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoProdutosAG.IoC
{
    public class ApplicationDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

        }
    }
}
