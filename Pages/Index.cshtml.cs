using Microsoft.AspNetCore.Mvc.RazorPages;
using PickleballClubManagement.Models;
using PickleballClubManagement.Services;

namespace PickleballClubManagement.Pages
{
    public class IndexModel : PageModel
    {
        public int TotalMembers { get; set; }
        public int ActiveChallenges { get; set; }
        public int TotalMatches { get; set; }
        public int AvailableCourts { get; set; }

        public async Task OnGetAsync()
        {
            TotalMembers = InMemoryDataStore.GetMembers().Count;
            ActiveChallenges = InMemoryDataStore.GetChallenges().Count(c => c.Status == ChallengeStatus.Open);
            TotalMatches = InMemoryDataStore.GetMatches().Count;
            AvailableCourts = InMemoryDataStore.GetCourts().Count(c => c.IsActive);
            await Task.CompletedTask;
        }
    }
}
