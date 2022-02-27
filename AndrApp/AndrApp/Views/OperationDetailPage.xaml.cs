using System;
using AndrApp.ViewModels;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace AndrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OperationDetailPage
    {
        private readonly OperationDetailModel model;

        public OperationDetailPage()
        {
            InitializeComponent();
            model = new OperationDetailModel(this);
            BindingContext = model;
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            Launcher.TryOpenAsync(model.Geo);
        }
    }
}