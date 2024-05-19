using Project.App.ViewModels;

namespace Project.App.Views.Subject;

public partial class SubjectListView: ContentPageBase
{
    public SubjectListView(SubjectListViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }

    private void OnSubjectsClicked(object sender, EventArgs e)
    {
         
    }
}