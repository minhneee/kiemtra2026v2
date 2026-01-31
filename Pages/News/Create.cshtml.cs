using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PickleballClubManagement.Models;
using PickleballClubManagement.Services;
using System.ComponentModel.DataAnnotations;

namespace PickleballClubManagement.Pages.News
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
            [StringLength(200, ErrorMessage = "Tiêu đề không vượt quá 200 ký tự")]
            public string Title { get; set; } = string.Empty;

            [Required(ErrorMessage = "Vui lòng nhập nội dung")]
            public string Content { get; set; } = string.Empty;

            public bool IsPinned { get; set; } = false;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var news = new Models.News
            {
                Title = Input.Title,
                Content = Input.Content,
                IsPinned = Input.IsPinned,
                CreatedDate = DateTime.Now
            };

            InMemoryDataStore.AddNews(news);

            TempData["SuccessMessage"] = "Tạo tin tức thành công!";
            return RedirectToPage("Index");
        }
    }
}
