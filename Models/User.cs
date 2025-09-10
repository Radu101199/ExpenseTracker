namespace ExpenseTracker.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    
    //Relationship 1 User -> n Expenses
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}