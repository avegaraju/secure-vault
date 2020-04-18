using System;

namespace SecureVault.Domain.Bank
{
    public class BankData
    {
        public BankData(
            string bankName,
            string accountNumber,
            string url,
            string loginId,
            string password
        )
        {
            BankName = bankName;
            AccountNumber = accountNumber;
            Url = url;
            LoginId = loginId;
            Password = password;
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
