using System;

namespace SecureVault.Domain.Requests
{
    public class AddCardRequest
    {
        public AddCardRequest(
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
    }
}
