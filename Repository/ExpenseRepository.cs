using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repository;

public class ExpenseRepository : IExpenseRepository
{       
        private readonly AppDbContext _context;
        public ExpenseRepository(AppDbContext context)
        {
                _context = context;
        }

        public IEnumerable<Expense> GetAllExpenses() => _context.Expenses
                .Include(e => e.Category).Include(e=>e.User).ToList();

        public Expense? GetById(int id) => _context.Expenses
                .Include(e => e.Category).Include(e => e.User)
                .FirstOrDefault(e => e.Id == id);

        public void Add(Expense expense)
        {
                _context.Expenses.Add(expense);
                _context.SaveChanges();
        }

        public void Update(Expense expense)
        {
                _context.Expenses.Update(expense);
                _context.SaveChanges();
        }

        public void Delete(int id)
        {
                var expense = _context.Expenses.Find(id);
                if (expense != null)
                {
                        _context.Expenses.Remove(expense);
                        _context.SaveChanges();
                }
        }

}