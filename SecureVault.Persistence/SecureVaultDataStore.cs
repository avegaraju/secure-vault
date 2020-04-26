using System.Collections.Generic;
using System.ComponentModel.Design;
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
                ModifyDate = null,
                Active = bankData.Active
            });

            SaveChanges();
        }

        public IReadOnlyCollection<BankData> GetBanks()
        {
            return Banks
                .Where(bank => bank.Active)
                .Select(bank =>
                    new BankData(
                        bank.BankId,
                        bank.Name,
                        bank.AccountNumber,
                        bank.Url,
                        bank.LoginId,
                        bank.Password,
                        bank.CreateDate,
                        bank.ModifyDate,
                        bank.Active
                    )
                ).ToList();
        }

        public BankData GetBankById(int bankId)
        {
            var bank = Banks.Find(bankId);

            if (bank == null || bank.Active == false)
                return null;
            
            return new BankData(
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
                ModifyDate = bankData.ModifyDate,
                Active = bankData.Active
            };
            
            Banks.Update(bank);
            SaveChanges();
        }
    }
}
