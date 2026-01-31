using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PickleballClubManagement.Models;
using PickleballClubManagement.Services;
using System.ComponentModel.DataAnnotations;

namespace PickleballClubManagement.Pages.News
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
            [StringLength(200, ErrorMessage = "Tiêu đề không vượt quá 200 ký tự")]
            public string Title { get; set; } = string.Empty;

            [Required(ErrorMessage = "Vui lòng nhập nội dung")]
            public string Content { get; set; } = string.Empty;

            public bool IsPinned { get; set; } = false;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var news = InMemoryDataStore.GetNews().FirstOrDefault(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            Input.Id = news.Id;
            Input.Title = news.Title;
            Input.Content = news.Content;
            Input.IsPinned = news.IsPinned;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var news = InMemoryDataStore.GetNews().FirstOrDefault(n => n.Id == Input.Id);
            if (news == null)
            {
                return NotFound();
            }

            news.Title = Input.Title;
            news.Content = Input.Content;
            news.IsPinned = Input.IsPinned;

            TempData["SuccessMessage"] = "Cập nhật tin tức thành công!";
            return RedirectToPage("Index");
        }
    }
}
