using System;
using AndrApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndrApp.Views
{
    //[QueryProperty(nameof(Name), "name")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOperationPage
    {
        NewOperationViewModel viewModel;

        public NewOperationPage()
        {
            InitializeComponent();
            viewModel = new NewOperationViewModel();
            BindingContext = new NewOperationViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //BindingContext = new NewOperationViewModel();
        }

        private void selfgeo_OnChanged(object sender, ToggledEventArgs e)
        {
            s1.IsEnabled = !selfgeo.On;
            s2.IsEnabled = !selfgeo.On;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // name.Text = pic.SelectedItem.ToString();
        }
    }
}