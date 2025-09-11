using ExpenseTracker.Models;

namespace ExpenseTracker.Services;

public interface IExpenseService
{
    IEnumerable<Expense> GetAllExpenses();
    Expense? GetById(int id);
    void Add(Expense expense);
    void Update(Expense expense);
    void Delete(int id);
}