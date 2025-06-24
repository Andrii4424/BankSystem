using BankProject;
using BankServicesContracts.ServicesContracts.EmployeeServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeReadService _employeeReadService;
        private readonly IEmployeeAddService _employeeAddService;
        private readonly IEmployeeUpdateService _employeeUpdateService;
        private readonly IEmployeeDeleteService _employeeDeleteService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeReadService employeeReadService, IEmployeeAddService employeeAddService,
            IEmployeeUpdateService employeeUpdateService, IEmployeeDeleteService employeeDeleteService, ILogger<EmployeeController> logger)
        {
            _employeeReadService = employeeReadService;
            _employeeAddService = employeeAddService;
            _employeeUpdateService = employeeUpdateService;
            _employeeDeleteService = employeeDeleteService;
            _logger = logger;
        }

        [HttpGet("{bankId:int}")]
        public async Task<IActionResult> EmployeeInfo(int bankId)
        {
            return Ok(await _employeeReadService.GetAllBankEmployeesList(bankId));
        }

        [HttpPost("{bankId:int?}")]
        public async Task<IActionResult> AddEmployee([FromRoute] int bankId, [FromForm] int userId, [FromForm] string JobTitle)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                return BadRequest(errors);
            }
            await _employeeAddService.AddEmployee(bankId, userId, JobTitle);
            return Ok(await _employeeReadService.GetEmployeeDto(userId));
        }

        [HttpPut("{bankId:int}/{userId:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int bankId, [FromRoute] int userId, [FromForm] string JobTitle)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                return BadRequest(errors);
            }
            await _employeeUpdateService.UpdateEmployee(userId, JobTitle);
            return Ok(await _employeeReadService.GetEmployeeDto(userId));
        }

        [HttpDelete("{bankId:int}/{userId:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int bankId, [FromRoute] int userId)
        {
            await _employeeDeleteService.FireEmployee(userId);
            _logger.LogInformation("POST /update-employee -> Succes deleting employee for bankId: {BankId}, " +
                "userId: {UserId}", bankId, userId);
            return Ok(); //TO DO: Redirect
        }

        /*


        [TypeFilter(typeof(UserValidation))]
        [HttpGet("/add-employee/bank-id/{bankId:int?}")]
        public IActionResult AddEmployee(int? bankId)
        {
            ViewBag.BankId = bankId;
            return View();
        }

        [TypeFilter(typeof(UserValidation))]
        [HttpGet("/update-employee/bank-id/{bankId:int}/user-id/{userId:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int bankId, [FromRoute] int userId)
        {
            return View(await _employeeReadService.GetEmployeeDto(userId));
        }
        */
    }
}
