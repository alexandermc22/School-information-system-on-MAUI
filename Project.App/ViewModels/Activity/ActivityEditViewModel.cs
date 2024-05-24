using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;
namespace Project.App.ViewModels.Activity;

[QueryProperty(nameof(Subject), nameof(Subject))]
[QueryProperty(nameof(Activity), nameof(Activity))]
public partial class ActivityEditViewModel(    
    IActivityFacade activityFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<ActivityEditMessage>, IRecipient<ActivityDeleteMessage>
{
    public ActivityDetailModel Activity { get; set; } = ActivityDetailModel.Empty;
    public SubjectDetailModel Subject { get; set; } = SubjectDetailModel.Empty;
    
    [RelayCommand]
    private async Task SaveAsync()
    {
        await activityFacade.SaveAsync(Activity,Subject.Id);

        MessengerService.Send(new ActivityEditMessage { ActivityId = Activity.Id });

        navigationService.SendBackButtonPressed();
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
    
    public void DateSelected(object sender, DateChangedEventArgs e)
    {
        Activity.ActivityStartTime = e.NewDate;
    }
    
    
}