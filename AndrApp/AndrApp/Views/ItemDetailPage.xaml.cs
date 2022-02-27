using AndrApp.ViewModels;

namespace AndrApp.Views
{
    public partial class ItemDetailPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}