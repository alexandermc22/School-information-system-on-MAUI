using Project.App.Models;
using Project.App.ViewModels;
using Project.App.ViewModels.Activity;
using Project.App.ViewModels.Grade;
using Project.App.Views.Activity;
// using FirstProject.App.Views.Ingredient;
using Project.App.Views.Student;
using Project.App.Views.Subject;

namespace Project.App.Services;

public class NavigationService : INavigationService
{
    public IEnumerable<RouteModel> Routes { get; } = new List<RouteModel>
    {
        new("//subjects", typeof(SubjectListView), typeof(SubjectListViewModel)),
        new("//subjects/detail", typeof(SubjectDetailView), typeof(SubjectDetailViewModel)),
        new("//subjects/edit", typeof(SubjectEditView), typeof(SubjectEditViewModel)),
        new("//subjects/detail/edit", typeof(SubjectEditView), typeof(SubjectEditViewModel)),
        
        new("//subjects/detail/activity", typeof(ActivityListView), typeof(ActivityListViewModel)),
        // new("//subjects/detail/activity/detail", typeof(ActivityDetailView), typeof(ActivityDetailViewModel)),
        // new("//subjects/detail/activity/edit", typeof(ActivityEditView), typeof(ActivityEditViewModel)),
        // new("//subjects/detail/activity/detail/edit", typeof(ActivityEditView), typeof(ActivityEditViewModel)),
        //
        //
        // new("//subjects/detail/activity/detail/grade", typeof(GradeListView), typeof(GradeListViewModel)),
        //
        // new("//subjects/detail/activity/detail/grade/detail", typeof(GradeDetailView), typeof(GradeDetailViewModel)),
        // new("//subjects/detail/activity/detail/grade/edit", typeof(GradeEditView), typeof(GradeEditViewModel)),
        // new("//subjects/detail/activity/detail/grade/edit/edit", typeof(GradeEditView), typeof(GradeEditViewModel)),

        
        new("//students", typeof(StudentListView), typeof(StudentListViewModel)),
        new("//students/detail", typeof(StudentDetailView), typeof(StudentDetailViewModel)),
        new("//students/edit/studentsubjects", typeof(StudentSubjectsEditView), typeof(StudentSubjectsEditViewModel)),
        new("//students/edit", typeof(StudentEditView), typeof(StudentEditViewModel)),
        new("//students/detail/edit", typeof(StudentEditView), typeof(StudentEditViewModel)),
        new("//students/detail/edit/studentsubjects", typeof(StudentSubjectsEditView), typeof(StudentSubjectsEditViewModel)),
    };

    public async Task GoToAsync<TViewModel>()
        where TViewModel : IViewModel
    {
        var route = GetRouteByViewModel<TViewModel>();
        await Shell.Current.GoToAsync(route);
    }
    public async Task GoToAsync<TViewModel>(IDictionary<string, object?> parameters)
        where TViewModel : IViewModel
    {
        var route = GetRouteByViewModel<TViewModel>();
        await Shell.Current.GoToAsync(route, parameters);
    }

    public async Task GoToAsync(string route)
        => await Shell.Current.GoToAsync(route);

    public async Task GoToAsync(string route, IDictionary<string, object?> parameters)
        => await Shell.Current.GoToAsync(route, parameters);

    public bool SendBackButtonPressed()
        => Shell.Current.SendBackButtonPressed();

    private string GetRouteByViewModel<TViewModel>()
        where TViewModel : IViewModel 
        => Routes.First(route => route.ViewModelType == typeof(TViewModel)).Route;
}