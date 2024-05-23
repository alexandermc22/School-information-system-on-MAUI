using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;
namespace Project.App.ViewModels;


[QueryProperty(nameof(Id), nameof(Id))]
public partial class StudentDetailViewModel(
    IStudentFacade studentFacade,
    INavigationService navigationService,
    IMessengerService messengerService,
    IAlertService alertService)
    : ViewModelBase(messengerService), IRecipient<StudentEditMessage>,
        IRecipient<StudentSubjectsDeleteMessage>,
        IRecipient<StudentSubjectsAddMessage>
{
    public Guid Id { get; set; }
    public StudentDetailModel? Student { get; private set; }
    
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Student = await studentFacade.GetAsync(Id);
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (Student is not null)
        {
            try
            {
                await studentFacade.DeleteAsync(Student.Id);
                MessengerService.Send(new StudentDeleteMessage());
                navigationService.SendBackButtonPressed();
            }
            catch (InvalidOperationException)
            {
                await alertService.DisplayAsync("StudentDetailViewModelTexts.DeleteError_Alert_Title", "StudentDetailViewModelTexts.DeleteError_Alert_Message");
            }
        }
    }

    [RelayCommand]
    private async Task GoToEditAsync()
    {
        await navigationService.GoToAsync("/edit",
            new Dictionary<string, object?> { [nameof(StudentEditViewModel.Student)] = Student });
    }

    public async void Receive(StudentEditMessage message)
    {
        if (message.StudentId == Student?.Id)
        {
            await LoadDataAsync();
        }
    }
    public async void Receive(StudentSubjectsDeleteMessage message)
    {
        await LoadDataAsync();
    }
    public async void Receive(StudentSubjectsAddMessage message)
    {
        await LoadDataAsync();
    }
}