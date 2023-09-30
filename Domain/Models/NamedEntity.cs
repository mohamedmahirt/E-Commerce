using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shopbridge_base.Domain.Models
{
    public abstract class NamedEntity:BaseEntity
    {
        [Column(TypeName = "varchar(500)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }
    }
}
