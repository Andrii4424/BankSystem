using BankProject;
using BankServicesContracts.ServicesContracts.BankService;
using DTO.BankDto;
using Entities.BanksEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankReadService _bankReadService;
        private readonly IBankAddService _bankAddService;
        private readonly IBankDeleteService _bankDeleteService;
        private readonly IBankUpdateService _bankUpdateService;
        private readonly ILogger<BankController> _logger;

        public BankController(IBankReadService bankReadService, IBankAddService bankAddService,
            IBankDeleteService bankDeleteService, IBankUpdateService bankUpdateService, ILogger<BankController> logger)
        {
            _bankAddService = bankAddService;
            _bankDeleteService = bankDeleteService;
            _bankUpdateService = bankUpdateService;
            _bankReadService = bankReadService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> BanksList()
        {
            /// <summary>
            /// Showing banks list 
            /// </summary>
            /// <returns></returns>
            return Ok(await _bankReadService.GetAllBanksList());
        }

        [HttpGet("{bankId:int?}")]
        public async Task<IActionResult> BankInfo(int? bankId)
        {
            /// <summary>
            /// Showing bank info, bank serches by id
            /// </summary>
            /// <returns></returns>
            BankEntity bank = await _bankReadService.GetBankModel(bankId.Value);
            return Ok(bank);
        }

        [HttpPost]
        public async Task<IActionResult> AddBank([FromForm] BankDto bank)
        {
            /// <summary>
            /// Adding bank
            /// </summary>
            /// <returns></returns>
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("POST /{ActionName} -> Invalid model", nameof(AddBank));
                List<string> errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                return BadRequest(errors);
            }
            await _bankAddService.AddBank(bank);
            return Ok(await _bankReadService.GetAllBanksList());
        }

        [HttpPut("{bankId:int?}")]
        public async Task<IActionResult> UpdateBank([FromForm] BankDto bank, int bankId)
        {
            /// <summary>
            /// Updating bank
            /// </summary>
            /// <returns></returns>
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("POST /{ActionName} -> Invalid model", nameof(AddBank));
                List<string> errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                return BadRequest(errors);
            }
            await _bankUpdateService.UpdateBank(bankId, bank);
            return Ok(await _bankReadService.GetAllBanksList());
        }

        [HttpDelete("{bankId:int}")]
        public async Task<IActionResult> DeleteBank(int bankId)
        {
            /// <summary>
            /// Deleting object
            /// </summary>
            /// <returns></returns>
            await _bankDeleteService.DeleteBank(bankId);
            _logger.LogInformation("POST /delete-bank -> Success deleting bank, bankId: {BankId}", bankId);
            return Ok();//TO DO : Redirect 
        } 

        /*
        [TypeFilter(typeof(UserValidation))]
        [HttpGet("/add-bank")]
        public IActionResult AddBank()
        {
            ViewBag.ObjectName = "Bank";
            return View();
        }

        [TypeFilter(typeof(UserValidation))]
        [HttpGet("/update-bank/bank-id/{bankId:int?}")]
        public async Task<IActionResult> UpdateBank(int bankId)
        {
            return View(await _bankReadService.GetBankDto(bankId));
        }      
         */
    }
}
