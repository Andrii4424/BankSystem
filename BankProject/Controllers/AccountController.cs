using ApplicationCore.Core.DTO.AppUserDto;
using ApplicationCore.Domain.Entities.Identity;
using BankProject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("{ReturnUrl?}")]
        public async Task<IActionResult> Register([FromForm] RegisterDto userDto, string? ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                return BadRequest(errors);
            }

            ApplicationUser user = new ApplicationUser()
            {
                FullName = userDto.FullName,
                Email = userDto.Email,
                UserName = userDto.Email,
                PhoneNumber = userDto.PhoneNumber
            };
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                string? decodedReturnUrl = WebUtility.UrlDecode(ReturnUrl);
                //TO DO: Redirect to previos page: return LocalRedirect($"~{decodedReturnUrl}")
                if (ReturnUrl != null && Url.IsLocalUrl(decodedReturnUrl)) return Ok();
                //TO DO: Redirect to home page": return RedirectToAction("BanksList", "Bank")
                return Ok(); 
            }
            else
            {
                List<string> errors = new List<string>();
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }
                errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                return BadRequest(errors);
            }
        }

        [HttpPost("{ReturnUrl?}")]
        public async Task<IActionResult> Login([FromForm] LoginDto userDto, string? ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                return BadRequest(errors);
            }

            var result = await _signInManager.PasswordSignInAsync(userDto.Email, userDto.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                string? decodedReturnUrl = WebUtility.UrlDecode(ReturnUrl);
                //TO DO: Redirect to previos page: return LocalRedirect($"~{decodedReturnUrl}")
                if (ReturnUrl != null && Url.IsLocalUrl(decodedReturnUrl)) return Ok();
                //TO DO: Redirect to home page: RedirectToAction("BanksList", "Bank")
                return Ok();
            }
            else
            {
                return BadRequest("Invalid email or password!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //TO DO: Redirect to home page: RedirectToAction("Index", "Home")
            return Ok(); 
        }
        /*
        [HttpGet("[controller]/[action]/{ReturnUrl?}")]
        public IActionResult Register(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpGet("[controller]/[action]/{ReturnUrl?}")]
        public IActionResult Login(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        */
    }
}
