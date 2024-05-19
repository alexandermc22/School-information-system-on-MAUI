using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Models;

namespace Project.App.ViewModels;

public partial class SubjectListViewModel(
    // IStudentFacade studentFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<SubjectEditMessage>, IRecipient<SubjectDeleteMessage>
{
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null
    
     public SubjectListViewModel()
     {
                // Инициализация мок-данных
                Subjects = new IEnumerable<SubjectListModel>
                {
                    new SubjectListModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Math",
                        Code = "MATH101",
                        ImageUrl = new Uri("https://example.com/images/math.png")
                    },
                    new SubjectListModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Chemistry",
                        Code = "CHEM101",
                        ImageUrl = new Uri("https://example.com/images/chemistry.png")
                    },
                    new SubjectListModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Biology",
                        Code = "BIO101",
                        ImageUrl = new Uri("https://example.com/images/biology.png")
                    },
                    // Добавьте больше предметов по необходимости
                };
            }
    
    
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        // Students = await studentFacade.GetAsync();
    }
    
    // [RelayCommand]
    // private async Task GoToCreateAsync()
    // {
    //     await navigationService.GoToAsync("/edit");
    // }
    //
    // [RelayCommand]
    // private async Task GoToDetailAsync(Guid id)
    // {
    //     await navigationService.GoToAsync<StudentDetailViewModel>(
    //         new Dictionary<string, object?> { [nameof(StudentDetailViewModel.Id)] = id });
    // }
    
    public async void Receive(SubjectEditMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(SubjectDeleteMessage message)
    {
        await LoadDataAsync();
    }
}