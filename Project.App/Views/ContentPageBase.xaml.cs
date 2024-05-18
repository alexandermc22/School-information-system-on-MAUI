using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.App.ViewModels;
namespace Project.App.Views;

public partial class ContentPageBase : ContentPage
{
    protected IViewModel ViewModel { get; }
    public ContentPageBase(IViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = ViewModel = viewModel;
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        
        await ViewModel.OnAppearingAsync();
    }
    
}