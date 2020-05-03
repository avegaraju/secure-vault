using SecureVault.Domain.Card;
using SecureVault.Domain.Ports;
using SecureVault.Domain.Requests;

namespace SecureVault.Domain.UseCases
{
    public interface IUpdateCardUseCase
    {
        void Execute(UpdateCardRequest updateCardRequest);
    }

    public class UpdateCardUseCase: IUpdateCardUseCase
    {
        private readonly ISecureVaultDataStore _secureVaultDataStore;

        public UpdateCardUseCase(ISecureVaultDataStore secureVaultDataStore)
        {
            _secureVaultDataStore = secureVaultDataStore;
        }

        public void Execute(UpdateCardRequest updateCardRequest)
        {
            var cardData = CardData.Factory.Make(
                updateCardRequest.BankId,
                updateCardRequest.CardId,
                updateCardRequest.CardTypeId,
                updateCardRequest.CardNumber,
                updateCardRequest.Cvv,
                updateCardRequest.ExpiryMonth,
                updateCardRequest.ExpiryYear,
                updateCardRequest.Notes
            );

            _secureVaultDataStore.UpdateCard(cardData);
        }
    }
}
