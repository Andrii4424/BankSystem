using BankProject;
using BankServicesContracts.ServicesContracts.UserServiceContracts;
using DTO.PersonDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
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

        [HttpGet("{bankId:int}")]
        public async Task<IActionResult> UsersInfo(int bankId)
        {
            return Ok(await _userReadService.GetUsersListByBankId(bankId));
        }

        [HttpPost("{bankId:int}")]
        public async Task<IActionResult> AddUser([FromRoute] int bankId, [FromForm] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                return BadRequest(errors);
            }
            await _userAddService.AddUser(userDto);
            return Ok(userDto);
        }

        [HttpPut("{bankId:int}/{userId:int}")]
        public async Task<IActionResult> UpdateUser([FromForm] UserDto userDto, [FromRoute] int bankId,
    [FromRoute] int userId)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                return BadRequest(errors);
            }
            if (userDto.JobTitle != null) userDto.IsEmployed = true;
            await _userUpdateService.UpdateUser(userId, userDto);
            return Ok(userDto);
        }

        [HttpDelete("{bankId:int}/{userId:int}")]
        public async Task<IActionResult> DeleteUser(int bankId, [FromRoute] int userId)
        {
            await _userDeleteService.DeleteUser(userId);
            _logger.LogInformation("POST /delete-user -> Success deleting user for bankId: {BankId}", bankId);
            return Ok(); //TO DO : Redirect
        }

        /*
        [TypeFilter(typeof(UserValidation))]
        [HttpGet("/add-user/bank-id/{bankId:int}")]
        public IActionResult AddUser([FromRoute] int bankId)
        {
            ViewBag.BankId = bankId;
            return View();
        }

        [TypeFilter(typeof(UserValidation))]
        [HttpGet("/update-user/bank-id/{bankId:int}/user-id/{userId:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int bankId, [FromRoute] int userId)
        {
            return View(await _userReadService.GetUserDto(userId));
        }
        */
    }
}
