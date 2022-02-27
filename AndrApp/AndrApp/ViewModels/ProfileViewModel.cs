using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AndrApp.ViewModels
{
    internal class ProfileViewModel : BaseViewModel
    {
        Page p1;
        public Command AddCommand { get; }
        public Command<string> Tapped { get; }
        private ObservableCollection<string> budgets;

        public ObservableCollection<string> Budgets
        {
            get => budgets;
            set
            {
                budgets = value;
                OnPropertyChanged();
            }
        }

        public ProfileViewModel(Page page)
        {
            p1 = page;
            Tapped = new Command<string>(OnSelected);
            Budgets = Data.GetBudgets().Result;
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
                await Data.DelBudgetAsync(item);
                Application.Current.MainPage = new AppShell(); // await Data.DelCategoryAsync(item);
            }
        }

        private async void Add()
        {
            var answer =
                await p1.DisplayPromptAsync("Добавить", "Новая категория:", "Добавить", "Отмена", "Название");
            if (string.IsNullOrEmpty(answer) || Data.GetBudgets().Result.Contains(answer))
                return;
            await Data.AddBudgetAsync(answer);
        }
    }
}