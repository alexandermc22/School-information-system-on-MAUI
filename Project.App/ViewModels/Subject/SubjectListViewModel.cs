using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;

namespace Project.App.ViewModels;

public partial class SubjectListViewModel(
    ISubjectFacade subjectFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<SubjectEditMessage>, IRecipient<SubjectDeleteMessage>
{
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;
    private string Code { get; set; } = string.Empty;
    private string Name { get; set; } = string.Empty;
    
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Subjects = await subjectFacade.GetAsync();
    }
    
    [RelayCommand]
    private async Task SortAsync()
    {
        await base.LoadDataAsync();
        Subjects = await subjectFacade.GetSortAsync();
    }
    
    [RelayCommand]
    private async Task GetFilteredAsync()
    {
        await base.LoadDataAsync();
    
        Subjects = await subjectFacade.GetByNameAsync(Code, Name);
    }
    
    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        await navigationService.GoToAsync("/edit");
    }
    
    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
    {
        await navigationService.GoToAsync<SubjectDetailViewModel>(
            new Dictionary<string, object?> { [nameof(SubjectDetailViewModel.Id)] = id });
    }
    
    public async void Receive(SubjectEditMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(SubjectDeleteMessage message)
    {
        await LoadDataAsync();
    }
}