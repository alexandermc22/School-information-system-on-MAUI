using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Mappers;
using Project.BL.Models;
using Project.Common.Enum;
namespace Project.App.ViewModels.Grade;

[QueryProperty(nameof(Activity), nameof(Activity))]
public partial class GradeEditViewModel(
    IGradeFacade gradeFacade,
    IStudentFacade studentFacade,
    INavigationService navigationService,
    GradeModelMapper gradeModelMapper,
    IMessengerService messengerService)
    : ViewModelBase(messengerService)
{
    public ActivityDetailModel? Activity { get; set; }
    
    public ObservableCollection<StudentListModel> Students { get; set; } = new();
    
    public ObservableCollection<GradeScore> GradeValues { get; } = new ObservableCollection<GradeScore>(Enum.GetValues(typeof(GradeScore)).Cast<GradeScore >());
    
    public StudentListModel? StudentSelected { get; set; }
    
    public GradeDetailModel GradeNew { get; private set; }
    
    public DateTime DateStartSelected { get; set; }
    
    public TimeSpan TimeStartSelected { get; set; }
    
    protected async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Students.Clear();
        var students = await studentFacade.GetAsync();
        foreach (var student in students)
        {
            Students.Add(student);
            GradeNew = GetGradeNew();
        }
    }
    
    [RelayCommand]
    private async Task SaveAsync()
    {
        
        GradeNew.GradeDate = DateStartSelected + TimeStartSelected;
        Activity.Grades.Add(gradeModelMapper.MapToListModel(GradeNew));
        await gradeFacade.SaveAsync(GradeNew,Activity.Id);

        MessengerService.Send(new GradeEditMessage { GradeId = GradeNew.Id });

        navigationService.SendBackButtonPressed();
    }

    [RelayCommand]
    private async Task AddNewStudentToGradeAsync()
    {
        if (GradeNew is not null
            && StudentSelected is not null
            && Activity is not null)
        {
            gradeModelMapper.MapToExistingDetailModel(GradeNew, StudentSelected);

            await gradeFacade.SaveAsync(GradeNew, Activity.Id);
            Activity.Grades.Add(gradeModelMapper.MapToListModel(GradeNew));

            GradeNew = GetGradeNew();

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
            GradeValue = Common.Enum.GradeScore.None,
        };
    }
}