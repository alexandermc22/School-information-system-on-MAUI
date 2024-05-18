using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.App.ViewModels;

namespace Project.App.Views.Student;

public partial class StudentListView : ContentView
{
    public StudentListView(StudentListViewModel viewModel)
        // : base(viewModel)
    {
        InitializeComponent();
    }
}