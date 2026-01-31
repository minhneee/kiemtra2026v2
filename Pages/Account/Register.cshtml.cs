using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PickleballClubManagement.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PickleballClubManagement.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IMemberService _memberService;

        public RegisterModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string? ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
            [StringLength(50, ErrorMessage = "Tên đăng nhập không được quá 50 ký tự")]
            [Display(Name = "Tên đăng nhập")]
            public string Username { get; set; } = string.Empty;

            [Required(ErrorMessage = "Vui lòng nhập họ tên")]
            [StringLength(100, ErrorMessage = "Họ tên không được quá 100 ký tự")]
            [Display(Name = "Họ và Tên")]
            public string FullName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Vui lòng nhập email")]
            [EmailAddress(ErrorMessage = "Email không hợp lệ")]
            [Display(Name = "Email")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
            [StringLength(100, ErrorMessage = "Mật khẩu phải có ít nhất {2} ký tự", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu")]
            public string Password { get; set; } = string.Empty;

            [DataType(DataType.Password)]
            [Display(Name = "Xác nhận mật khẩu")]
            [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
            public string ConfirmPassword { get; set; } = string.Empty;
        }

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                // Check if username already exists
                if (InMemoryUserStore.UserExists(Input.Username))
                {
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập này đã được sử dụng.");
                    return Page();
                }

                // Register user in in-memory store
                if (InMemoryUserStore.TryRegisterUser(Input.Username, Input.Password, Input.Email, Input.FullName))
                {
                    try
                    {
                        // Create member record with Rank 1.0 BEFORE signing in
                        var member = await _memberService.CreateMemberAsync(Input.Username, Input.FullName);
                        
                        // Get user roles from store
                        var userRoles = InMemoryUserStore.GetUserRoles(Input.Username);

                        // Create claims principal
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, Input.Username),
                            new Claim(ClaimTypes.Name, Input.Username),
                            new Claim(ClaimTypes.Email, Input.Email),
                        };

                        // Add role claims
                        foreach (var role in userRoles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = false,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                        };

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);

                        return LocalRedirect(returnUrl);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, $"Lỗi khi tạo thông tin thành viên: {ex.Message}");
                        return Page();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Lỗi khi đăng ký. Vui lòng thử lại.");
                }
            }

            return Page();
        }
    }
}
