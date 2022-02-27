using AndrApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace AndrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel(this);
        }
    }
}