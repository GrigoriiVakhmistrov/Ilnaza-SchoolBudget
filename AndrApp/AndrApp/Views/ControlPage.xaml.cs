using AndrApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace AndrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlPage
    {
        public ControlPage()
        {
            InitializeComponent();

            BindingContext = new ControlViewModel(this);
        }
    }
}