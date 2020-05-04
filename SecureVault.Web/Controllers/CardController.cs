using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecureVault.Domain.Exceptions;
using SecureVault.Domain.Requests;
using SecureVault.Domain.Responses;
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
        private readonly IGetCardByIdUseCase _getCardByIdUseCase;
        private readonly IUpdateCardUseCase _updateCardUseCase;
        private readonly IDeleteCardUseCase _deleteCardUseCase;

        public CardController(
            IGetBanksUseCase getBanksUseCase,
            IGetCardTypesUseCase getCardTypesUseCase,
            IAddCardUseCase addCardUseCase,
            IGetCardsUseCase getCardsUseCase,
            IGetCardByIdUseCase getCardByIdUseCase,
            IUpdateCardUseCase updateCardUseCase, 
            IDeleteCardUseCase deleteCardUseCase)
        {
            _getBanksUseCase = getBanksUseCase;
            _getCardTypesUseCase = getCardTypesUseCase;
            _addCardUseCase = addCardUseCase;
            _getCardsUseCase = getCardsUseCase;
            _getCardByIdUseCase = getCardByIdUseCase;
            _updateCardUseCase = updateCardUseCase;
            _deleteCardUseCase = deleteCardUseCase;
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

        public ActionResult Delete(int id)
        {
            CardResponse cardResponse;
            IReadOnlyCollection<CardTypeResponse> cardTypeResponse;

            try
            {
                cardResponse = _getCardByIdUseCase.Get(id);
                cardTypeResponse = _getCardTypesUseCase.Get();
            }
            catch (NotFoundException e)
            {
                return View("NotFound");
            }

            var cardViewModel = new CardViewModel
            {
                BankId = cardResponse.BankId,
                BankName = cardResponse.BankName,
                CardId = cardResponse.CardId,
                CardNumber = cardResponse.CardNumber,
                CardTypes = cardTypeResponse.Select(
                    response => new SelectListItem(
                        response.CardType,
                        response.CardTypeId.ToString()
                    )
                ),
                CardTypeId = cardResponse.CardTypeId,
                CreateDate = cardResponse.CreateDate,
                Cvv = cardResponse.Cvv,
                ExpiryMonth = cardResponse.ExpiryMonth,
                ExpiryYear = cardResponse.ExpiryYear,
                Notes = cardResponse.Notes
            };

            cardViewModel.CardTypes.Single(
                item => item.Value == cardViewModel.CardTypeId.ToString()).Selected = true;

            return View(cardViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _deleteCardUseCase.Execute(id);
            }
            catch (Exception e)
            {
                throw;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            CardResponse cardResponse;
            IReadOnlyCollection<CardTypeResponse> cardTypeResponse;
            try
            {
                cardResponse = _getCardByIdUseCase.Get(id);
                cardTypeResponse = _getCardTypesUseCase.Get();
            }
            catch (NotFoundException e)
            {
                return View("NotFound");
            }

            var cardViewModel = new CardViewModel
            {
                BankId = cardResponse.BankId,
                BankName = cardResponse.BankName,
                CardId = cardResponse.CardId,
                CardNumber = cardResponse.CardNumber,
                CardTypes = cardTypeResponse.Select(
                            response => new SelectListItem(
                                response.CardType, 
                                response.CardTypeId.ToString()
                                )
                            ),
                CardTypeId = cardResponse.CardTypeId,
                CreateDate = cardResponse.CreateDate,
                Cvv = cardResponse.Cvv,
                ExpiryMonth = cardResponse.ExpiryMonth,
                ExpiryYear = cardResponse.ExpiryYear,
                Notes = cardResponse.Notes
            };

            cardViewModel.CardTypes.Single(
                item => item.Value == cardViewModel.CardTypeId.ToString()).Selected = true;

            return View(cardViewModel);
        }

        // POST: Card/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "BankId, CardId, CardTypeId,CardNumber, Cvv,ExpiryMonth,ExpiryYear,Notes") ]CardViewModel model)
        {
            if (ModelState.IsValid)
            {
                _updateCardUseCase.Execute(new UpdateCardRequest(
                        model.BankId,
                        model.CardId,
                        model.CardTypeId,
                        model.CardNumber,
                        model.Cvv,
                        model.ExpiryMonth,
                        model.ExpiryYear,
                        model.Notes
                    )
                );

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Edit");
                //return View("Edit", model);
                //return RedirectToAction("Edit", new
                //{
                //    Id = model.BankId,
                //    CardViewModel = model

                //});
            }
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