using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SecureVault.Persistence.Models
{
    public class CardType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardTypeId { get; set; }
        [Required]
        public string Name { get; set; } 
    }
}
