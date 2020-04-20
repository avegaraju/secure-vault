using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SecureVault.Domain.Bank;
using SecureVault.Domain.Ports;
using SecureVault.Persistence.Models;

namespace SecureVault.Persistence
{
    public class SecureVaultDataStore: SecureVaultContext, ISecureVaultDataStore 
    {
        public SecureVaultDataStore(DbContextOptions options) : base(options)
        {
        }

        public void AddBank(BankData bankData)
        {
            Banks.Add(new Bank
            {
                Name = bankData.BankName,
                AccountNumber = bankData.AccountNumber,
                LoginId = bankData.LoginId,
                Password = bankData.Password,
                CreateDate = bankData.CreateDate,
                Url = bankData.Url,
                ModifyDate = null
            });

            SaveChanges();
        }

        public IReadOnlyCollection<BankData> GetBanks()
        {
            return Banks.Select(bank =>
                new BankData(
                    bank.BankId,
                    bank.Name,
                    bank.AccountNumber,
                    bank.Url,
                    bank.LoginId,
                    bank.Password,
                    bank.CreateDate,
                    bank.ModifyDate
                )
            ).ToList();
        }

        public BankData GetBankById(int bankId)
        {
            var bank = Banks.Find(bankId);
            
            return bank == null
                ? null
                : new BankData(
                    bank.BankId,
                    bank.Name,
                    bank.AccountNumber,
                    bank.Url,
                    bank.LoginId,
                    bank.Password,
                    bank.CreateDate,
                    bank.ModifyDate
                );
        }

        public void UpdateBank(BankData bankData)
        {
            var bank = new Bank
            {
                BankId = bankData.BankId.Value,
                Name = bankData.BankName,
                AccountNumber = bankData.AccountNumber,
                LoginId = bankData.LoginId,
                Password = bankData.Password,
                Url = bankData.Url,
                CreateDate = bankData.CreateDate,
                ModifyDate = bankData.ModifyDate
            };
            
            Banks.Update(bank);
            SaveChanges();
        }
    }
}
