using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SecureVault.Domain.Bank;
using SecureVault.Domain.Card;
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
                Active = bankData.Active,
                Notes = bankData.Notes
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
                        bank.Notes,
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
                bank.Notes,
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
                Active = bankData.Active,
                Notes = bankData.Notes
            };
            
            Banks.Update(bank);
            SaveChanges();
        }

        public IReadOnlyCollection<CardTypesData> GetCardTypes()
        {
            return CardTypes
                .Select(type => new CardTypesData(type.CardTypeId, type.Name))
                .ToList();
        }

        public void AddCard(CardData cardData)
        {
            Cards.Add(new Card
            {
                BankId = cardData.BankId,
                CardNumber = cardData.CardNumber,
                CardTypeId = cardData.CardTypeId,
                CreateDate = cardData.CreateDate,
                Cvv = cardData.Cvv,
                ExpiryMonth = cardData.ExpiryMonth,
                ExpiryYear = cardData.ExpiryYear,
                Notes = cardData.Notes
            });

            SaveChanges();
        }

        public IReadOnlyCollection<CardData> GetCards()
        {
            return Cards.Join(
                inner: Banks,
                outerKeySelector: card => card.BankId,
                innerKeySelector: bank => bank.BankId,
                resultSelector: (card, bank) => new {Card = card, Bank = bank}
            ).Join(
                CardTypes,
                outerKeySelector: bankCardTuple => bankCardTuple.Card.CardTypeId,
                innerKeySelector: type => type.CardTypeId,
                (bankCard, type) => CardData.Factory.Make(
                    bankCard.Bank.BankId,
                    bankCard.Card.CardId,
                    bankCard.Bank.Name,
                    bankCard.Card.CardTypeId,
                    bankCard.Card.CardNumber,
                    bankCard.Card.Cvv,
                    bankCard.Card.ExpiryMonth,
                    bankCard.Card.ExpiryYear,
                    bankCard.Card.CreateDate,
                    bankCard.Card.Notes
                )
            ).ToList();
        }
    }
}
