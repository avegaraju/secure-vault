using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecureVault.Domain.UseCases;
using SecureVault.Web.Models;

namespace SecureVault.Web.Controllers
{
    public class CardController : Controller
    {
        private readonly IGetBanksUseCase _getBanksUseCase;
        private readonly IGetCardTypesUseCase _getCardTypesUseCase;

        public CardController(
            IGetBanksUseCase getBanksUseCase,
            IGetCardTypesUseCase getCardTypesUseCase
            )
        {
            _getBanksUseCase = getBanksUseCase;
            _getCardTypesUseCase = getCardTypesUseCase;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CardViewModel cardViewModel)
        {

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            var bankNames = _getBanksUseCase.Get()
                .Select(response => new SelectListItem(response.BankName, response.BankId.ToString()))
                .ToList();

            var cardTypes = _getCardTypesUseCase.Get()
                .Select(response => new SelectListItem(response.CardType, response.CardTypeId.ToString()))
                .ToList();

            var cardViewModel = new CardViewModel
            {
                BankNames = bankNames,
                CardTypes = cardTypes
            };

            return View(cardViewModel);
        }
    }
}