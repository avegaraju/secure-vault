using System;
using System.Runtime;

namespace SecureVault.Domain.Requests
{
    public class AddBankRequest
    {
        public AddBankRequest(
            string bankName, 
            string accountNumber, 
            string loginId, 
            string password,
            string url
            )
        {
            BankName = bankName;
            AccountNumber = accountNumber;
            LoginId = loginId;
            Password = password;
            Url = url;
            CreateDate = DateTime.Now;
        }

        public string BankName { get; }
        public string AccountNumber { get; }
        public string LoginId { get; }
        public string Password { get; }
        public string Url { get; }
        public DateTime CreateDate { get; }
    }
}
