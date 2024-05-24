using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;

namespace Project.App.ViewModels;

public partial class StudentListViewModel(
    IStudentFacade studentFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<StudentEditMessage>, IRecipient<StudentDeleteMessage>
{
    public IEnumerable<StudentListModel> Students { get; set; } = null!;


    private string FirstName { get; set; } = string.Empty;
    private string LastName { get; set; } = string.Empty;
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        
        Students = await studentFacade.GetAsync();
    }
    
    [RelayCommand]
    private async Task SortAsync()
    {
        await base.LoadDataAsync();
        
        Students = await studentFacade.GetSortAsync();
    }
    
    [RelayCommand]
    private async Task GetFilteredAsync()
    {
        await base.LoadDataAsync();
    
        Students = await studentFacade.GetByNameAsync(FirstName, LastName);
    }
    
    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        await navigationService.GoToAsync("/edit");
    }

    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
    {
        await navigationService.GoToAsync<StudentDetailViewModel>(
            new Dictionary<string, object?> { [nameof(StudentDetailViewModel.Id)] = id });
    }

    public async void Receive(StudentEditMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(StudentDeleteMessage message)
    {
        await LoadDataAsync();
    }
}