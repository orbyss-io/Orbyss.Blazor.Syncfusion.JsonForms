using Microsoft.Extensions.DependencyInjection;
using Orbyss.Blazor.JsonForms;
using Orbyss.Blazor.JsonForms.Context.Interfaces;
using Orbyss.Blazor.JsonForms.Extensions;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Extensions
{
    public static class BootstrapExtensions
    {
        public static IServiceCollection AddSyncfusionJsonForms(this IServiceCollection services, SyncfusionFormComponentInstanceProviderOptions? options = null, Func<IServiceProvider, IJsonFormContext>? jsonFormContextFactory = null)
        {
            return services
                .AddJsonForms(jsonFormContextFactory)
                .AddSingleton<IFormComponentInstanceProvider>(new SyncfusionFormComponentInstanceProvider(options));
        }

        public static IServiceCollection AddSyncfusionJsonForms<TFormComponentInstanceProvider>(this IServiceCollection services, Func<IServiceProvider, IJsonFormContext>? jsonFormContextFactory = null)
            where TFormComponentInstanceProvider : class, IFormComponentInstanceProvider
        {
            return services
                .AddJsonForms(jsonFormContextFactory)
                .AddSingleton<IFormComponentInstanceProvider, TFormComponentInstanceProvider>();
        }
    }
}
