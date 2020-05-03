using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecureVault.Web.Models
{
    public class CardViewModel
    {
        public int CardId { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int CardTypeId { get; set; }
        public string CardNumber { get; set; }
        public int Cvv { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public DateTime CreateDate { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Bank")]
        public IEnumerable<SelectListItem> BankNames { get; set; }
        [Display(Name = "Card types")]
        public IEnumerable<SelectListItem> CardTypes { get; set; }
    }
}
