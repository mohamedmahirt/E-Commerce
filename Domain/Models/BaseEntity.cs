using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Shopbridge_base.Domain.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
