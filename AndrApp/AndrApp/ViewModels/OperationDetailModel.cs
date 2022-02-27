using System;
using System.Diagnostics;
using Xamarin.Forms;
using AndrApp.Views;

namespace AndrApp.ViewModels
{
    //[QueryProperty(nameof(ItemId), nameof(OperationsViewModel.ItemTapped))]
    [QueryProperty(nameof(ItemId), "Ind")]
    public class OperationDetailModel : BaseViewModel
    {
        public Command AddItemCommand { get; }
        private double aftconvert;

        public double Aftconvert
        {
            get => aftconvert;
            set => SetProperty(ref aftconvert, value);
        }

        private string currency;

        private string itemId;
        //private string text;

        private string category;
        private double value1;
        private string name;
        private DateTime dataTime;
        private string geo;
        private bool reg;

        public bool Regular
        {
            get => reg;
            set => SetProperty(ref reg, value);
        }

        public Command delthis { get; set; }
        private Page page;

        public OperationDetailModel(Page p)
        {
            page = p;
            AddItemCommand = new Command(OnAddItem);
            delthis = new Command(DelOperation);
        }

        async void DelOperation()
        {
            if (ItemId == null)
                return;
            var answer = await page.DisplayAlert("Подтверждение", $"Вы точно хтите удалить операцию?", "Да", "Нет");
            if (answer)
            {
                await Data.DeleteOperationAsync(Convert.ToInt32(ItemId));
                await Shell.Current.GoToAsync("..");
            }
        }

        private async void OnAddItem(object obj)
        {
            Debug.WriteLine($"/n/n/n/n{ItemId}");

            await Shell.Current.GoToAsync($"//{nameof(NewOperationPage)}?Id={ItemId}");
        }

        public string Currency
        {
            get => currency;
            set => SetProperty(ref currency, value);
        }

        //public string Id { get; set; }
        public string Name
        {
            get { return name; }
            set => SetProperty(ref name, value);
        }

        public double Value
        {
            get => value1;
            set => SetProperty(ref value1, value);
        }

        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }

        public DateTime DateTime1
        {
            get => dataTime;
            set => SetProperty(ref dataTime, value);
        }

        public string Geo
        {
            get => geo;
            set => SetProperty(ref geo, value);
        }


        public string ItemId
        {
            get { return itemId; }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string item)

        {
            try
            {
                var ser = Data.GetOperations().Result[Convert.ToInt32(item)];
                Name = ser.Name;
                Category = ser.Category;
                Value = ser.Value;
                DateTime1 = ser.DateAdd;
                Geo = ser.Geodata.Link;
                Regular = ser.Regular;
                Currency = ser.Currency;
                Aftconvert = ser.Aftconvert;
            }
            catch (Exception)
            {
                Debug.WriteLine($"/n/n/n/n{item}");
            }
        }
    }
}