using CommunityToolkit.Maui;
using FoodRecipesApp.Interfaces;
using FoodRecipesApp.Services;
using FoodRecipesApp.ViewModels;
using FoodRecipesApp.Views;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace FoodRecipesApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<IBaseServices, BaseServices>();
            builder.Services.AddSingleton<IRecipeServices,RecipeServices>();
            builder.Services.AddSingleton<IProcedureServices, ProcedureServices>();
            builder.Services.AddSingleton<IOriginService, OriginServices>();
            builder.Services.AddSingleton<OriginPageViewModel>();
            builder.Services.AddSingleton<OriginPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
