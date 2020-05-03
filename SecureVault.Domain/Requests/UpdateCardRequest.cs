using System;

namespace SecureVault.Domain.Requests
{
    public class UpdateCardRequest
    {
        public UpdateCardRequest(
            int bankId,
            int cardId,
            int cardTypeId,
            string cardNumber,
            int cvv,
            int expiryMonth,
            int expiryYear,
            string notes
        )
        {
            BankId = bankId;
            CardId = cardId;
            CardTypeId = cardTypeId;
            CardNumber = cardNumber;
            Cvv = cvv;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
            CreateDate = DateTime.Now;
            Notes = notes;
        }

        public int BankId { get; }
        public int CardId { get; }
        public int CardTypeId { get; }
        public string CardNumber { get; }
        public int Cvv { get; }
        public int ExpiryMonth { get; }
        public int ExpiryYear { get; }
        public DateTime CreateDate { get; }
        public string Notes { get; }
    }
}
