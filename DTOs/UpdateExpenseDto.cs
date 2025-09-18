namespace ExpenseTracker.DTOs;

public class UpdateExpenseDto
{
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTimeOffset Date { get; set; }
    public int CategoryId { get; set; }
    public int UserId { get; set; }
}