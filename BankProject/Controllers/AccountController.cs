using ApplicationCore.Core.DTO.AppUserDto;
using ApplicationCore.Domain.Entities.Identity;
using BankProject;
using BankProject.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("[controller]/[action]/{ReturnUrl?}")]
        public IActionResult Register(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [TypeFilter(typeof(ModelBindingFilter), Arguments = new object[] { nameof(Register) })]
        [HttpPost("[controller]/[action]/{ReturnUrl?}")]
        public async Task<IActionResult> Register([FromForm] RegisterDto userDto, string? ReturnUrl)
        {
            ApplicationUser user = new ApplicationUser()
            {
                FullName = userDto.FullName, 
                Email = userDto.Email,
                UserName = userDto.Email, 
                PhoneNumber = userDto.PhoneNumber
            };
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded) {
                await _signInManager.SignInAsync(user, isPersistent: false);
                string? decodedReturnUrl = WebUtility.UrlDecode(ReturnUrl);
                if (ReturnUrl != null && Url.IsLocalUrl(decodedReturnUrl)) return LocalRedirect($"~{decodedReturnUrl}");
                return RedirectToAction("BanksList", "Bank");
            }
            else
            {
                List<string> errors = new List<string>();
                ViewBag.Message = "Error";
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }
                errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                ViewBag.Errors = errors;
                return View();
            }
        }

        [HttpGet("[controller]/[action]/{ReturnUrl?}")]
        public IActionResult Login(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [TypeFilter(typeof(ModelBindingFilter), Arguments = new object[] { nameof(Register) })]
        [HttpPost("[controller]/[action]/{ReturnUrl?}")]
        public async Task<IActionResult> Login([FromForm] LoginDto userDto, string? ReturnUrl)
        {
            var result = await _signInManager.PasswordSignInAsync(userDto.Email, userDto.Password, isPersistent:false, lockoutOnFailure: false);
            if (result.Succeeded) {
                string? decodedReturnUrl = WebUtility.UrlDecode(ReturnUrl);
                if (ReturnUrl!=null && Url.IsLocalUrl(decodedReturnUrl)) return LocalRedirect($"~{decodedReturnUrl}");
                return RedirectToAction("BanksList", "Bank");
            }
            else
            {
                List<string> errors = new List<string>();
                ViewBag.Message = "Error";
                errors.Add("Invalid email or password!");
                ViewBag.Errors = errors;
                return View();
            }
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
