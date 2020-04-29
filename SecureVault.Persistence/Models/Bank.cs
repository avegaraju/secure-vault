using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecureVault.Persistence.Models
{
    public class Bank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public string Notes { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Active { get; set; }
        [Required]
        public DateTime CreateDate { get; set; } 
        public DateTime? ModifyDate { get; set; }
    }
}
