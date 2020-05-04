using SecureVault.Domain.Ports;

namespace SecureVault.Domain.UseCases
{
    public interface IDeleteCardUseCase
    {
        void Execute(int cardId);
    }
    public class DeleteCardUseCase : IDeleteCardUseCase
    {
        private readonly ISecureVaultDataStore _secureVaultDataStore;

        public DeleteCardUseCase(ISecureVaultDataStore secureVaultDataStore)
        {
            _secureVaultDataStore = secureVaultDataStore;
        }
        public void Execute(int cardId)
        {
            _secureVaultDataStore.DeleteCard(cardId);
        }
    }
}
