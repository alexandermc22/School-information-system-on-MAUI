using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.App.ViewModels;

namespace Project.App.Views.Student;

public partial class StudentSubjectsEditView 
{
    public StudentSubjectsEditView(StudentSubjectsEditViewModel editViewModel)
        : base(editViewModel)
    {
        InitializeComponent();
    }
}