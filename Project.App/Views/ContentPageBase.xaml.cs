
using Project.App.ViewModels;
namespace Project.App.Views;

public partial class ContentPageBase
{
    protected IViewModel EditViewModel { get; }
    public ContentPageBase(IViewModel editViewModel)
    {
        InitializeComponent();

        BindingContext = EditViewModel = editViewModel;
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        
        await EditViewModel.OnAppearingAsync();
    }
    
}