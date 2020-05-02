using System;
using System.ComponentModel.DataAnnotations;

namespace SecureVault.Web.Models
{
    public class BankViewModel
    {
        public int BankId { get; set; }
        [Required(ErrorMessage = "Bank name is mandatory")]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Required(ErrorMessage = "Account number is mandatory")]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = "Login id is mandatory")]
        [Display(Name = "Login Id")]
        public string LoginId { get; set; }
        [Required(ErrorMessage = "Password is mandatory")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Bank's website url")]
        public string Url { get; set; }
        public DateTime CreateDate { get; set; }
        [Display(Name = "Additional notes")]
        public string Notes { get; set; }
    }
}
