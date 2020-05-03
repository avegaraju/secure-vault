using System.Collections.Generic;
using System.Linq;
using SecureVault.Domain.Ports;
using SecureVault.Domain.Responses;

namespace SecureVault.Domain.UseCases
{
    public interface IGetCardTypesUseCase
    {
        IReadOnlyCollection<CardTypeResponse> Get();
    }
    public class GetCardTypesUseCase: IGetCardTypesUseCase
    {
        private readonly ISecureVaultDataStore _secureVaultDataStore;

        public GetCardTypesUseCase(ISecureVaultDataStore secureVaultDataStore)
        {
            _secureVaultDataStore = secureVaultDataStore;
        }

        public IReadOnlyCollection<CardTypeResponse> Get()
        {
            return _secureVaultDataStore.GetCardTypes()
                .Select(data => new CardTypeResponse
                {
                    CardTypeId = data.CardTypeId,
                    CardType = data.CardType
                }).ToList();
        }
    }
}
