using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PickleballClubManagement.Models;
using PickleballClubManagement.Services;

namespace PickleballClubManagement.Pages.News
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public List<Models.News> NewsList { get; set; } = new();

        public async Task OnGetAsync()
        {
            NewsList = InMemoryDataStore.GetNews()
                .OrderByDescending(n => n.IsPinned)
                .ThenByDescending(n => n.CreatedDate)
                .ToList();
            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            if (!User.IsInRole("Admin"))
                return Forbid();

            var news = InMemoryDataStore.GetNews().FirstOrDefault(n => n.Id == id);
            if (news != null)
            {
                InMemoryDataStore.GetNews().Remove(news);
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostTogglePinAsync(int id)
        {
            if (!User.IsInRole("Admin"))
                return Forbid();

            var news = InMemoryDataStore.GetNews().FirstOrDefault(n => n.Id == id);
            if (news != null)
            {
                news.IsPinned = !news.IsPinned;
            }

            return RedirectToPage();
        }
    }
}
