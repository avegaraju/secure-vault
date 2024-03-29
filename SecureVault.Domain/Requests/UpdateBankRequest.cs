﻿using System;

namespace SecureVault.Domain.Requests
{
    public class UpdateBankRequest
    {
        public UpdateBankRequest(
            int bankId,
            string bankName,
            string accountNumber,
            string loginId,
            string password,
            string url,
            DateTime createDate,
            string notes
        )
        {
            BankId = bankId;
            BankName = bankName;
            AccountNumber = accountNumber;
            LoginId = loginId;
            Password = password;
            Url = url;
            CreateDate = createDate;
            Notes = notes;
            ModifyDate = DateTime.Now;
        }

        public int BankId { get; }
        public string BankName { get; }
        public string AccountNumber { get; }
        public string LoginId { get; }
        public string Password { get; }
        public string Url { get; }
        public DateTime CreateDate { get; }
        public string Notes { get; }
        public DateTime ModifyDate { get; }
    }
}
