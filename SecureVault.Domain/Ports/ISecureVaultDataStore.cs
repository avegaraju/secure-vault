using System.Collections.Generic;
using SecureVault.Domain.Bank;
using SecureVault.Domain.Card;

namespace SecureVault.Domain.Ports
{
    public interface ISecureVaultDataStore
    {
        void AddBank(BankData bankData);
        IReadOnlyCollection<BankData> GetBanks();
        BankData GetBankById(int bankId);
        void UpdateBank(BankData bankData);
        IReadOnlyCollection<CardTypesData> GetCardTypes();
    }
}
