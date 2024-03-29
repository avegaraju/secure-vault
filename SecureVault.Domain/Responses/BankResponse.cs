﻿using System;

namespace SecureVault.Domain.Responses
{
    public class BankResponse
    {
        public BankResponse(
            int bankId,
            string bankName,
            string accountNumber,
            string url,
            string loginId,
            string password,
            DateTime createDate,
            DateTime? modifyDate,
            string notes
        )
        {
            BankId = bankId;
            BankName = bankName;
            AccountNumber = accountNumber;
            Url = url;
            LoginId = loginId;
            Password = password;
            CreateDate = createDate;
            ModifyDate = modifyDate;
            Notes = notes;
        }

        public int BankId { get; }
        public string BankName { get; }
        public string AccountNumber { get; }
        public string LoginId { get; }
        public string Password { get; }
        public string Url { get; }
        public DateTime CreateDate { get; }
        public DateTime? ModifyDate { get; }
        public string Notes { get; }
    }
}
