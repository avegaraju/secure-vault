using SecureVault.Domain.Ports;

namespace SecureVault.Domain.UseCases
{
    public interface IDeleteBankUseCase
    {
        void Execute(int bankId);
    }
    public class DeleteBankUseCase: IDeleteBankUseCase
    {
        private readonly ISecureVaultDataStore _secureVaultDataStore;

        public DeleteBankUseCase(ISecureVaultDataStore secureVaultDataStore)
        {
            _secureVaultDataStore = secureVaultDataStore;
        }
        public void Execute(int bankId)
        {
            _secureVaultDataStore.DeleteBank(bankId);
        }
    }
}
