using Project.App.Models;
using Project.App.ViewModels;
// using FirstProject.App.Views.Ingredient;
using Project.App.Views.Student;
using Project.App.Views.Subject;

namespace Project.App.Services;

public class NavigationService : INavigationService
{
    public IEnumerable<RouteModel> Routes { get; } = new List<RouteModel>
    {
        new("//subject", typeof(SubjectListView), typeof(SubjectListViewModel)),
        // new("//subject/detail", typeof(SubjectDetailView), typeof(SubjectDetailViewModel)),
        
        // new("//subject/edit", typeof(SubjectEditView), typeof(SubjectEditViewModel)),
        // new("//subject/detail/edit", typeof(SubjectEditView), typeof(SubjectEditViewModel)),
        // new("//subject/detail/activity", typeof(ActivityView), typeof(ActivityViewModel)),
        // new("//subject/detail/activity/detail", typeof(ActivityView), typeof(ActivityViewModel)),
        // new("//subject/detail/activity/detail/edit", typeof(ActivityView), typeof(ActivityViewModel)),
        //
        // new("//subject/detail/activity/detail/grade", typeof(GradeView), typeof(ActivityEditViewModel)),
        //
        // new("//subject/detail/activity/detail/grade/detail", typeof(ActivityView), typeof(ActivityViewModel)),
        // new("//subject/detail/activity/detail/grade/detail/edit", typeof(ActivityView), typeof(ActivityViewModel)),
        //
        new("//students", typeof(StudentListView), typeof(StudentListViewModel)),
        new("//students/detail", typeof(StudentDetailView), typeof(StudentDetailViewModel)),
        
        new("//students/edit", typeof(StudentEditView), typeof(StudentEditViewModel)),
        new("//students/detail/edit", typeof(StudentEditView), typeof(StudentEditViewModel)),
        
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