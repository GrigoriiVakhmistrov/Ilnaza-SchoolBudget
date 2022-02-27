using System.Collections.ObjectModel;

namespace AndrApp.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        AppShell shell;
        private string login;
        private ObservableCollection<string> budgets;


        public ShellViewModel(AppShell app)
        {
            shell = app;
            //shell.Log.Text = Data.GetLogin().Result;// Подумать 
            //shell.Buds = Data.GetBudgets().Result;
            LoginShow = Data.GetLogin().Result;
            Budgets = Data.GetBudgets().Result;
        }


        public string LoginShow
        {
            get => login;


            set => SetProperty(ref login, value);
        }

        public ObservableCollection<string> Budgets
        {
            get => budgets;
            set => SetProperty(ref budgets, value);
        }

        public int Index
        {
            get { return 0; }
            set { Data.SetBud(value); }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}