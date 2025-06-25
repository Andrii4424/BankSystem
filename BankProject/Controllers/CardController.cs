using BankProject;
using BankServicesContracts.ServicesContracts.CardServiceContracts;
using DTO.BankDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
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

        [HttpGet("{bankId:Guid}")]
        public async Task<IActionResult> CardsInfo(Guid bankId)
        {
            return Ok(await _cardReadService.GetCardsListByBankId(bankId));
        }

        [HttpPost("{bankId:Guid}")]
        public async Task<IActionResult> AddCard([FromRoute] Guid bankId, [FromForm] CardDto cardDto)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                return BadRequest(errors);
            }
            await _cardAddService.AddCard(cardDto);
            return Ok(cardDto);
        }

        [HttpPut("{bankId:Guid}/{cardId:Guid}")]
        public async Task<IActionResult> UpdateCard([FromForm] CardDto cardDto, [FromRoute] Guid bankId,
    [FromRoute] Guid cardId)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = ErrorHandler.PrintErrorList(ModelState, HttpContext);
                return BadRequest(errors);
            }
            await _cardUpdateService.UpdateCard(cardId, cardDto);
            return Ok(cardDto);
        }

        [HttpDelete("{bankId:Guid}/{cardId:Guid}")]
        public async Task<IActionResult> DeleteCard([FromRoute] Guid bankId, Guid cardId)
        {
            await _cardDeleteService.DeleteCard(cardId);
            _logger.LogInformation("POST /delete-card -> Success deleting card for bankId: {BankId}, cardId: {CardId}", bankId, cardId);
            return Ok(); //TO DO : Redirect 
        }

        /*


        [TypeFilter(typeof(UserValidation))]
        [HttpGet("/add-bank-card/bank-id/{bankId:int?}")]
        public IActionResult AddCard(int bankId)
        {
            ViewBag.BankId = bankId;
            return View();
        }



        [TypeFilter(typeof(UserValidation))]
        [HttpGet("/update-card/bank-id/{bankId:int}/card-id/{cardId:int}")]
        public async Task<IActionResult> UpdateCard([FromRoute] int bankId, [FromRoute] int cardId)
        {
            return View(await _cardReadService.GetCardDto(cardId));
        }



        [TypeFilter(typeof(UserValidation))]

        */
    }
}
