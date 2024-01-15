using Microsoft.Extensions.Logging;
using FridgeTracker.Repositories;
using FridgeTracker.MVVM.Models;
using Plugin.LocalNotification;
using Camera.MAUI;

namespace FridgeTrackerZuyd
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseLocalNotification()
                .UseMauiCameraView()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<BaseRepository<Brew>>();
            builder.Services.AddSingleton<BaseRepository<Group>>();
            builder.Services.AddSingleton<BaseRepository<GeneralUser>>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
