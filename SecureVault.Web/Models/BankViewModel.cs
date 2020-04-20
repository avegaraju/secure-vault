using System;

namespace SecureVault.Web.Models
{
    public class BankViewModel
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
