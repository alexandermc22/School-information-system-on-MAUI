﻿using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;
namespace Project.App.ViewModels.Activity;


[QueryProperty(nameof(Subject), nameof(Subject))]
public partial class ActivityListViewModel(
    IActivityFacade activityFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<ActivityEditMessage>, IRecipient<ActivityDeleteMessage>
{
    
    public SubjectDetailModel Subject { get; set; } = SubjectDetailModel.Empty;
    public IEnumerable<ActivityListModel> Activity { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Activity = await activityFacade.GetActivityAsync(Subject.Id); //TODO check null
    }


    [RelayCommand]
    private async Task GetFilteredAsync(DateTime startTime, DateTime endTime)
    {
        await base.LoadDataAsync();
    
        Activity = await activityFacade.GetFilteredAsync(Subject.Id, startTime, endTime);
    }
    
    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
        => await navigationService.GoToAsync<ActivityDetailViewModel>(
            new Dictionary<string, object?> { [nameof(ActivityDetailViewModel.Id)] = id });

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        await navigationService.GoToAsync("/editActivity",
            new Dictionary<string, object?> { [nameof(ActivityEditViewModel.Subject)] = Subject });
    }

    // private async Task GoToCreateAsync<ActivityEditViewModel>()
    // {
    //     await navigationService.GoToAsync<ActivityEditViewModel>();
    // }

    public async void Receive(ActivityEditMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(ActivityDeleteMessage message)
    {
        await LoadDataAsync();
    }
    
}