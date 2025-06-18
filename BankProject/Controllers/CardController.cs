using BankProject.Filters;
using BankServices.BankService;
using BankServicesContracts.ServicesContracts;
using BankServicesContracts.ServicesContracts.CardServiceContracts;
using DTO.BankDto;
using Microsoft.AspNetCore.Mvc;

namespace BankProject.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardReadService _cardReadService;
        private readonly ICardAddService _cardAddService;
        private readonly ICardUpdateService _cardUpdateService;
        private readonly ICardDeleteService _cardDeleteService;
        private readonly ILogger<CardController> _logger;

        public CardController(ICardReadService cardReadService, ICardAddService cardAddService,
            ICardUpdateService cardUpdateService, ICardDeleteService cardDeleteService, ILogger<CardController> logger)
        {
            _cardReadService = cardReadService;
            _cardAddService = cardAddService;
            _cardUpdateService = cardUpdateService;
            _cardDeleteService = cardDeleteService;
            _logger = logger;
        }

        [HttpGet("/cards-info/bank-id/{bankId:int}")]
        public async Task<IActionResult> CardsInfo(int bankId)
        {
            ViewBag.BankId = bankId;
            ViewBag.BankName = await _cardReadService.GetCardBankName(bankId);
            return View(await _cardReadService.GetCardsListByBankId(bankId));
        }

        [HttpGet("/add-bank-card/bank-id/{bankId:int?}")]
        public IActionResult AddCard(int bankId)
        {
            ViewBag.BankId = bankId;
            return View();
        }

        [TypeFilter(typeof(ModelBindingFilter), Arguments = new object[] { nameof(AddCard) })]
        [HttpPost("/add-bank-card/bank-id/{bankId:int}")]
        public async Task<IActionResult> AddCard([FromRoute] int bankId, [FromForm] CardDto card)
        {
            ViewBag.BankId = bankId;
            if(ModelState.IsValid) await _cardAddService.AddCard(card);
            return View(card);
        }


        [HttpGet("/update-card/bank-id/{bankId:int}/card-id/{cardId:int}")]
        public async Task<IActionResult> UpdateCard([FromRoute] int bankId, [FromRoute] int cardId)
        {
            return View(await _cardReadService.GetCardDto(cardId));
        }

        [TypeFilter(typeof(ModelBindingFilter), Arguments = new object[] { nameof(UpdateCard) })]
        [HttpPost("/update-card/bank-id/{bankId:int}/card-id/{cardId:int}")]
        public async Task<IActionResult> UpdateCard([FromForm] CardDto cardDto, [FromRoute] int bankId, 
            [FromRoute] int cardId)
        {
            if(ModelState.IsValid) await _cardUpdateService.UpdateCard(cardId, cardDto);
            return View(cardDto);
        }

        [HttpPost("/delete-card/bank-id/{bankId:int}/card-id/{cardId:int}")]
        public async Task<IActionResult> DeleteCard([FromRoute] int bankId, int cardId)
        {
            await _cardDeleteService.DeleteCard(cardId);
            _logger.LogInformation("POST /delete-card -> Success deleting card for bankId: {BankId}, cardId: {CardId}", bankId, cardId);
            return RedirectToAction("CardsInfo", "Card", new { bankId = bankId });
        }
    }
}
