using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;

namespace Project.App.ViewModels;

[QueryProperty(nameof(Subject), nameof(Subject))]
public partial class SubjectEditViewModel(
    ISubjectFacade subjectFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<SubjectEditMessage>,IRecipient<SubjectAddMessage>, IRecipient<SubjectDeleteMessage>

{
    public SubjectDetailModel Subject { get; set; } = SubjectDetailModel.Empty;
    
    


    [RelayCommand]
    private async Task SaveAsync()
    {
        await subjectFacade.SaveAsync(Subject with{ Activities = default!, SubjectStudents = default!});

        MessengerService.Send(new SubjectEditMessage { SubjectId = Subject.Id});

        navigationService.SendBackButtonPressed();
    }

    public async void Receive(SubjectEditMessage message)
    {
        await ReloadDataAsync();
    }

    public async void Receive(SubjectAddMessage message)
    {
        await ReloadDataAsync();
    }

    public async void Receive(SubjectDeleteMessage message)
    {
        await ReloadDataAsync();
    }

    private async Task ReloadDataAsync()
    {
        Subject = await subjectFacade.GetAsync(Subject.Id)
                 ?? SubjectDetailModel.Empty;
    }
}