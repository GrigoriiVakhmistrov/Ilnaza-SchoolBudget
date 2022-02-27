using System;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;
using AndrApp.Models;
using AndrApp.Views;
using Xamarin.Essentials;

namespace AndrApp.ViewModels
{
    [QueryProperty(nameof(ItemId), "Id")]
    public class NewOperationViewModel : BaseViewModel
    {
        public Command AddItemCommand { get; }
        private bool editing;

        public bool Editing
        {
            get => editing;
            set => SetProperty(ref editing, value);
        }

        private double aftconvert;

        public double Aftconvert
        {
            get => aftconvert;
            set => SetProperty(ref aftconvert, value);
        }

        private string currency;


        private string category;
        private double value1;
        private string name;
        private DateTime dataTime;
        private GeoData geo;
        private bool reg;

        public bool Regular
        {
            get => reg;
            set => SetProperty(ref reg, value);
        }

        private string itemId;

        public string ItemId
        {
            get => itemId;
            set
            {
                load(value);
                // Debug.WriteLine(value);
                // LoadItemId(value);
            }
        }


        public string Currency
        {
            get => currency;
            set => SetProperty(ref currency, value);
        }

        public string Id { get; set; }

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

        private ObservableCollection<string> categories;

        public ObservableCollection<string> Categories
        {
            get => categories;
            set => SetProperty(ref categories, value);
        }

        public DateTime DateTime1
        {
            get => dataTime;
            set => SetProperty(ref dataTime, value);
        }

        private TimeSpan time;

        public TimeSpan Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }

        public GeoData Geo
        {
            get => geo;
            set => SetProperty(ref geo, value);
        }

        private float latitude;
        private float longitude;

        public float Latitude
        {
            get => latitude;
            set => SetProperty(ref latitude, value);
        }

        public float Longitude
        {
            get => longitude;
            set => SetProperty(ref longitude, value);
        }

        private bool selfgeo;

        public bool Selfgeo
        {
            get => selfgeo;
            set
            {
                selfgeo = value;
                OnPropertyChanged("Selfgeo ");
            }
        }


        public NewOperationViewModel()
        {
            Latitude = 55.755797F;
            Longitude = 37.617729F;
            DateTime1 = DateTime.Now;
            Time = new TimeSpan(DateTime1.Hour, DateTime1.Minute, DateTime1.Second);
            AddItemCommand = new Command(AddNewOperation);
            Categories = Data.GetCategories().Result;
            Title = "Добавить";
        }

        private async void AddNewOperation()
        {
            var cur_geo = new GeoData { Latitude = Latitude, Longitude = Longitude };
            // Debug.WriteLine(cur_geo.Link);

            if (selfgeo)
            {
                try
                {
                    //var g = Geolocation.GetLocationAsync();
                    var location = await Geolocation.GetLocationAsync();

                    if (location != null)
                    {
                        cur_geo = new GeoData
                            { Latitude = (float)location.Latitude, Longitude = (float)location.Longitude };
                        Console.WriteLine(
                            $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    Debug.WriteLine("NotSupported");
                    // Handle not supported on device exception
                }
                catch (FeatureNotEnabledException fneEx)
                {
                    Debug.WriteLine("NotEnabled");
                    // Handle not enabled on device exception
                }
                catch (PermissionException pEx)
                {
                    Debug.WriteLine("Permission");
                    return;
                    // Handle permission exception
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    // Unable to get location
                }
            }

            DateTime1 = DateTime1.AddHours(-DateTime1.Hour);
            DateTime1 = DateTime1.AddMinutes(-DateTime1.Minute);
            DateTime1 = DateTime1.AddSeconds(-DateTime1.Second);
            DateTime1 = DateTime1.AddMinutes(Time.Minutes);
            DateTime1 = DateTime1.AddHours(Time.Hours);
            Console.WriteLine(Time.Hours);

            if (Editing)
            {
                Operation new_oper = new Operation
                {
                    Name = Name, Category = Category, Value = Value, Currency = Currency, Aftconvert = Aftconvert,
                    Regular = Regular, Geodata = cur_geo, DateAdd = DateTime1
                };
                Data.DeleteOperationAsync(Convert.ToInt32(ItemId));
                Data.AddOperationAsync(new_oper);
            }
            else
            {
                Operation new_oper = new Operation
                {
                    Name = Name, Category = Category, Value = Value, Currency = Currency, Aftconvert = Value,
                    Regular = Regular, Geodata = cur_geo, DateAdd = DateTime1
                };
                await Data.AddOperationAsync(new_oper);
            }

            Shell.Current.GoToAsync($"//{nameof(OperationsPage)}");
        }

        void load(string id)
        {
            Categories = Data.GetCategories().Result;
            itemId = Convert.ToString(id);
            if (id == null)
            {
                Editing = false;
                OnPropertyChanged("Editing");
                Title = "Добавить";
                OnPropertyChanged("Title");
                Name = "";
                Category = null;
                Value = 0.0F;
                DateTime1 = DateTime.Now;
                //   OnPropertyChanged("DateTime1");
                Latitude = 55.755797F;
                Time = new TimeSpan(DateTime1.Hour, DateTime1.Minute, DateTime1.Second);
                OnPropertyChanged("Latitude");
                Longitude = 37.617729F;
                OnPropertyChanged("Longitude");
                Regular = false;
                Currency = null;
                Aftconvert = 0;
            }
            else
            {
                Debug.WriteLine(ItemId + "as" + nameof(ItemId));
                Title = "Изменить";
                OnPropertyChanged("Title");
                var ser = Data.GetOperations().Result[Convert.ToInt32(id)];
                Name = ser.Name;
                Category = ser.Category;
                Value = ser.Value;
                DateTime1 = ser.DateAdd;
                Geo = ser.Geodata;
                Latitude = Geo.Latitude;
                Longitude = Geo.Longitude;
                Regular = ser.Regular;
                Currency = ser.Currency;
                Aftconvert = ser.Aftconvert;
                Editing = true;
                Time = new TimeSpan(DateTime1.Hour, DateTime1.Minute, DateTime1.Second);
            }
        }


        public void LoadItemId(string item)

        {
            try
            {
            }
            catch (Exception)
            {
                Debug.WriteLine($"/n/n/n/n{item}");
            }
        }
    }
}