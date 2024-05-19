using CommunityToolkit.Mvvm.Input;
using Project.App.Services;
using Project.App.ViewModels;
namespace Project.App;

public partial class AppShell : Shell
{
    private readonly INavigationService _navigationService;
    public AppShell(INavigationService navigationService)
    {
        _navigationService = navigationService;

        InitializeComponent();
    }
    
    [RelayCommand]
    private async Task GoToStudentsAsync()
        => await _navigationService.GoToAsync<StudentListViewModel>();
}