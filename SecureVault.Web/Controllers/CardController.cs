using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecureVault.Domain.Requests;
using SecureVault.Domain.UseCases;
using SecureVault.Web.Models;

namespace SecureVault.Web.Controllers
{
    public class CardController : Controller
    {
        private readonly IGetBanksUseCase _getBanksUseCase;
        private readonly IGetCardTypesUseCase _getCardTypesUseCase;
        private readonly IAddCardUseCase _addCardUseCase;
        private readonly IGetCardsUseCase _getCardsUseCase;

        public CardController(
            IGetBanksUseCase getBanksUseCase,
            IGetCardTypesUseCase getCardTypesUseCase,
            IAddCardUseCase addCardUseCase, 
            IGetCardsUseCase getCardsUseCase
            )
        {
            _getBanksUseCase = getBanksUseCase;
            _getCardTypesUseCase = getCardTypesUseCase;
            _addCardUseCase = addCardUseCase;
            _getCardsUseCase = getCardsUseCase;
        }

        public IActionResult Index()
        {
            var cards = _getCardsUseCase.Get()
                .Select(response => new CardViewModel
                {
                    BankName = response.BankName,
                    BankId = response.BankId,
                    CardId = response.CardId,
                    CardNumber = response.CardNumber
                }).ToList();

            return View(cards);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CardViewModel cardViewModel)
        {
            if (ModelState.IsValid)
            {
                var addCardRequest = new AddCardRequest(
                    cardViewModel.BankId,
                    cardViewModel.CardTypeId,
                    cardViewModel.CardNumber,
                    cardViewModel.Cvv,
                    cardViewModel.ExpiryMonth,
                    cardViewModel.ExpiryYear,
                    cardViewModel.Notes
                );

                _addCardUseCase.Execute(addCardRequest);
            }
            else
            {
                return View("Create");
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int cardId)
        {
            return View();
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