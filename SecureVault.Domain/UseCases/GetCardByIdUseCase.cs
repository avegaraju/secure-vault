using SecureVault.Domain.Exceptions;
using SecureVault.Domain.Ports;
using SecureVault.Domain.Responses;

namespace SecureVault.Domain.UseCases
{
    public interface IGetCardByIdUseCase
    {
        CardResponse Get(int cardId);
    }
    public class GetCardByIdUseCase: IGetCardByIdUseCase
    {
        private readonly ISecureVaultDataStore _secureVaultDataStore;

        public GetCardByIdUseCase(ISecureVaultDataStore secureVaultDataStore)
        {
            _secureVaultDataStore = secureVaultDataStore;
        }
        public CardResponse Get(int cardId)
        {
            var cardData = _secureVaultDataStore.GetCardById(cardId);

            if(cardData == null)
                throw new NotFoundException("Card data not found.");

            return new CardResponse
            {
                BankId = cardData.BankId,
                BankName = cardData.BankName,
                CardId = cardData.CardId,
                CardNumber = cardData.CardNumber,
                CardTypeId = cardData.CardTypeId,
                CreateDate = cardData.CreateDate,
                Cvv = cardData.Cvv,
                ExpiryYear = cardData.ExpiryYear,
                ExpiryMonth = cardData.ExpiryMonth,
                Notes = cardData.Notes
            };
        }
    }
}
