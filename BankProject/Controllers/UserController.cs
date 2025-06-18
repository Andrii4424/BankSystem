using BankProject.Filters;
using BankServices.BankService;
using BankServicesContracts.ServicesContracts;
using BankServicesContracts.ServicesContracts.UserServiceContracts;
using DTO.BankDto;
using DTO.PersonDto;
using Microsoft.AspNetCore.Mvc;

namespace BankProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserReadService _userReadService;
        private readonly IUserAddService _userAddService;
        private readonly IUserUpdateService _userUpdateService;
        private readonly IUserDeleteService _userDeleteService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserReadService userReadService, IUserAddService userAddService,
            IUserUpdateService userUpdateService, IUserDeleteService userDeleteService, ILogger<UserController> logger)
        {
            _userReadService = userReadService;
            _userAddService = userAddService;
            _userUpdateService = userUpdateService;
            _userDeleteService = userDeleteService;
            _logger = logger;
        }

        [HttpGet("/users-info/bank-id/{bankId:int}")]
        public async Task<IActionResult> UsersInfo(int bankId)
        {
            ViewBag.BankName = await _userReadService.GetUsersBankName(bankId);
            ViewBag.BankId = bankId;
            return View(await _userReadService.GetUsersListByBankId(bankId));
        }


        [HttpGet("/add-user/bank-id/{bankId:int}")]
        public IActionResult AddUser([FromRoute] int bankId)
        {
            ViewBag.BankId = bankId;
            return View();
        }

        [TypeFilter(typeof(ModelBindingFilter), Arguments = new object[] { nameof(AddUser) })]
        [HttpPost("/add-user/bank-id/{bankId:int}")]
        public async Task<IActionResult> AddUser([FromRoute] int bankId, [FromForm] UserDto userDto)
        {
            ViewBag.BankId = bankId;
            if(ModelState.IsValid) await _userAddService.AddUser(userDto);
            return View();
        }

        [HttpGet("/update-user/bank-id/{bankId:int}/user-id/{userId:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int bankId, [FromRoute] int userId)
        {
            return View(await _userReadService.GetUserDto(userId));
        }

        [TypeFilter(typeof(ModelBindingFilter), Arguments = new object[] { nameof(AddUser) })]
        [HttpPost("/update-user/bank-id/{bankId:int}/user-id/{userId:int}")]
        public async Task<IActionResult> UpdateUser([FromForm] UserDto userDto, [FromRoute] int bankId, 
            [FromRoute] int userId)
        {
            if(userDto.JobTitle!=null) userDto.IsEmployed = true;
            if(ModelState.IsValid) await _userUpdateService.UpdateUser(userId, userDto);
            return View(userDto);
        }


        [HttpPost("/delete-user/bank-id/{bankId:int}/user-id/{userId:int}")]
        public async Task<IActionResult> DeleteUser(int bankId, [FromRoute]int userId)
        {
            await _userDeleteService.DeleteUser(userId);
            _logger.LogInformation("POST /delete-user -> Success deleting user for bankId: {BankId}", bankId);
            return RedirectToAction("UsersInfo", "User", new { bankId = bankId });
        }
    }
}
