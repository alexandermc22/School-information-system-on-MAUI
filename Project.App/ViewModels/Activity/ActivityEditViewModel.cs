using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Mappers;
using Project.BL.Models;
using Project.Common.Enum;

namespace Project.App.ViewModels.Activity;

[QueryProperty(nameof(Subject), nameof(Subject))]
[QueryProperty(nameof(Activity), nameof(Activity))]
public partial class ActivityEditViewModel(    
    IActivityFacade activityFacade,
    ISubjectFacade subjectFacade,
    INavigationService navigationService,
    IAlertService alertService,
    IActivityModelMapper activityModelMapper,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<ActivityEditMessage>, IRecipient<ActivityDeleteMessage>
{
    public ActivityDetailModel Activity { get; set; } = ActivityDetailModel.Empty;
    public SubjectDetailModel Subject { get; set; } = SubjectDetailModel.Empty;
    
    
    
    [RelayCommand]
    private async Task SaveAsync()
    {
        Activity.ActivityStartTime = DateStartSelected.Date + TimeStartSelected;
        Activity.ActivityEndTime = DateEndSelected.Date + TimeEndSelected;
        if (Activity.ActivityType == string.Empty || Activity.ActivityRoom==string.Empty)
        {
            alertService.DisplayAsync("Error", "You must enter activity type and room");
        }
        else if(Activity.ActivityStartTime >= Activity.ActivityEndTime )
        {
            alertService.DisplayAsync("Error", "Wrong Date");
        }
        else
        {
            Subject.Activities.Add(activityModelMapper.MapToListModel(Activity));
            subjectFacade.SaveAsync(Subject);
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
    
    
    public DateTime DateEndSelected { get; set; }
    
    public TimeSpan TimeEndSelected { get; set; }
    
    public DateTime DateStartSelected { get; set; }
    
    public TimeSpan TimeStartSelected { get; set; }
    
    
}