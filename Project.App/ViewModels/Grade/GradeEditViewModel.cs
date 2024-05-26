using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Mappers;
using Project.BL.Models;
namespace Project.App.ViewModels.Grade;

[QueryProperty(nameof(Activity), nameof(Activity))]
[QueryProperty(nameof(Grade), nameof(Grade))]
public partial class GradeEditViewModel(
    IGradeFacade gradeFacade,
    IStudentFacade studentFacade,
    INavigationService navigationService,
    IGradeModelMapper gradeModelMapper,
    IMessengerService messengerService)
    : ViewModelBase(messengerService)
{
    public ActivityDetailModel? Activity { get; set; }
    
    public ObservableCollection<StudentListModel> Students { get; set; } = new();
    
    public StudentListModel? StudentSelected { get; set; }
    
    public GradeDetailModel Grade { get; private set; }
    
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Students.Clear();
        var students = await studentFacade.GetAsync();
        foreach (var student in students)
        {
            Students.Add(student);
            Grade = GetGradeNew();
        }
    }

    [RelayCommand]
    private async Task AddNewStudentToGradeAsync()
    {
        if (Grade is not null
            && StudentSelected is not null
            && Activity is not null)
        {
            gradeModelMapper.MapToExistingDetailModel(Grade, StudentSelected);

            await gradeFacade.SaveAsync(Grade, Activity.Id);
            Activity.Grades.Add(gradeModelMapper.MapToListModel(Grade));

            Grade = GetGradeNew();

            // MessengerService.Send(new RecipeIngredientAddMessage());
        }
    }
    
    [RelayCommand]
    private async Task UpdateStudentAsync(GradeListModel? model)
    {
        if (model is not null
            && Activity is not null)
        {
            await gradeFacade.SaveAsync(model, Activity.Id);

            // MessengerService.Send(new RecipeIngredientEditMessage());
        }
    }

    [RelayCommand]
    private async Task RemoveIngredientAsync(GradeListModel model)
    {
        if (Activity is not null)
        {
            await gradeFacade.DeleteAsync(model.Id);
            Activity.Grades.Remove(model);

            // MessengerService.Send(new RecipeIngredientDeleteMessage());
        }
    }
    
    private GradeDetailModel GetGradeNew()
    {
        var studentFirst = Students.First();
        return new()
        {
            ActivityId = Activity.Id,
            Id = Guid.NewGuid(),
            StudentId = studentFirst.Id,
            StudentName = studentFirst.LastName +" " + studentFirst.FirstName,
            Description = string.Empty,
            GradeDate = DateTime.Today,
            GradeValue = Common.Enum.Grade.None,
        };
    }
}