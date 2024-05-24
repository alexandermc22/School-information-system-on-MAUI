using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;
namespace Project.App.ViewModels.Grade;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class GradeDetailViewModel(
    IGradeFacade gradeFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<GradeEditMessage>, IRecipient<ActivityGradeAddMessage>,
        IRecipient<GradeDeleteMessage>
{
    public Guid Id { get; set; }
    public GradeDetailModel? Grade { get; set; }
    
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Grade = await gradeFacade.GetAsync(Id);
    }
    
    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (Grade is not null)
        {
            await gradeFacade.DeleteAsync(Grade.Id);

            MessengerService.Send(new GradeDeleteMessage());

            navigationService.SendBackButtonPressed();
        }
    }


    [RelayCommand]
    private async Task GoToEditAsync()
    {
        if (Grade is not null)
        {
            // await navigationService.GoToAsync("/edit",
            //     new Dictionary<string, object?> { [nameof(GradeEditViewModel.Grade)] = Grade with { } });
        }
    }
    public async void Receive(GradeEditMessage message)
    {
        if (message.GradeId == Grade?.Id)
        {
            await LoadDataAsync();
        }
    }

    public async void Receive(ActivityGradeAddMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(GradeDeleteMessage message)
    {
        await LoadDataAsync();
    }
}