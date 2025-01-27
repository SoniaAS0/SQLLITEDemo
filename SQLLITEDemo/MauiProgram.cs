using Microsoft.Extensions.Logging;
using SQLLITEDemo.Abstractions;
using SQLLITEDemo.MVVM.Model;
using SQLLITEDemo.Repositories;

namespace SQLLITEDemo
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
            builder.Services.AddSingleton<IBaseRepository<Customer>, BaseRepository<Customer>>();
            builder.Services.AddSingleton<IBaseRepository<Order>, BaseRepository<Order>>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
