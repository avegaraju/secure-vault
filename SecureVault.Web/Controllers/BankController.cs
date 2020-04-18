using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureVault.Domain.Requests;
using SecureVault.Domain.UseCases;
using SecureVault.Web.Models;

namespace SecureVault.Web.Controllers
{
    public class BankController : Controller
    {
        private readonly IAddBankUseCase _addBankUseCase;

        public BankController(IAddBankUseCase addBankUseCase)
        {
            _addBankUseCase = addBankUseCase;
        }
        // GET: Bank
        [Route("Bank", Name = "ShowBanks")]
        public ActionResult Index()
        {
            return View();
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
                        model.Password
                    );
                    
                    _addBankUseCase.Execute(request);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return RedirectToAction(nameof(Index)); ;
            }
        }

        // POST: Bank/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Bank/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bank/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bank/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bank/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}