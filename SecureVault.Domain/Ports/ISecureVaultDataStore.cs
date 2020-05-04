using System.Collections.Generic;
using SecureVault.Domain.Bank;
using SecureVault.Domain.Card;
using SecureVault.Domain.Requests;

namespace SecureVault.Domain.Ports
{
    public interface ISecureVaultDataStore
    {
        void AddBank(BankData bankData);
        IReadOnlyCollection<BankData> GetBanks();
        BankData GetBankById(int bankId);
        void UpdateBank(BankData bankData);
        void DeleteBank(int bankId);
        IReadOnlyCollection<CardTypesData> GetCardTypes();
        void AddCard(CardData cardData);
        IReadOnlyCollection<CardData> GetCards();
        CardData GetCardById(int cardId);
        void UpdateCard(CardData cardData);
        void DeleteCard(int cardId);
    }
}
