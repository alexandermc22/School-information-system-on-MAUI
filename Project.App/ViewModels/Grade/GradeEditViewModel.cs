using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;
namespace Project.App.ViewModels.Grade;

[QueryProperty(nameof(Grade), nameof(Grade))]
public partial class GradeEditViewModel(
    IGradeFacade gradeFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService)
{
    public GradeDetailModel Grade { get; set; } = GradeDetailModel.Empty;
    
    public ObservableCollection<StudentListModel> Students { get; set; } = new();

    public StudentListModel? StudentSelected { get; set; }

    // public IngredientAmountDetailModel? IngredientAmountNew { get; private set; }
    
    [RelayCommand]
    private async Task SaveAsync()
    {
        await gradeFacade.SaveAsync(Grade);

        // MessengerService.Send(new IngredientEditMessage { IngredientId = Ingredient.Id });

        navigationService.SendBackButtonPressed();
    }
    

}