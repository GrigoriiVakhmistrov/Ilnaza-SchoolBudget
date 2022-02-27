using AndrApp.ViewModels;

namespace AndrApp.Views
{
    public partial class ItemsPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }
    }
}