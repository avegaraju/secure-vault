using System.Collections.Generic;
using SecureVault.Domain.Exceptions;
using SecureVault.Domain.Ports;
using SecureVault.Domain.Responses;

namespace SecureVault.Domain.UseCases
{
    public interface IGetBankByIdUseCase
    {
        BankResponse Get(int bankId);
    }

    public class GetBankByIdUseCase: IGetBankByIdUseCase
    {
        private readonly ISecureVaultDataStore _secureVaultDataStore;

        public GetBankByIdUseCase(ISecureVaultDataStore secureVaultDataStore)
        {
            _secureVaultDataStore = secureVaultDataStore;
        }

        public BankResponse Get(int bankId)
        {
            var bankData = _secureVaultDataStore.GetBankById(bankId);

            if(bankData == null)
                throw new NotFoundException("Bank data not found.");

            return new BankResponse(
                bankData.BankId.Value,
                bankData.BankName,
                bankData.AccountNumber,
                bankData.Url,
                bankData.LoginId,
                bankData.Password,
                bankData.CreateDate,
                bankData.ModifyDate,
                bankData.Notes
            );
        }
    }
}
