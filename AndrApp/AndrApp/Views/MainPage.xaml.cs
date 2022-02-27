using AndrApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        private readonly MainViewModel mainView;

        public MainPage()
        {
            DevExpress.XamarinForms.Charts.Initializer.Init();
            Shell.Current.GoToAsync($"//{nameof(Auth)}");
            InitializeComponent();
            mainView = new MainViewModel();
            BindingContext = mainView;
        }

        protected override void OnAppearing()
        {
            mainView.Update();
        }
    }
}