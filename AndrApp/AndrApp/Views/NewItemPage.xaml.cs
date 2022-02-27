using AndrApp.Models;
using AndrApp.ViewModels;

namespace AndrApp.Views
{
    public partial class NewItemPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}