namespace ExpenseTracker.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    //Relationship 1 Category -> n Expenses
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

}