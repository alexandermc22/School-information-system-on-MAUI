using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Mappers;
using Project.BL.Models;
namespace Project.App.ViewModels.Grade;

[QueryProperty(nameof(Activity), nameof(Activity))]
[QueryProperty(nameof(Grade), nameof(Grade))]
[QueryProperty(nameof(Subject), nameof(Subject))]

public partial class GradeEditViewModel(
    IGradeFacade gradeFacade,
    IStudentFacade studentFacade,
    INavigationService navigationService,
    IAlertService alertService,
    IGradeModelMapper gradeModelMapper,
    IMessengerService messengerService)
    : ViewModelBase(messengerService) 
{
    public ActivityDetailModel? Activity { get; set; }
    
    public SubjectDetailModel? Subject { get; set; }

    public ObservableCollection<StudentListModel> Students { get; set; } = new();
    
    public List<Common.Enum.Grade> Grades { get; set; } = new((Common.Enum.Grade[])Enum.GetValues(typeof(Common.Enum.Grade)));
    public StudentListModel? StudentSelected { get; set; }
    
    public GradeDetailModel Grade { get; private set; }
    
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Students.Clear();
        var students = await studentFacade.GetAsync();
        foreach (var student in students)
        {
            var studentDetail = await studentFacade.GetAsync(student.Id);
            foreach (var subject in studentDetail.StudentSubjects)
            {
                if (subject.SubjectId == Subject.Id)
                {
                    Students.Add(student);
                    Grade = GetGradeNew();
                    break;
                }
            }
            
        }
    }

    [RelayCommand]
    private async Task AddNewStudentToGradeAsync()
    {
        if (Grade is not null
            && StudentSelected is not null
            && Activity is not null)
        {
            foreach (var grade in Activity.Grades)
            {
                if (grade.StudentId == StudentSelected.Id)
                {
                    await alertService.DisplayAsync("Error", "Cannot add Student, because its already added");
                    return;
                }
            }
            gradeModelMapper.MapToExistingDetailModel(Grade, StudentSelected);

            Grade = await gradeFacade.SaveAsync(Grade, Activity.Id);
            Activity.Grades.Add(gradeModelMapper.MapToListModel(Grade));

            Grade = GetGradeNew();

            MessengerService.Send(new GradeEditMessage(){GradeId = Grade.Id});
        }
    }
    
    [RelayCommand]
    private async Task UpdateStudentAsync(GradeListModel? model)
    {
        if (model is not null
            && Activity is not null)
        {
            await gradeFacade.SaveAsync(model, Activity.Id);

            MessengerService.Send(new GradeEditMessage(){GradeId = Grade.Id});
        }
    }

    [RelayCommand]
    private async Task RemoveGradeAsync(GradeListModel model)
    {
        if (Activity is not null)
        {
            await gradeFacade.DeleteAsync(model.Id);
            Activity.Grades.Remove(model);

            MessengerService.Send(new GradeDeleteMessage());
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