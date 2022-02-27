using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace AndrApp.ViewModels
{
    class ControlViewModel : BaseViewModel
    {
        Page p1;
        public Command AddCommand { get; }
        public Command<string> Tapped { get; }
        public ObservableCollection<string> Categories { get; set; }

        public ControlViewModel(Page page)
        {
            p1 = page;
            Tapped = new Command<string>(OnSelected);
            Categories = Data.GetCategories().Result;
            AddCommand = new Command(Add);
        }

        private async void OnSelected(string item)
        {
            if (item == null)
                return;
            var answer = await p1.DisplayAlert("Подтверждение", $"Вы точно хтите удалить категорию {item}?", "Да",
                "Нет");
            if (answer)
            {
                await Data.DelCategoryAsync(item);
            }
        }

        private async void Add()
        {
            var answer =
                await p1.DisplayPromptAsync("Добавить", "Новая категория:", "Добавить", "Отмена", "Название");
            if (string.IsNullOrEmpty(answer) || Data.GetCategories().Result.Contains(answer))
                return;
            await Data.AddCategoryAsync(answer);
        }
    }
}