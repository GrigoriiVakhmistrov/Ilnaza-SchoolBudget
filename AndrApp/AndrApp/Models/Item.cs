using System;
using System.Collections.ObjectModel;

namespace AndrApp.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class Operation
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }
        public string Currency { get; set; }
        public DateTime DateAdd { get; set; }
        public string Budget { get; set; }
        public bool Regular { get; set; }
        public GeoData Geodata { get; set; }
        public double Aftconvert { get; set; }
    }

    public class Budget
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Status { get; set; }
        public ObservableCollection<string> Share { get; set; }
        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<Operation> Operations { get; set; }
    }

    public class GeoData
    {
        public float Latitude;
        public float Longitude;
        public string Link => $"https://yandex.ru/maps/?pt={Longitude},{Latitude}&z=18&l=map";
    }
}