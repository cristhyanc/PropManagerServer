using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PropManagerModel.Model
{
    public enum RentPeriod
    {
        Weekly,
        Fortnightly,
        Monthly
    }

    public class Rent : IGuidKey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public decimal RentPrice { get; set; }
        public decimal Bond { get; set; }
        public RentPeriod PaymentPeriod { get; set; }
        [Required]
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        [Required]
        public Guid TenantId { get; set; }
        [Required]
        public Tenant Tenant { get; set; } = null!;
        public bool Deleted { get; set; }
        
    }
}
