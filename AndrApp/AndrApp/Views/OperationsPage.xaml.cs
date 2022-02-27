using AndrApp.ViewModels;

namespace AndrApp.Views
{
    public partial class OperationsPage
    {
        private readonly OperationsViewModel viewModel;

        public OperationsPage()
        {
            //Shell.Current.GoToAsync($"//Auth");
            InitializeComponent();
            BindingContext = viewModel = new OperationsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}