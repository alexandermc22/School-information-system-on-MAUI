using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;

namespace Project.App.ViewModels;

public partial class SubjectListViewModel(
    // IStudentFacade studentFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<SubjectEditMessage>, IRecipient<SubjectDeleteMessage>
{
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;
    

    
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        // Students = await studentFacade.GetAsync();
    }
    
    // [RelayCommand]
    // private async Task GoToCreateAsync()
    // {
    //     await navigationService.GoToAsync("/edit");
    // }
    //
    // [RelayCommand]
    // private async Task GoToDetailAsync(Guid id)
    // {
    //     await navigationService.GoToAsync<StudentDetailViewModel>(
    //         new Dictionary<string, object?> { [nameof(StudentDetailViewModel.Id)] = id });
    // }
    
    public async void Receive(SubjectEditMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(SubjectDeleteMessage message)
    {
        await LoadDataAsync();
    }
}