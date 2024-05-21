namespace Project.App;

public partial class App : Application
{
    // public static IServiceProvider Services { get; private set; }
    public App(IServiceProvider serviceProvider )
    {
        InitializeComponent();

        MainPage = serviceProvider.GetRequiredService<AppShell>();
        // Services = serviceProvider;
    }
}