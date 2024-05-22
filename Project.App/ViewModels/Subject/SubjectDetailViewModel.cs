using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;
namespace Project.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class SubjectDetailViewModel(
ISubjectFacade subjectFacade,
    INavigationService navigationService,
IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<SubjectEditMessage>,IRecipient<SubjectAddMessage>, IRecipient<SubjectDeleteMessage>
{
    public Guid Id { get; set; }
    public SubjectDetailModel? Subject { get; set; }
    
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Subject = await subjectFacade.GetAsync(Id);
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (Subject is not null)
        {
            await subjectFacade.DeleteAsync(Subject.Id);

            MessengerService.Send(new SubjectDeleteMessage());

            navigationService.SendBackButtonPressed();
        }
    }


    [RelayCommand]
    private async Task GoToEditAsync()
    {
        if (Subject is not null)
        {
            await navigationService.GoToAsync("/edit",
                new Dictionary<string, object?> { [nameof(SubjectEditViewModel.Subject)] = Subject });
        }
    }

    public async void Receive(SubjectEditMessage message)
    {
        if (message.SubjectId == Subject?.Id)
        {
            await LoadDataAsync();
        }
    }

    public async void Receive(SubjectAddMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(SubjectDeleteMessage message)
    {
        await LoadDataAsync();
    }
}