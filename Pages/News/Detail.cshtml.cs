using Microsoft.AspNetCore.Mvc.RazorPages;
using PickleballClubManagement.Models;
using PickleballClubManagement.Services;

namespace PickleballClubManagement.Pages.News
{
    public class DetailModel : PageModel
    {
        public Models.News News { get; set; } = new();

        public async Task OnGetAsync(int id)
        {
            var news = InMemoryDataStore.GetNews().FirstOrDefault(n => n.Id == id);
            if (news != null)
            {
                News = news;
            }
            await Task.CompletedTask;
        }
    }
}
