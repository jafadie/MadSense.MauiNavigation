using Microsoft.Extensions.Logging;
using Prismanda.Services;
using Prismanda.ViewModels;
using Prismanda.Views;

namespace Prismanda
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton(_ => Application.Current!.MainPage!.Navigation);

            builder.Services.AddSingleton<BackgroundService>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<Page1>();

            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<Page1ViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
