using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PickleballClubManagement.Models;
using PickleballClubManagement.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PickleballClubManagement.Pages.Financial
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public List<TransactionCategory> Categories { get; set; } = new();

        public class InputModel
        {
            [Required(ErrorMessage = "Vui lòng chọn danh mục")]
            public int CategoryId { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập số tiền")]
            [Range(1000, double.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 1,000đ")]
            public decimal Amount { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập mô tả")]
            public string Description { get; set; } = string.Empty;

            [Required]
            public DateTime Date { get; set; } = DateTime.Now;
        }

        public async Task OnGetAsync()
        {
            Categories = InMemoryDataStore.GetTransactionCategories();
            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Categories = InMemoryDataStore.GetTransactionCategories();
                return Page();
            }

            var transaction = new Transaction
            {
                CategoryId = Input.CategoryId,
                Amount = Input.Amount,
                Description = Input.Description,
                Date = Input.Date,
                CreatedDate = DateTime.Now,
                CreatedById = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            InMemoryDataStore.AddTransaction(transaction);

            TempData["SuccessMessage"] = "Ghi nhận giao dịch thành công!";
            return RedirectToPage("/Financial/Index");
        }
    }
}
