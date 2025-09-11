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
    public ActionResult<IEnumerable<Expense>> GetAll()
    {
        return Ok(_service.GetAllExpenses());
    }

    [HttpGet("{id}")]
    public ActionResult<Expense> getById(int id)
    {
        var expense = _service.GetById(id);
        if (expense == null)
            return NotFound();
        return Ok(expense);
    }

    [HttpPost]
    public ActionResult Add(Expense expense)
    {
        _service.Add(expense);
        return CreatedAtAction(nameof(GetById), new { id = expense.Id }, expense);
    }
    [HttpPut("id")]
    public ActionResult Update(int id, Expense expense)
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