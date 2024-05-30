using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Mappers;
using Project.BL.Models;
namespace Project.App.ViewModels;

[QueryProperty(nameof(Student), nameof(Student))]
public partial class StudentSubjectsEditViewModel(
    ISubjectFacade subjectFacade,
    IStudentSubjectsFacade studentSubjectsFacade,
    IStudentSubjectsModelMapper studentSubjectsModelMapper,
    IAlertService alertService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService)
{
    public StudentDetailModel? Student { get; set; }
    
    public ObservableCollection<SubjectListModel> Subjects { get; set; } = new();

    public SubjectListModel? SubjectSelected { get; set; }
    
    public StudentSubjectsDetailModel? StudentSubjectsNew { get; private set; }
    
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Subjects.Clear();
        var subjects = await subjectFacade.GetAsync();
        foreach (var subject in subjects)
        {
            Subjects.Add(subject);
            StudentSubjectsNew = GetStudentSubjectsNew();
        }
    }
    
    [RelayCommand]
    private async Task AddNewSubjectToStudentAsync()
    {
        if (StudentSubjectsNew is not null 
            && SubjectSelected is not null
             && Student is not null)
        {
            
            studentSubjectsModelMapper.MapToExistingDetailModel(StudentSubjectsNew, SubjectSelected);

            var subjectList = studentSubjectsModelMapper.MapToListModel(StudentSubjectsNew);
            
            foreach (var subject in Student.StudentSubjects)
            {
                if (subject.SubjectId == subjectList.SubjectId)
                {
                    await alertService.DisplayAsync("Error", "Cannot add Subject, because its already added");
                    return;
                }
            }

            await studentSubjectsFacade.SaveAsync(StudentSubjectsNew, Student.Id);
            
            Student.StudentSubjects.Add(subjectList);

            StudentSubjectsNew = GetStudentSubjectsNew();

            MessengerService.Send(new StudentSubjectsAddMessage());
        }
    }

    [RelayCommand]
    private async Task UpdateSubjectAsync(StudentSubjectsListModel? model)
    {
        if (model is not null
            && Student is not null)
        {
            await studentSubjectsFacade.SaveAsync(model, Student.Id);

            MessengerService.Send(new StudentSubjectsEditMessage());
        }

    }

    [RelayCommand]
    private async Task RemoveSubjectAsync(StudentSubjectsListModel model)
    {
        if (Student is not null)
        {
            await studentSubjectsFacade.DeleteAsync(model.Id);
            Student.StudentSubjects.Remove(model);

            MessengerService.Send(new StudentSubjectsDeleteMessage());
        }
    }
    
    
    private StudentSubjectsDetailModel GetStudentSubjectsNew()
    {
        var subjectFirst = Subjects.First();
        return new()
        {
            Id = Guid.NewGuid(),
            SubjectId = subjectFirst.Id,
            SubjectCode = subjectFirst.Code,
            SubjectName = subjectFirst.Name,
            SubjectImageUrl = subjectFirst.ImageUrl
        };
    }
    

}