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

        [HttpGet("{bankId:Guid}")]
        public async Task<IActionResult> EmployeeInfo(Guid bankId)
        {
            return Ok(await _employeeReadService.GetAllBankEmployeesList(bankId));
        }

        [HttpPost("{bankId:Guid?}")]
        public async Task<IActionResult> AddEmployee([FromRoute] Guid bankId, [FromForm] Guid userId, [FromForm] string JobTitle)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                return BadRequest(errors);
            }
            await _employeeAddService.AddEmployee(bankId, userId, JobTitle);
            return Ok(await _employeeReadService.GetEmployeeById(userId, bankId));
        }

        [HttpPut("{bankId:Guid}/{userId:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid bankId, [FromRoute] Guid userId, [FromForm] string JobTitle)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                return BadRequest(errors);
            }
            await _employeeUpdateService.UpdateEmployee(userId, JobTitle);
            return Ok(await _employeeReadService.GetEmployeeById(userId, bankId));
        }

        [HttpDelete("{bankId:Guid}/{userId:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid bankId, [FromRoute] Guid userId)
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
