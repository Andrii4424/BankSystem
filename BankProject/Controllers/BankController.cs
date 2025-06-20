using BankProject.Filters;
using BankServicesContracts.ServicesContracts;
using BankServicesContracts.ServicesContracts.BankService;
using DTO.BankDto;
using Entities.BanksEntities;
using Microsoft.AspNetCore.Mvc;
using UI.Filters;

namespace BankProject.Controllers
{
    public class BankController : Controller
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

        [Route("/banks-info")]
        public async Task<IActionResult> BanksList()
        {
            return View(await _bankReadService.GetAllBanksList());
        }

        [HttpGet("/bank-info/{bankId:int?}")]
        public async Task<IActionResult> BankInfo(int? bankId)
        {
            BankEntity bank = await _bankReadService.GetBankModel(bankId.Value);
            return View(bank);
        }

        [TypeFilter(typeof(UserValidation))]
        [HttpGet("/add-bank")]
        public IActionResult AddBank()
        {
            ViewBag.ObjectName = "Bank";
            return View();
        }

        [TypeFilter(typeof(ModelBindingFilter), Arguments = new object[] {nameof(AddBank)})]
        [HttpPost("/add-bank")]
        public IActionResult AddBank([FromForm] BankDto bank)
        {
            ViewBag.ObjectName = "Bank";
            if(ModelState.IsValid) _bankAddService.AddBank(bank);
            return View("AddBank");
        }

        [TypeFilter(typeof(UserValidation))]
        [HttpGet("/update-bank/bank-id/{bankId:int?}")]
        public async Task<IActionResult> UpdateBank(int bankId)
        {
            return View(await _bankReadService.GetBankDto(bankId));
        }

        [TypeFilter(typeof(ModelBindingFilter), Arguments = new object[] { nameof(UpdateBank) })]
        [HttpPost("/update-bank/bank-id/{bankId:int?}")]
        public async Task<IActionResult> UpdateBank([FromForm] BankDto bank, int bankId)
        {
            if(ModelState.IsValid) await _bankUpdateService.UpdateBank(bankId, bank);
            return View(bank);
        }

        [TypeFilter(typeof(UserValidation))]
        [HttpPost("/delete-bank/{bankId:int}")]
        public async Task<IActionResult> DeleteBank(int bankId)
        {
            await _bankDeleteService.DeleteBank(bankId);
            _logger.LogInformation("POST /delete-bank -> Success deleting bank, bankId: {BankId}", bankId);
            return RedirectToAction("BanksList", "Bank");
        }
    }
}
