using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Globalization;
using AndrApp.Models;

namespace AndrApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Operation> operations = new ObservableCollection<Operation>();
        private string all;

        public string All
        {
            get => all;
            set
            {
                all = value;
                OnPropertyChanged();
            }
        }

        private string perday;

        public string Perday
        {
            get => perday;
            set
            {
                perday = value;
                OnPropertyChanged();
            }
        }

        private string prib;

        public string Prib
        {
            get => prib;
            set
            {
                prib = value;
                OnPropertyChanged();
            }
        }

        private double incomePerDay;

        public double IncomePerDay
        {
            get => incomePerDay;
            set
            {
                incomePerDay = value;
                OnPropertyChanged();
            }
        }

        private string incomePerDayString;

        public string IncomePerDayString
        {
            get => incomePerDayString;
            set
            {
                incomePerDayString = value;
                OnPropertyChanged();
            }
        }

        private double consumptionPerDay;

        public double ConsumptionPerDay
        {
            get => consumptionPerDay;
            set
            {
                consumptionPerDay = value;
                OnPropertyChanged();
            }
        }

        private string consumptionPerDayString;

        public string ConsumptionPerDayString
        {
            get => consumptionPerDayString;
            set
            {
                consumptionPerDayString = value;
                OnPropertyChanged();
            }
        }

        public Command LoadCommand { get; }

        private ChartData incomeData;

        public ChartData IncomeData
        {
            get => incomeData;
            set
            {
                incomeData = value;
                OnPropertyChanged();
            }
        }

        private ChartData costData;

        public ChartData CostData
        {
            get => costData;
            set
            {
                costData = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            LoadCommand = new Command(async () => await ExecuteLoadItemsCommand());

            if (Data.IsAthorised().Result)
            {
                Update();
            }
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Update();
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

        public void Update()
        {
            operations = Data.GetOperations().Result;

            double sum = 0;
            double sumpd = 0;
            double prib1 = 0;
            double incomePerDay = 0;
            double consumptionPerDay = 0;
            if (operations.Count !=
                0) //Рекомендую всю логику, в которой есть чтение операций подвергать данному условию, иначе возможны ошибки 
            {
                for (var i = 0; i < operations.Count; i++)
                {
                    var date = operations[i].DateAdd;
                    sum = sum + operations[i].Aftconvert;
                    if (date.Year == DateTime.Now.Year && date.Month == DateTime.Now.Month &&
                        date.Day == DateTime.Now.Day)
                    {
                        sumpd += operations[i].Aftconvert;
                        if (operations[i].Aftconvert > 0)
                        {
                            incomePerDay += operations[i].Aftconvert;
                        }
                        else
                        {
                            consumptionPerDay -= operations[i].Aftconvert;
                        }
                    }

                    if (operations[i].Regular)
                    {
                        prib1 += operations[i].Aftconvert;
                    }
                }
            }

            IncomePerDay = incomePerDay;
            ConsumptionPerDay = consumptionPerDay;

            All = Convert.ToString(sum, CultureInfo.InvariantCulture) + " RUB";
            Perday = Convert.ToString(sumpd, CultureInfo.InvariantCulture) + " RUB";
            Prib = Convert.ToString(prib1, CultureInfo.InvariantCulture) + " RUB";
            IncomePerDayString = $"{incomePerDay} RUB";
            ConsumptionPerDayString = $"{consumptionPerDay * -1} RUB";

            IncomeData = new ChartData("Доходы", new ChartValue(IncomePerDay));
            CostData = new ChartData("Расходы", new ChartValue(ConsumptionPerDay));
        }
    }


    public class ChartData
    {
        public string Name { get; }
        public IList<ChartValue> Values { get; }

        public ChartData(string name, params ChartValue[] values)
        {
            Name = name;
            Values = new List<ChartValue>(values);
        }
    }


    public class ChartValue
    {
        public int AxisXValue { get; }
        public double Value { get; }

        public ChartValue(double value, int axisXValue = 0)
        {
            Value = value;
            AxisXValue = axisXValue;
        }
    }
}