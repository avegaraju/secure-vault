using System;

namespace SecureVault.Domain.Responses
{
    public class CardResponse
    {
        public int BankId { get; set; }
        public int CardId { get; set; }
        public string BankName { get; set; }
        public int CardTypeId { get; set; }
        public string CardNumber { get; set; }
        public int Cvv { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public DateTime CreateDate { get; set; }
        public string Notes { get; set; }
    }
}
