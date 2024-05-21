
using Project.App.ViewModels;
namespace Project.App.Views;

public partial class ContentPageBase
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