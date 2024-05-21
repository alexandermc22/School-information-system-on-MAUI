using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.App.ViewModels;

namespace Project.App.Views.Student;

public partial class StudentEditView : ContentPageBase
{
    public StudentEditView(StudentEditViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
        // BindingContext = App.Services.GetRequiredService<StudentEditViewModel>();
    }
}