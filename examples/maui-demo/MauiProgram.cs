using Microsoft.Extensions.Logging;
using Orbyss.Blazor.Syncfusion.JsonForms.Extensions;
using Syncfusion.Blazor;

namespace Syncfusion.JsonForms.MauiDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            // Register Syncfusion Blazor Core services
            builder.Services.AddSyncfusionBlazor();

            // Register Syncfusion JSON Forms
            builder.Services.AddSyncfusionJsonForms();

            return builder.Build();
        }
    }
}
