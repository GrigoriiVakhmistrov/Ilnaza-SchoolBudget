using System;
using AndrApp.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using AndrApp.Views;
using System.Diagnostics;

namespace AndrApp.ViewModels
{
    public class OperationsViewModel : BaseViewModel
    {
        private Operation selectedItem;
        private int sel;

        public int Sel
        {
            get => sel;
            set
            {
                sel = value;
                Debug.WriteLine(sel);
                OnPropertyChanged();
            }
        }

        public Command LoadOperationsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Operation> ItemTapped { get; }
        private ObservableCollection<Operation> operations;

        public ObservableCollection<Operation> Operations
        {
            get => operations;
            set
            {
                operations = value;
                OnPropertyChanged();
            }
        }

        public OperationsViewModel()
        {
            LoadOperationsCommand = new Command(async () => await ExecuteLoadOperationsCommand());

            ItemTapped = new Command<Operation>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            Operations = new ObservableCollection<Operation>();
        }

        private async Task ExecuteLoadOperationsCommand()
        {
            IsBusy = true;

            try
            {
                Operations.Clear();
                var items = await Data.GetOperations();
                foreach (var item in items)
                {
                    Operations.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Operation SelectedItem
        {
            get => selectedItem;
            set
            {
                SetProperty(ref selectedItem, value);
                OnItemSelected(value);
            }
        }

        private static async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(NewOperationPage)}");
        }

        private async void OnItemSelected(Operation item)
        {
            if (item == null)
                return;
            var items = await Data.GetOperations();
            sel = items.IndexOf(item);
            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(OperationDetailPage)}?Ind={sel}");
        }
    }
}