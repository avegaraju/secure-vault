using SecureVault.Domain.Card;
using SecureVault.Domain.Ports;
using SecureVault.Domain.Requests;

namespace SecureVault.Domain.UseCases
{
    public interface IAddCardUseCase
    {
        void Execute(AddCardRequest addCardRequest);
    }
    public class AddCardUseCase: IAddCardUseCase
    {
        private readonly ISecureVaultDataStore _secureVaultDataStore;

        public AddCardUseCase(ISecureVaultDataStore secureVaultDataStore)
        {
            _secureVaultDataStore = secureVaultDataStore;
        }
        public void Execute(AddCardRequest addCardRequest)
        {
            var cardData = CardData.Factory.CreateNew(
                addCardRequest.BankId,
                addCardRequest.CardTypeId,
                addCardRequest.CardNumber,
                addCardRequest.Cvv,
                addCardRequest.ExpiryMonth,
                addCardRequest.ExpiryYear,
                addCardRequest.CreateDate,
                addCardRequest.Notes
            );
            _secureVaultDataStore.AddCard(cardData);
        }
    }
}
