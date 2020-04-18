using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace SecureVault.Persistence.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
