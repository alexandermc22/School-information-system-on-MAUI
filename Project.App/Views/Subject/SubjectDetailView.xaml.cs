using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.App.ViewModels;

namespace Project.App.Views.Subject;

public partial class SubjectDetailView 
{
    public SubjectDetailView(SubjectDetailViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}