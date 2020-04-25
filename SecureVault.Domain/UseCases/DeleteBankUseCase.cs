using SecureVault.Domain.Bank;
using SecureVault.Domain.Ports;
using SecureVault.Domain.Requests;

namespace SecureVault.Domain.UseCases
{
    public interface IDeleteBankUseCase
    {
        void Execute(DeleteBankRequest deleteBankRequest);
    }
    public class DeleteBankUseCase: IDeleteBankUseCase
    {
        private readonly ISecureVaultDataStore _secureVaultDataStore;

        public DeleteBankUseCase(ISecureVaultDataStore secureVaultDataStore)
        {
            _secureVaultDataStore = secureVaultDataStore;
        }
        public void Execute(DeleteBankRequest deleteBankRequest)
        {
            var bankData = new BankData(
                deleteBankRequest.BankId,
                deleteBankRequest.BankName,
                deleteBankRequest.AccountNumber,
                deleteBankRequest.Url,
                deleteBankRequest.LoginId,
                deleteBankRequest.Password,
                deleteBankRequest.CreateDate,
                deleteBankRequest.ModifyDate,
                active: false
            );
            _secureVaultDataStore.UpdateBank(bankData);
        }
    }
}
