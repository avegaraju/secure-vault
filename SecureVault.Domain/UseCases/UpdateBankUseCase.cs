using SecureVault.Domain.Bank;
using SecureVault.Domain.Ports;
using SecureVault.Domain.Requests;

namespace SecureVault.Domain.UseCases
{
    public interface IUpdateBankUseCase
    {
        void Execute(UpdateBankRequest updateBankRequest);
    }

    public class UpdateBankUseCase: IUpdateBankUseCase
    {
        private readonly ISecureVaultDataStore _secureVaultDataStore;

        public UpdateBankUseCase(ISecureVaultDataStore secureVaultDataStore)
        {
            _secureVaultDataStore = secureVaultDataStore;
        }
        public void Execute(UpdateBankRequest updateBankRequest)
        {
            var bankData = new BankData(
                updateBankRequest.BankId,
                updateBankRequest.BankName,
                updateBankRequest.AccountNumber,
                updateBankRequest.Url,
                updateBankRequest.LoginId,
                updateBankRequest.Password,
                updateBankRequest.CreateDate,
                updateBankRequest.ModifyDate
            );
            _secureVaultDataStore.UpdateBank(bankData);
        }
    }
}
