namespace ExpenseTracker.Models;

public class Expense
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public decimal Amount { get; set; }
    public DateTimeOffset Date { get; set; }
    
    //Relationships
    public int CategoryId { get; set; }
    public Category? Category { get; set; } = null!;

    public int UserId { get; set; }
    public User? User { get; set; } = null!;

}