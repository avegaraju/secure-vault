using System.Collections.Generic;
using SecureVault.Domain.Bank;

namespace SecureVault.Domain.Ports
{
    public interface ISecureVaultDataStore
    {
        void AddBank(BankData bankData);
        IReadOnlyCollection<BankData> GetBanks();
    }
}
