﻿using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Project.App.Messages;
using Project.App.Services;
using Project.BL.Facades;
using Project.BL.Mappers;
using Project.BL.Models;
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
    
    public StudentListModel? StudentSelected { get; set; }
    
    public GradeDetailModel GradeNew { get; private set; }
    
    protected override async Task LoadDataAsync()
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