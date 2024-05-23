using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.App.ViewModels.Grade;
using Project.BL.Facades;
using Project.BL.Models;
namespace Project.App.ViewModels.Activity;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class ActivityDetailViewModel(
    IActivityFacade activityFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<ActivityEditMessage>, IRecipient<ActivityGradeAddMessage>,
        IRecipient<ActivityGradeDeleteMessage>
{
    public Guid Id { get; set; }
    public ActivityDetailModel? Activity { get; set; }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Activity = await activityFacade.GetAsync(Id);
    }
    
    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (Activity is not null)
        {
            await activityFacade.DeleteAsync(Activity.Id);

            MessengerService.Send(new ActivityDeleteMessage());

            navigationService.SendBackButtonPressed();
        }
    }


    [RelayCommand]
    private async Task GoToEditAsync()
    {
        if (Activity is not null)
        {
            await navigationService.GoToAsync("/edit",
                new Dictionary<string, object?> { [nameof(ActivityEditViewModel.Activity)] = Activity with { } });
        }
    }
    
    private async Task GoToGradeAsync()
    {
        if (Activity is not null)
        {
            await navigationService.GoToAsync("/grade",
                new Dictionary<string, object?> { [nameof(GradeListViewModel.Activity)] = Activity with { } });
        }
    }

    public async void Receive(ActivityEditMessage message)
    {
        if (message.ActivityId == Activity?.Id)
        {
            await LoadDataAsync();
        }
    }

    public async void Receive(ActivityGradeAddMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(ActivityGradeDeleteMessage message)
    {
        await LoadDataAsync();
    }
}