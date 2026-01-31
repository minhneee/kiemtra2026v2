using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PickleballClubManagement.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PickleballClubManagement.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IMemberService _memberService;

        public LoginModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string? ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
            public string Username { get; set; } = string.Empty;

            [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            [Display(Name = "Ghi nhớ đăng nhập")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                if (InMemoryUserStore.TryAuthenticate(Input.Username, Input.Password))
                {
                    var userInfo = InMemoryUserStore.GetUserInfo(Input.Username);
                    if (userInfo.HasValue)
                    {
                        // Create claims principal
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, Input.Username),
                            new Claim(ClaimTypes.Name, Input.Username),
                            new Claim(ClaimTypes.Email, userInfo.Value.email),
                        };

                        // Add role claims
                        foreach (var role in userInfo.Value.roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = Input.RememberMe,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                        };

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);

                        // Ensure member record exists
                        var member = await _memberService.GetMemberByUserIdAsync(Input.Username);
                        if (member == null)
                        {
                            await _memberService.CreateMemberAsync(Input.Username, userInfo.Value.fullName);
                        }

                        return LocalRedirect(returnUrl);
                    }
                }

                ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng.");
                return Page();
            }

            return Page();
        }
    }
}
