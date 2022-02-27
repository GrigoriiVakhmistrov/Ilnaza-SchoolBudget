using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AndrApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            ToLogin = new Command(async () => await Shell.Current.GoToAsync("//LoginPage"));
        }

        public ICommand OpenWebCommand { get; }
        public ICommand ToLogin { get; }
    }
}