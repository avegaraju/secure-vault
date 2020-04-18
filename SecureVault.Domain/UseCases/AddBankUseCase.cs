using SecureVault.Domain.Bank;
using SecureVault.Domain.Ports;
using SecureVault.Domain.Requests;

namespace SecureVault.Domain.UseCases
{
    public interface IAddBankUseCase
    {
        void Execute(AddBankRequest request);
    }
    
    public class AddBankUseCase : IAddBankUseCase
    {
        private readonly ISecureVaultDataStore _secureVaultDataStore;

        public AddBankUseCase(ISecureVaultDataStore secureVaultDataStore)
        {
            _secureVaultDataStore = secureVaultDataStore;
        }

        public void Execute(AddBankRequest request)
        {
            _secureVaultDataStore.AddBank(new BankData(
                    request.BankName,
                    request.AccountNumber,
                    request.Url,
                    request.LoginId,
                    request.Password,
                    request.CreateDate
                )
            );
        }
    }
}
