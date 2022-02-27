using AndrApp.Views;
using Xamarin.Forms;

namespace AndrApp.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        private bool wrong;
        private bool loading;
        public string Login { get; set; }
        public string Password { get; }

        public bool Loading
        {
            get => loading;
            set
            {
                loading = value;
                OnPropertyChanged();
            }
        }

        public bool Wrong
        {
            get => wrong;
            set
            {
                wrong = value;
                OnPropertyChanged();
            }
        }

        public Command EnterCommand
        {
            get => new Command(Enter);
        }

        public Command RegisterCommand
        {
            get => new Command(Register);
        }

        public AuthViewModel()
        {
            var au = Data.IsAthorised();
            au.Wait();
            if (au.Result)
            {
                Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
        }

        private async void Enter()
        {
            var serignore = (Login == "#NO_SERV");
            Loading = true;
            var res = Data.Authorise(Login, Password, serignore);
            res.Wait();

            if (res.Result)
            {
                Application.Current.MainPage = new AppShell(); // костыль, но пусть так 
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else
            {
                Wrong = true;
            }

            Loading = false;
        }

        private static void Register()
        {
        }
    }
}