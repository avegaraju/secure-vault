using System.Collections.Generic;
using System.Linq;
using SecureVault.Domain.Ports;
using SecureVault.Domain.Responses;

namespace SecureVault.Domain.UseCases
{
    public interface IGetBanksUseCase
    {
        IReadOnlyCollection<BankResponse> Get();
    }

    public class GetBanksUseCase: IGetBanksUseCase
    {
        private readonly ISecureVaultDataStore _secureVaultDataStore;

        public GetBanksUseCase(ISecureVaultDataStore secureVaultDataStore)
        {
            _secureVaultDataStore = secureVaultDataStore;
        }
        public IReadOnlyCollection<BankResponse> Get()
        {
            return _secureVaultDataStore.GetBanks()
                .Select(data =>
                    new BankResponse(
                        data.BankId.Value,
                        data.BankName,
                        data.AccountNumber,
                        data.Url,
                        data.LoginId,
                        data.Password,
                        data.CreateDate,
                        data.ModifyDate,
                        data.Notes
                    )
                ).ToList();
        }
    }
}
