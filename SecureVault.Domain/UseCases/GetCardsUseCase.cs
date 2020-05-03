using System.Collections.Generic;
using System.Linq;
using SecureVault.Domain.Ports;
using SecureVault.Domain.Responses;

namespace SecureVault.Domain.UseCases
{
    public interface IGetCardsUseCase
    {
        IReadOnlyCollection<CardResponse> Get();
    }

    public class GetCardsUseCase: IGetCardsUseCase
    {
        private readonly ISecureVaultDataStore _secureVaultDataStore;

        public GetCardsUseCase(ISecureVaultDataStore secureVaultDataStore)
        {
            _secureVaultDataStore = secureVaultDataStore;
        }

        public IReadOnlyCollection<CardResponse> Get()
        {
            return _secureVaultDataStore.GetCards()
                .Select(data => new CardResponse
                {
                    BankId = data.BankId,
                    CardId = data.CardId,
                    BankName = data.BankName,
                    CardNumber = data.CardNumber,
                    CardTypeId = data.CardTypeId,
                    CreateDate = data.CreateDate,
                    Cvv = data.Cvv,
                    ExpiryMonth = data.ExpiryMonth,
                    ExpiryYear = data.ExpiryYear,
                    Notes = data.Notes
                }).ToList();
        }
    }
}
