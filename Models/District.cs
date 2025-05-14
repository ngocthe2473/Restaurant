using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuyTo.Models;

public partial class District
{
    [Key]
    public long DistrictId { get; set; }

    [Required]
    [StringLength(50)]
    public string DistrictName { get; set; } = null!;

    [StringLength(50)]
    public string? DistricType { get; set; }

    [ForeignKey("Province")]
    public long? ProvinceId { get; set; }

    public virtual ICollection<Commune> Communes { get; set; } = new List<Commune>();

    public virtual ICollection<FeeShip> FeeShips { get; set; } = new List<FeeShip>();

    public virtual Province? Province { get; set; }
}
