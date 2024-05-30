
using Project.App.ViewModels;

namespace Project.App.Views.Student;

public partial class StudentDetailView: ContentPageBase
{
    public StudentDetailView(StudentDetailViewModel viewModel)
          : base(viewModel)
    {
        InitializeComponent();
        // BindingContext = App.Services.GetRequiredService<StudentDetailViewModel>();
    }
}