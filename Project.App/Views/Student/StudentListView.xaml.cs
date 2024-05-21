
using Project.App.ViewModels;

namespace Project.App.Views.Student;

public partial class StudentListView: ContentPageBase
{
    public StudentListView(StudentListViewModel viewModel)
         : base(viewModel)
    {
        InitializeComponent();
        // BindingContext = App.Services.GetRequiredService<StudentListViewModel>();
    }
    
}