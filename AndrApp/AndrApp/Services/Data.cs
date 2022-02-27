using AndrApp.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AndrApp.Services
{
    class Data : IData
    {
        private string IP = "26.193.185.187";
        private int port = 1111;
        private string login;
        private string password;
        private bool authorised = false;
        private bool serwork;
        private ObservableCollection<Budget> budgets = new ObservableCollection<Budget> { };
        public int Curbud = 0;

        public async Task<bool> Authorise(string Login, string Password, bool Ser_work = true)
        {
            if (Ser_work)
            {
                try
                {
                    //__BD__
                }
                catch
                {
                }
            }
            else
            {
                budgets = new ObservableCollection<Budget>
                {
                    new Budget
                    {
                        Name = "Happy Company!!!!1",
                        Categories = new ObservableCollection<string> { "CAT" },
                        Share = new ObservableCollection<string> { },
                        Owner = "Uersaa",
                        Status = "1",
                        Operations = new ObservableCollection<Operation>
                        {
                            new Operation
                            {
                                Name = "NYX@", Aftconvert = 200, Category = "cat",
                                Geodata = new GeoData { Latitude = 10, Longitude = 20 }
                            },
                            new Operation { Name = "NYX", Aftconvert = 100, Category = "CAT" },
                            new Operation
                            {
                                Name = "NY@", Aftconvert = 200, Regular = true, Category = "cat",
                                Geodata = new GeoData { Latitude = 10, Longitude = 20 }
                            }
                        }
                    },
                    new Budget
                    {
                        Name = "test",
                        Operations = new ObservableCollection<Operation> { },
                        Categories = new ObservableCollection<string> { }
                    }
                };
                login = Login;
                password = Password;
                serwork = Ser_work;
                authorised = true;
            }

            return await Task.FromResult(authorised);
        }

        public async Task<bool> Registration(string Login, string Password, bool Ser_work = true)
        {
            if (Ser_work)
            {
                try
                {
                    //__BD__
                    return await Task.FromResult(true);
                }
                catch
                {
                    return await Task.FromResult(false);
                }
            }
            else
            {
                return await Task.FromResult(true);
            }
        }

        public async Task<bool> AuthoriseBySession(string session, bool Ser_work = true)
        {
            if (Ser_work)
            {
                try
                {
                    //__BD__
                }
                catch
                {
                }
            }

            return await Task.FromResult(authorised); //пока пусть будет так
        }

        public async Task<bool> AddBudgetAsync(string name)
        {
            if (serwork)
            {
                try
                {
                    //__BD__
                }
                catch
                {
                }
            }

            budgets.Add(
                new Budget
                {
                    Name = name,
                    Categories = new ObservableCollection<string> { },
                    Operations = new ObservableCollection<Operation> { },
                }
            );
            return await Task.FromResult(true);
        }

        public async Task<bool> DelBudgetAsync(string name)
        {
            if (serwork)
            {
                try
                {
                    //__BD__
                }
                catch
                {
                }
            }

            for (int i = 0; i < budgets.Count; i++)
            {
                if (budgets[i].Name == name)
                {
                    budgets.Remove(budgets[i]);
                }
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> IsAthorised()
        {
            return await Task.FromResult(authorised);
        }

        public async Task<bool> Synchronization()
        {
            if (serwork)
            {
                //__BD__
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> Exit()
        {
            if (serwork)
            {
                //__BD__
            }

            authorised = false;
            login = null;
            password = null;
            serwork = true;
            return await Task.FromResult(true);
        }

        public async Task<bool> RemoveUsr()
        {
            if (serwork)
            {
                //__BD__ (удалить акк пользователя)
            }

            authorised = false;

            return await Task.FromResult(true);
        }

        public async Task<string> GetLogin()
        {
            return await Task.FromResult(login);
        }

        public async Task<ObservableCollection<Operation>> GetOperations(string budget)
        {
            ObservableCollection<Operation> Operations = new ObservableCollection<Operation> { };
            for (int i = 0; i < budgets.Count; i++)
            {
                if (budgets[i].Name == budget)
                {
                    Operations = budgets[i].Operations;
                }
            }

            return await Task.FromResult(Operations);
        }

        public async Task<ObservableCollection<string>> GetCategories()
        {
            return Task.FromResult(budgets[Curbud].Categories).Result;
        }

        public async Task<bool> AddCategoryAsync(string name)
        {
            if (serwork)
            {
                //__BD__ 
            }

            budgets[Curbud].Categories.Add(name);
            return await Task.FromResult(true);
        }

        public async Task<bool> DelCategoryAsync(string name)
        {
            if (serwork)
            {
                //__BD__ 
            }

            budgets[Curbud].Categories.Remove(name);
            return await Task.FromResult(true);
        }

        public async Task<bool> SetBud(int index)
        {
            Curbud = index;

            return await Task.FromResult(true);
        }

        public async Task<ObservableCollection<Operation>> GetOperations()
        {
            return await Task.FromResult(budgets[Curbud].Operations);
        }

        public async Task<ObservableCollection<string>> GetBudgets()
        {
            ObservableCollection<string> Budgets = new ObservableCollection<string> { };
            for (int i = 0; i < budgets.Count; i++)
            {
                Budgets.Add(budgets[i].Name);
            }

            return Task.FromResult(Budgets).Result;
        }

        public async Task<bool> AddOperationAsync(Operation item, string budget)
        {
            for (int i = 0; i < budgets.Count; i++)
            {
                if (budgets[i].Name == budget)
                {
                    if (serwork)
                    {
                        try
                        {
                            //__BD__
                        }

                        catch
                        {
                            return await Task.FromResult(false);
                        }
                    }


                    budgets[i].Operations.Add(item);
                }
            }


            return true;
        }

        public async Task<bool> AddOperationAsync(Operation item)
        {
            if (serwork)
            {
                try
                {
                    //__BD__
                }

                catch
                {
                    return await Task.FromResult(false);
                }
            }

            budgets[Curbud].Operations.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateOperationAsync(int index, string budget)
        {
            for (int i = 0; i < budgets.Count; i++)
            {
                if (budgets[i].Name == budget)
                {
                    if (serwork)
                    {
                        try
                        {
                            //__BD__ (не трогать)
                        }

                        catch
                        {
                            return await Task.FromResult(false);
                        }
                    }
                }
            }


            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteOperationAsync(int id, string budget)
        {
            for (int i = 0; i < budgets.Count; i++)
            {
                if (budgets[i].Name == budget)
                {
                    if (serwork)
                    {
                        try
                        {
                            //__BD__ 
                        }

                        catch
                        {
                            return await Task.FromResult(false);
                        }

                        budgets[i].Operations.RemoveAt(id);
                    }
                }
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteOperationAsync(int id)
        {
            if (serwork)
            {
                try
                {
                    //__BD__ 
                }

                catch
                {
                    return await Task.FromResult(false);
                }
            }

            budgets[Curbud].Operations.RemoveAt(id);
            return await Task.FromResult(true);
        }
    }
}