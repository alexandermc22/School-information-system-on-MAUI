using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Project.App.ViewModels.Grade;

namespace Project.App.Views.Grade;

public partial class GradeEditView
{
    public GradeEditView(GradeEditViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}