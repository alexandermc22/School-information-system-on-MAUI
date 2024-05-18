using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Project.App.Services;
using Project.App.ViewModels;
namespace Project.App.Shells;

public partial class AppShell 
{
    private readonly INavigationService _navigationService;
    public AppShell(INavigationService navigationService)
    {
        _navigationService = navigationService;
        InitializeComponent();
    }
    
    [RelayCommand]
    private async Task GoToRecipesAsync()
        => await _navigationService.GoToAsync<StudentListViewModel>();
}