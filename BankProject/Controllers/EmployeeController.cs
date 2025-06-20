using BankProject.Filters;
using BankServicesContracts.ServicesContracts;
using BankServicesContracts.ServicesContracts.EmployeeServiceContracts;
using DTO.PersonDto;
using Microsoft.AspNetCore.Mvc;
using UI.Filters;

namespace BankProject.Controllers
{
    public class EmployeeController : Controller
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

        [HttpGet("employee-info/bank-id/{bankId:int}")]
        public async Task<IActionResult> EmployeeInfo(int bankId)
        {
            ViewBag.BankName = await _employeeReadService.GetEmployeesBankName(bankId);
            ViewBag.BankId = bankId;
            return View(await _employeeReadService.GetAllBankEmployeesList(bankId));
        }

        [TypeFilter(typeof(UserValidation))]
        [HttpGet("/add-employee/bank-id/{bankId:int?}")]
        public IActionResult AddEmployee(int? bankId)
        {
            ViewBag.BankId = bankId;
            return View();
        }

        [TypeFilter(typeof(ModelBindingFilter), Arguments = new object[] { nameof(AddEmployee) })]
        [HttpPost("/add-employee/bank-id/{bankId:int?}")]
        public async Task<IActionResult> AddEmployee([FromRoute] int bankId, [FromForm] int EmployeeId, [FromForm] string JobTitle)
        {
            ViewBag.BankId = bankId;
            await _employeeAddService.AddEmployee(bankId, EmployeeId, JobTitle);
            return View();
        }

        [TypeFilter(typeof(UserValidation))]
        [HttpGet("/update-employee/bank-id/{bankId:int}/user-id/{userId:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int bankId, [FromRoute] int userId)
        {
            return View(await _employeeReadService.GetEmployeeDto(userId));
        }

        [TypeFilter(typeof(ModelBindingFilter), Arguments = new object[] { nameof(UpdateEmployee) })]
        [HttpPost("/update-employee/bank-id/{bankId:int}/user-id/{userId:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int bankId, [FromRoute] int userId, [FromForm] string JobTitle)
        {
            if(ModelState.IsValid) await _employeeUpdateService.UpdateEmployee(userId, JobTitle); 
            return View(await _employeeReadService.GetEmployeeDto(userId));
        }

        [TypeFilter(typeof(UserValidation))]
        [HttpPost("/delete-employee/bank-id/{bankId:int}/user-id/{userId:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int bankId, [FromRoute] int userId)
        {
            await _employeeDeleteService.FireEmployee(userId);
            _logger.LogInformation("POST /update-employee -> Succes deleting employee for bankId: {BankId}, " +
                "userId: {UserId}", bankId, userId);
            return RedirectToAction("EmployeeInfo", "Employee", new { bankId = bankId });
        }
    }
}
