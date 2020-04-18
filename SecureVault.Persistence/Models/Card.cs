using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecureVault.Persistence.Models
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }
        [ForeignKey("Bank")]
        public int BankId { get; set; }
        [ForeignKey("CardType")]
        public int CardTypeId { get; set; }
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

    }
}
