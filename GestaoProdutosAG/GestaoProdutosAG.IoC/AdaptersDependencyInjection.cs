using GestaoProdutosAG.Domain.Adapters;
using GestaoProdutosAG.SqlAdapter;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoProdutosAG.IoC
{
    public class AdaptersDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IProductDbAdapter, ProductDbAdapter>();

        }
    }
}
