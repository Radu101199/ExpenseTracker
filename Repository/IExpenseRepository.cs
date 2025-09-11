using ExpenseTracker.Models;

namespace ExpenseTracker.Repository;

public interface IExpenseRepository
{
    IEnumerable<Expense> GetAllExpenses();
    Expense? GetById(int id);
    void Add(Expense expense);
    void Update(Expense expense);
    void Delete(int id);
}