using System;

namespace SecureVault.Domain.Card
{
    public class CardData
    {
        private CardData(
            int bankId,
            int cardTypeId,
            string cardNumber,
            int cvv,
            int expiryMonth,
            int expiryYear,
            string notes
        )
        {
            BankId = bankId;
            CardTypeId = cardTypeId;
            CardNumber = cardNumber;
            Cvv = cvv;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
            CreateDate = DateTime.Now;
            Notes = notes;
        }

        public int BankId { get; set; }
        public int CardTypeId { get; set; }
        public string CardNumber { get; set; }
        public int Cvv { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public DateTime CreateDate { get; set; }
        public string Notes { get; set; }

        public static class Factory
        {
            public static CardData CreateNew(
                int bankId,
                int cardTypeId,
                string cardNumber,
                int cvv,
                int expiryMonth,
                int expiryYear,
                DateTime createDate,
                string notes
                )
            {
                return new CardData(
                    bankId,
                    cardTypeId,
                    cardNumber,
                    cvv,
                    expiryMonth,
                    expiryYear,
                    notes
                );
            }
        }
    }
}
