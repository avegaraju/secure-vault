using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecureVault.Persistence.SqlServer.Models
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
