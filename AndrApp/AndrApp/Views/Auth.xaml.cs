using AndrApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace AndrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Auth
    {
        public Auth()
        {
            InitializeComponent();
            BindingContext = new AuthViewModel();
        }
    }
}