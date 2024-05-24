using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;
using Project.Common.Enum;

namespace Project.App.ViewModels.Activity;

[QueryProperty(nameof(Subject), nameof(Subject))]
[QueryProperty(nameof(Activity), nameof(Activity))]
public partial class ActivityEditViewModel(    
    IActivityFacade activityFacade,
    INavigationService navigationService,
    IAlertService alertService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<ActivityEditMessage>, IRecipient<ActivityDeleteMessage>
{
    public ActivityDetailModel Activity { get; set; } = ActivityDetailModel.Empty;
    public SubjectDetailModel Subject { get; set; } = SubjectDetailModel.Empty;
    
    [RelayCommand]
    private async Task SaveAsync()
    {
        if (Activity.ActivityType == string.Empty)
        {
            alertService.DisplayAsync("Error", "You must enter activity type");
        }
        else
        {
            Activity.Duration = Activity.ActivityEndTime - Activity.ActivityStartTime;
            await activityFacade.SaveAsync(Activity,Subject.Id);

            MessengerService.Send(new ActivityEditMessage { ActivityId = Activity.Id });

            navigationService.SendBackButtonPressed();
        }
    }
    
    public async void Receive(ActivityEditMessage message)
    {
        await ReloadDataAsync();
    }

    public async void Receive(ActivityDeleteMessage message)
    {
        await ReloadDataAsync();
    }
    
    private async Task ReloadDataAsync()
    {
        Activity = await activityFacade.GetAsync(Activity.Id)
                  ?? ActivityDetailModel.Empty;
    }
    
    public DateTime DateTimeStartSelected
    {
        get => Activity.ActivityStartTime;
        set
        {
            if (Activity.ActivityStartTime != value)
            {
                Activity.ActivityStartTime = value;
                // OnPropertyChanged(); // Вызов PropertyChanged для уведомления об изменении
            }
        }
    }
    
    public DateTime DateTimeEndSelected
    {
        get => Activity.ActivityEndTime;
        set
        {
            if (Activity.ActivityEndTime != value)
            {
                Activity.ActivityEndTime = value;
                // OnPropertyChanged(); // Вызов PropertyChanged для уведомления об изменении
            }
        }
    }
    
    
}