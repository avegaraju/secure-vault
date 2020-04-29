using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureVault.Domain.Exceptions;
using SecureVault.Domain.Requests;
using SecureVault.Domain.Responses;
using SecureVault.Domain.UseCases;
using SecureVault.Web.Models;

namespace SecureVault.Web.Controllers
{
    public class BankController : Controller
    {
        private readonly IAddBankUseCase _addBankUseCase;
        private readonly IGetBanksUseCase _getBanksUseCase;
        private readonly IGetBankByIdUseCase _getBankByIdUseCase;
        private readonly IUpdateBankUseCase _updateBankUseCase;
        private readonly IDeleteBankUseCase _deleteBankUseCase;

        public BankController(
            IAddBankUseCase addBankUseCase,
            IGetBanksUseCase getBanksUseCase,
            IGetBankByIdUseCase getBankByIdUseCase,
            IUpdateBankUseCase updateBankUseCase,
            IDeleteBankUseCase deleteBankUseCase
        )
        {
            _addBankUseCase = addBankUseCase;
            _getBanksUseCase = getBanksUseCase;
            _getBankByIdUseCase = getBankByIdUseCase;
            _updateBankUseCase = updateBankUseCase;
            _deleteBankUseCase = deleteBankUseCase;
        }

        // GET: Bank
        [Route("Bank", Name = "ShowBanks")]
        public ActionResult Index()
        {
            var banks = _getBanksUseCase.Get()
                .Select(response =>
                    new BankViewModel
                    {
                        BankId =  response.BankId,
                        BankName = response.BankName,
                        AccountNumber = response.AccountNumber,
                        LoginId = response.LoginId,
                        Password = response.Password,
                        Url = response.Url
                    }
                ).ToList();

            return View(banks);
        }

        // GET: Bank/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bank/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BankViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var request = new AddBankRequest(
                        model.BankName,
                        model.AccountNumber,
                        model.LoginId,
                        model.Password,
                        model.Url,
                        model.Notes
                    );
                    
                    _addBankUseCase.Execute(request);
                }
                else
                {
                    return View("Create");
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return RedirectToAction(nameof(Index)); ;
            }
        }

        // GET: Bank/Edit/5
        public ActionResult Edit(int id)
        {
            BankResponse response;

            try
            {
                response = _getBankByIdUseCase.Get(id);
            }
            catch (NotFoundException e)
            {
                return View("NotFound");
            }

            var bankViewModel = new BankViewModel
            {
                BankId = response.BankId,
                BankName = response.BankName,
                AccountNumber = response.AccountNumber,
                LoginId = response.LoginId,
                Password = response.Password,
                Url = response.Url,
                CreateDate = response.CreateDate
            };

            return View(bankViewModel);
        }

        // POST: Bank/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection formCollection)
        public ActionResult Edit([Bind(include:"BankId, BankName, AccountNumber, LoginId, Password, Url, CreateDate")]BankViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updateBankRequest = new UpdateBankRequest(
                        model.BankId,
                        model.BankName,
                        model.AccountNumber,
                        model.LoginId,
                        model.Password,
                        model.Url,
                        model.CreateDate,
                        model.Notes
                    );

                    _updateBankUseCase.Execute(updateBankRequest);
                    
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Edit", new
                    {
                        BankId= model.BankId, 
                        BankName= model.BankName,
                        AccountNumber = model.AccountNumber,
                        LoginId = model.LoginId,
                        Password = model.Password,
                        Url = model.Url,
                        CreateDate = model.CreateDate
                    });
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Bank/Delete/5
        public ActionResult Delete(int id)
        {
            BankResponse bankResponse;
            try
            {
                bankResponse = _getBankByIdUseCase.Get(id);
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }
            
            var bankViewModel = new BankViewModel
            {
                AccountNumber = bankResponse.AccountNumber,
                BankId = bankResponse.BankId,
                BankName = bankResponse.BankName,
                CreateDate = bankResponse.CreateDate,
                LoginId = bankResponse.LoginId,
                Password = bankResponse.Password,
                Url = bankResponse.Url
            };

            return View(bankViewModel);
        }

        // POST: Bank/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection formCollection)
        {
            try
            {
                var bankName = formCollection["BankName"][0];
                var accountNumber = formCollection["AccountNumber"][0];
                var loginId = formCollection["LoginId"][0];
                var password = formCollection["Password"][0];
                var url = formCollection["Url"][0];
                var createDate = DateTime.Parse(formCollection["CreateDate"][0]);

                var deleteBankRequest = new DeleteBankRequest(
                    id,
                    bankName,
                    accountNumber,
                    loginId,
                    password,
                    url,
                    createDate,
                    string.Empty
                );

                _deleteBankUseCase.Execute(deleteBankRequest);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}