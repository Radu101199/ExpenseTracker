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
                Date = e.Date.ToUniversalTime(),
                CategoryId = e.CategoryId,
                UserId = e.UserId
            });

        return Ok(expenses);
    }

    [HttpGet("{id}")]
    public ActionResult<ExpenseDto> GetById(int id)
    {
        var e = _service.GetById(id);
        if (e == null) return NotFound();

        var dto = new ExpenseDto
        {
            Id = e.Id,
            Title = e.Title,
            Amount = e.Amount,
            Date = e.Date.ToUniversalTime(),
            CategoryId = e.CategoryId,
            UserId = e.UserId,
        };

        return Ok(dto);
    }


    [HttpPost]
    public ActionResult<ExpenseDto> Add([FromBody]CreateExpenseDto dto)
    {
        var expense = new Expense
        {
            Title = dto.Title,
            Amount = dto.Amount,
            Date = dto.Date.ToUniversalTime(),
            CategoryId = dto.CategoryId,
            UserId = dto.UserId
        };

        _service.Add(expense);

        var expenseDto = new ExpenseDto
        {
            Id = expense.Id,
            Title = expense.Title,
            Amount = expense.Amount,
            Date = expense.Date.ToUniversalTime(),
            CategoryId = expense.CategoryId,
            UserId = expense.UserId
        };

        return CreatedAtAction(nameof(GetById), new { id = expense.Id }, expenseDto);
        
    }
    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] UpdateExpenseDto dto)
    {
        var existing = _service.GetById(id);
        if (existing == null) return NotFound();

        existing.Title = dto.Title;
        existing.Amount = dto.Amount;
        existing.Date = dto.Date.ToUniversalTime();
        existing.CategoryId = dto.CategoryId;
        existing.UserId = dto.UserId;

        _service.Update(existing);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existing = _service.GetById(id);
        if (existing == null)
            return NotFound();

        _service.Delete(id);
        return NoContent();
    }
}