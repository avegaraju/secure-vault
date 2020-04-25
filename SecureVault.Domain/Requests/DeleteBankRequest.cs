using System;

namespace SecureVault.Domain.Requests
{
    public class DeleteBankRequest
    {
        public DeleteBankRequest(
            int bankId,
            string bankName,
            string accountNumber,
            string loginId,
            string password,
            string url,
            DateTime createDate
        )
        {
            BankId = bankId;
            BankName = bankName;
            AccountNumber = accountNumber;
            LoginId = loginId;
            Password = password;
            Url = url;
            CreateDate = createDate;
            ModifyDate = DateTime.Now;
        }

        public int BankId { get; }
        public string BankName { get; }
        public string AccountNumber { get; }
        public string LoginId { get; }
        public string Password { get; }
        public string Url { get; }
        public DateTime CreateDate { get; }
        public DateTime ModifyDate { get; }
    }
}
