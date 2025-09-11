using ExpenseTracker.Models;

namespace ExpenseTracker.Repository;

public class ExpenseRepository : IExpenseRepository
{
        private readonly List<Expense> _expenses = new()
        {
                new Expense { Id = 1, Title = "Coffee", Amount = 2.5m, Date = DateTime.Now, CategoryId = 1 },
                new Expense { Id = 2, Title = "Groceries", Amount = 50m, Date = DateTime.Now, CategoryId = 2 }
        };

        public IEnumerable<Expense> GetAllExpenses() => _expenses;

        public Expense? GetById(int id) => _expenses.FirstOrDefault(e => e.Id == id);

        public void Add(Expense expense)
        {
                expense.Id = _expenses.Max(e => e.Id) + 1;
                _expenses.Add(expense);
        }

        public void Update(Expense expense)
        {
                var existing = GetById(expense.Id);
                if (existing != null)
                {
                        existing.Title = expense.Title;
                        existing.Amount = expense.Amount;
                        existing.Date = expense.Date;
                        existing.CategoryId = expense.CategoryId;
                }
        }

        public void Delete(int id)
        {
                var expense = GetById(id);
                if (expense != null)
                {
                        _expenses.Remove(expense);
                }
        }

}