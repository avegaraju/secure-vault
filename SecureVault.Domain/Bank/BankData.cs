﻿using System;

namespace SecureVault.Domain.Bank
{
    public class BankData
    {
        public BankData(
            string bankName,
            string accountNumber,
            string url,
            string loginId,
            string password,
            DateTime createDate,
            DateTime? modifyDate = null,
            bool active = true
        ) : this(
            null,
            bankName,
            accountNumber,
            url,
            loginId,
            password,
            createDate,
            modifyDate,
            active
        )
        {
        }

        public BankData(
            int? bankId,
            string bankName,
            string accountNumber,
            string url,
            string loginId,
            string password,
            DateTime createDate,
            DateTime? modifyDate=null,
            bool active = true
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
            Active = active;
        }

        public int? BankId { get; }
        public string BankName { get; }
        public string AccountNumber { get; }
        public string LoginId { get; }
        public string Password { get; }
        public string Url { get; }
        public DateTime CreateDate { get; }
        public DateTime? ModifyDate { get; }
        public bool Active { get; }
    }
}
