﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.App.ViewModels.Activity;

namespace Project.App.Views.Activity;

public partial class ActivityDetailView
{
    public ActivityDetailView(ActivityDetailViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
        // BindingContext = App.Services.GetRequiredService<StudentListViewModel>();
    }
}