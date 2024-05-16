using CommunityToolkit.Mvvm.Input;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;

namespace Project.App.ViewModels;

[QueryProperty(nameof(Student), nameof(Student))]
public partial class StudentEditViewModel(
    IStudentFacade studentFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService)
{
    public StudentDetailModel Student { get; init; } = StudentDetailModel.Empty;
    
    [RelayCommand]
    private async Task SaveAsync()
    {
        await studentFacade.SaveAsync(Student);

        MessengerService.Send(new StudentEditMessage { StudentId = Student.Id });

        navigationService.SendBackButtonPressed();
    }

}