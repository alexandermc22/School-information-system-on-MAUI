using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.App.ViewModels.Activity;

namespace Project.App.Views.Activity;

public partial class ActivityEditView
{
    public ActivityEditView(ActivityEditViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
        // BindingContext = App.Services.GetRequiredService<StudentListViewModel>();
    }
    
    // private void TimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    // {
    //     if (e.PropertyName == "Time")
    //     {
    //         label.Text = $"Вы выбрали {timePicker.Time}";
    //     }
    // }
    
   
    
}