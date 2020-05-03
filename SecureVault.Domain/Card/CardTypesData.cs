namespace SecureVault.Domain.Card
{
    public class CardTypesData
    {
        public int CardTypeId { get; }
        public string CardType { get; }

        public CardTypesData(int cardTypeId, string cardType)
        {
            CardTypeId = cardTypeId;
            CardType = cardType;
        }
    }
}
