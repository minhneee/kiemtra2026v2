using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PickleballClubManagement.Models;
using PickleballClubManagement.Services;

namespace PickleballClubManagement.Pages.Financial
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        public List<Transaction> Transactions { get; set; } = new();
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal CurrentBalance { get; set; }

        public async Task OnGetAsync()
        {
            Transactions = InMemoryDataStore.GetTransactions()
                .OrderByDescending(t => t.Date)
                .ToList();

            // Populate categories for each transaction
            foreach (var transaction in Transactions)
            {
                transaction.Category = InMemoryDataStore.GetTransactionCategoryById(transaction.CategoryId);
            }

            TotalIncome = Transactions
                .Where(t => t.Category?.Type == TransactionType.Income)
                .Sum(t => t.Amount);

            TotalExpense = Transactions
                .Where(t => t.Category?.Type == TransactionType.Expense)
                .Sum(t => t.Amount);

            CurrentBalance = TotalIncome - TotalExpense;
            await Task.CompletedTask;
        }
    }
}
