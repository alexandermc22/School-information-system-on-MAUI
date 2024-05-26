using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;
namespace Project.App.ViewModels.Grade;

[QueryProperty(nameof(Activity), nameof(Activity))]
public partial class GradeListViewModel( 
    IGradeFacade gradeFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<GradeEditMessage>, IRecipient<GradeDeleteMessage>
{
    public ActivityDetailModel Activity { get; set; } = ActivityDetailModel.Empty;
    public IEnumerable<GradeListModel> Grade { get; set; } = null!;
    
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Grade = await  gradeFacade.GetGradeAsync(Activity.Id); //TODO check null
    }

    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
        => await navigationService.GoToAsync<GradeDetailViewModel>(
            new Dictionary<string, object?> { [nameof(GradeDetailViewModel.Id)] = id });

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        await navigationService.GoToAsync("/edit");
    }

    public async void Receive(GradeEditMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(GradeDeleteMessage message)
    {
        await LoadDataAsync();
    }
}