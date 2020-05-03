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

        private CardData(
            int bankId,
            int cardId,
            string bankName,
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
            BankName = bankName;
            CardTypeId = cardTypeId;
            CardNumber = cardNumber;
            Cvv = cvv;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
            CreateDate = DateTime.Now;
            Notes = notes;
        }

        private CardData(
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
        public string BankName { get; }
        public int CardTypeId { get; }
        public string CardNumber { get; }
        public int Cvv { get; }
        public int ExpiryMonth { get; }
        public int ExpiryYear { get; }
        public DateTime CreateDate { get; }
        public string Notes { get; }

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

            public static CardData Make(
                int bankId,
                int cardId,
                string bankName,
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
                    cardId,
                    bankName,
                    cardTypeId,
                    cardNumber,
                    cvv,
                    expiryMonth,
                    expiryYear,
                    notes
                );
            }

            public static CardData Make(
                int cardId,
                int bankId,
                int cardTypeId,
                string cardNumber,
                int cvv,
                int expiryMonth,
                int expiryYear,
                string notes
            )
            {
                return new CardData(
                    bankId,
                    cardId,
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
