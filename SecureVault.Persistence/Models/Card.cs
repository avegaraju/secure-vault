using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecureVault.Persistence.SqlServer.Models
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }
        [ForeignKey("BankId")]
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        [ForeignKey("CardType")]
        public int CardTypeId { get; set; }
        public virtual CardType CardType { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public int Cvv { get; set; }
        [Required]
        public int ExpiryMonth { get; set; }
        [Required]
        public int ExpiryYear { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public string Notes { get; set; }
    }
}
