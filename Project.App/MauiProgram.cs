using CommunityToolkit.Maui;
using Project.App.Services;
using Project.BL;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Project.App.ViewModels;
using Project.BL.Facades;
using Project.DAL;
using Project.DAL.Migrator;
using Project.DAL.Options;
[assembly:System.Resources.NeutralResourcesLanguage("en")]
namespace Project.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        ConfigureAppSettings(builder);
        
        builder.Services
            .AddDALServices(GetDALOptions(builder.Configuration))
            .AddAppServices()
            .AddBLServices();
        
        
        // // Регистрация сервисов
        // builder.Services.AddSingleton<INavigationService, NavigationService>();
        // builder.Services.AddSingleton<IMessengerService, MessengerService>();
        //
        // // Регистрация фасадов
        // builder.Services.AddTransient<IStudentFacade, StudentFacade>();
        //
        // // Регистрация ViewModel
        // builder.Services.AddTransient<StudentEditViewModel>();
        
        var app = builder.Build();
        
        // Проверка всех зарегистрированных зависимостей
        // using (var scope = app.Services.CreateScope())
        // {
        //     var services = scope.ServiceProvider;
        //     try
        //     {
        //         // Попытка получения каждого зарегистрированного сервиса
        //         services.GetRequiredService<INavigationService>();
        //         services.GetRequiredService<IMessengerService>();
        //         services.GetRequiredService<IStudentFacade>();
        //         services.GetRequiredService<StudentEditViewModel>();
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new ArgumentException();
        //     }
        // }
        
        MigrateDb(app.Services.GetRequiredService<IDbMigrator>());
        RegisterRouting(app.Services.GetRequiredService<INavigationService>());
        return app;
    }
    private static void MigrateDb(IDbMigrator migrator) => migrator.Migrate();
    private static void ConfigureAppSettings(MauiAppBuilder builder)
    {
        var configurationBuilder = new ConfigurationBuilder();

        var assembly = Assembly.GetExecutingAssembly();
        const string appSettingsFilePath = "Project.App.appsettings.json";
        using var appSettingsStream = assembly.GetManifestResourceStream(appSettingsFilePath);
        if (appSettingsStream is not null)
        {
            configurationBuilder.AddJsonStream(appSettingsStream);
        }
        else
        {
            throw new ArgumentException();
        }

        var configuration = configurationBuilder.Build();
        builder.Configuration.AddConfiguration(configuration);
    }
    
    private static void RegisterRouting(INavigationService navigationService)
    {
        foreach (var route in navigationService.Routes)
        {
            Routing.RegisterRoute(route.Route, route.ViewType);
        }
    }
    
    private static DALOptions GetDALOptions(IConfiguration configuration)
    {
        DALOptions dalOptions = new()
        {
            DatabaseDirectory = FileSystem.AppDataDirectory,
            // DatabaseName = "project.db"
        };
        configuration.GetSection("Project:DAL").Bind(dalOptions);
        return dalOptions;
    }
}