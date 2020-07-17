using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecureVault.Persistence.SqlServer.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
