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
        [Required(ErrorMessage = "Card number is required.")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Cvv is required.")]
        public int Cvv { get; set; }
        [Required(ErrorMessage = "Expiry month is required.")]
        public int ExpiryMonth { get; set; }
        [Required(ErrorMessage = "Expiry year is required.")]
        public int ExpiryYear { get; set; }
        public DateTime CreateDate { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Bank")]
        public IEnumerable<SelectListItem> BankNames { get; set; }
        [Display(Name = "Card types")]
        public IEnumerable<SelectListItem> CardTypes { get; set; }
    }
}
