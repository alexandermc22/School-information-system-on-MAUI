using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;

namespace Project.App.ViewModels;

[QueryProperty(nameof(Student), nameof(Student))]
public partial class StudentEditViewModel(
    IAlertService alertService,
    IStudentFacade studentFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService),
        IRecipient<StudentSubjectsDeleteMessage>,
        IRecipient<StudentSubjectsAddMessage>,
        IRecipient<StudentSubjectsEditMessage>
{
    public StudentDetailModel Student { get; set; } = StudentDetailModel.Empty;
    
    [RelayCommand]
    public async Task SaveAsync()
    {
        await studentFacade.SaveAsync(Student with{StudentSubjects = default!});

        MessengerService.Send(new StudentEditMessage { StudentId = Student.Id });

        navigationService.SendBackButtonPressed();
    }
    
    [RelayCommand]
    private async Task GoToStudentSubjectsEditAsync()
    {
        await navigationService.GoToAsync("/studentsubjects",
            new Dictionary<string, object?> { [nameof(StudentSubjectsEditViewModel.Student)] = Student });
    }
    
    public async void Receive(StudentSubjectsDeleteMessage message)
    {
        await ReloadDataAsync();
    }

    public async void Receive(StudentSubjectsAddMessage message)
    {
        await ReloadDataAsync();
    }

    public async void Receive(StudentSubjectsEditMessage message)
    {
        await ReloadDataAsync();
    }
    private async Task ReloadDataAsync()
    {
        Student = await studentFacade.GetAsync(Student.Id)
                 ?? StudentDetailModel.Empty;
    }
}