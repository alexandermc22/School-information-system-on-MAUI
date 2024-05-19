
using Project.App.ViewModels;

namespace Project.App.Views.Student;

public partial class StudentListView: ContentPageBase
{
    public StudentListView(StudentListViewModel viewModel)
         : base(viewModel)
    {
        InitializeComponent();
    }

    private void OnSubjectsClicked(object sender, EventArgs e)
    {
         
    }
}