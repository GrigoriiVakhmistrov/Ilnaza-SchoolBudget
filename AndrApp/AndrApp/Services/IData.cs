using System.Threading.Tasks;
using AndrApp.Models;
using System.Collections.ObjectModel;

namespace AndrApp.Services
{
    public interface IData
    {
        Task<bool> Authorise(string login, string password, bool ser_work = true); //вход по логину и паролю
        Task<bool> Registration(string login, string password, bool ser_work = true); // регистрация
        Task<bool> AuthoriseBySession(string session, bool ser_work = true); // вход по сессии
        Task<bool> IsAthorised(); // выполнен вход да/нет 
        Task<bool> Synchronization(); // синхронизация с сервером
        Task<bool> Exit(); //выход
        Task<bool> RemoveUsr(); // удалить аккаунт
        Task<string> GetLogin(); // получить логин
        Task<ObservableCollection<string>> GetBudgets(); // получить названия кошельков
        Task<ObservableCollection<string>> GetCategories();
        Task<bool> AddBudgetAsync(string name);
        Task<bool> DelBudgetAsync(string name);
        Task<bool> AddCategoryAsync(string name);
        Task<bool> DelCategoryAsync(string name);
        Task<ObservableCollection<Operation>> GetOperations(string budget); // получить операции кошелька budget
        Task<ObservableCollection<Operation>> GetOperations(); //получить операции текущего кошелька
        Task<bool> SetBud(int index); // установить текущий кошелек
        Task<bool> AddOperationAsync(Operation item, string budget);

        Task<bool> AddOperationAsync(Operation item);

        //Task<bool> UpdateOperationAsync(int index,String budget);
        Task<bool> DeleteOperationAsync(int id, string budget);
        Task<bool> DeleteOperationAsync(int id);
    }
}