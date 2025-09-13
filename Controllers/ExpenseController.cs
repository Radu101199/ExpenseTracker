using ExpenseTracker.DTOs;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseService _service;

    public ExpenseController(IExpenseService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ExpenseDto>> GetAll()
    {
        var expenses = _service.GetAllExpenses()
            .Select(e => new ExpenseDto
            {
                Id = e.Id,
                Title = e.Title,
                Amount = e.Amount,
                Date = e.Date,
                CategoryId = e.CategoryId,
                UserId = e.UserId
            });

        return Ok(expenses);
    }

    [HttpGet("{id}")]
    public ActionResult<Expense> GetById(int id)
    {
        var expense = _service.GetById(id);
        if (expense == null)
            return NotFound();
        return Ok(expense);
    }

    [HttpPost]
    public ActionResult<ExpenseDto> Add([FromBody]CreateExpenseDto dto)
    {
        var expense = new Expense
        {
            Title = dto.Title,
            Amount = dto.Amount,
            Date = dto.Date,
            CategoryId = dto.CategoryId,
            UserId = dto.UserId
        };

        _service.Add(expense);

        var expenseDto = new ExpenseDto
        {
            Id = expense.Id,
            Title = expense.Title,
            Amount = expense.Amount,
            Date = expense.Date,
            CategoryId = expense.CategoryId,
            UserId = expense.UserId
        };

        return CreatedAtAction(nameof(GetAll), new { id = expense.Id }, expenseDto);
        
    }
    [HttpPut("id")]
    public ActionResult Update(int id,[FromBody] Expense expense)
    {
        if (id != expense.Id)
            return BadRequest();

        var existing = _service.GetById(id);
        if (existing == null)
            return NotFound();

        _service.Update(expense);
        return NoContent();
    }
    
    [HttpDelete("id")]
    public ActionResult Delete(int id)
    {
        var existing = _service.GetById(id);
        if (existing == null)
            return NotFound();

        _service.Delete(id);
        return NoContent();
    }
}