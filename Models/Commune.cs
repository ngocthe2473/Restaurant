using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuyTo.Models;

public partial class Commune
{
    [Key]
    public long CommuneId { get; set; }

    [Required]
    [StringLength(50)]
    public string CommuneName { get; set; } = null!;

    [StringLength(50)]
    public string? CommuneType { get; set; }

    [ForeignKey("District")]
    public long? DistrictId { get; set; }

    public virtual District? District { get; set; }

    public virtual ICollection<FeeShip> FeeShips { get; set; } = new List<FeeShip>();
}
