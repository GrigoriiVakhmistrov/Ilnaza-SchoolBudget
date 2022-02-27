using AndrApp.ViewModels;
using AndrApp.Views;
using System;
using Xamarin.Forms;

namespace AndrApp
{
    public partial class AppShell
    {
        ShellViewModel shellViewModel;

        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(Auth), typeof(Auth));
            Routing.RegisterRoute(nameof(OperationDetailPage), typeof(OperationDetailPage));
            shellViewModel = new ShellViewModel(this);
            BindingContext = shellViewModel;
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}