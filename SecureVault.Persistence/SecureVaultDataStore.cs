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
    }
}
