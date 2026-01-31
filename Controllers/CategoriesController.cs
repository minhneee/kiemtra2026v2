using Microsoft.AspNetCore.Mvc;
using PickleballClubManagement.Models;

namespace PickleballClubManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly static List<TransactionCategory> _categories = new()
    {
        new TransactionCategory { Id = 1, Name = "Membership Fees", Type = TransactionType.Income },
        new TransactionCategory { Id = 2, Name = "Court Rental", Type = TransactionType.Income },
        new TransactionCategory { Id = 3, Name = "Equipment", Type = TransactionType.Expense },
        new TransactionCategory { Id = 4, Name = "Maintenance", Type = TransactionType.Expense },
        new TransactionCategory { Id = 5, Name = "Staff Salary", Type = TransactionType.Expense }
    };

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<TransactionCategory>> GetCategories()
    {
        return Ok(_categories);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<TransactionCategory> GetCategory(int id)
    {
        var category = _categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }
}
