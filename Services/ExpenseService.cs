using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _repository;

    public ExpenseService(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Expense> GetAllExpenses() => _repository.GetAllExpenses();


    public Expense? GetById(int id) => _repository.GetById(id);

    public void Add(Expense expense) => _repository.Add(expense);

    public void Update(Expense expense) => _repository.Update(expense);

    public void Delete(int id) => _repository.Delete(id);

}