using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuyTo.Models;

public partial class FeeShip
{
    [Key]
    public long FeeShipId { get; set; }

    [ForeignKey("Commune")]
    public long? CommuneId { get; set; }

    [ForeignKey("Province")]
    public long? ProvinceId { get; set; }

    [ForeignKey("District")]
    public long? DistrictId { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal ShipPrice { get; set; }

    public virtual Commune? Commune { get; set; }

    public virtual District? District { get; set; }

    public virtual Province? Province { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
