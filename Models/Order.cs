using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models;

public partial class Order
{
    [Key]
    public long OrderId { get; set; }

    [Required]
    [StringLength(20)]
    public string? Code { get; set; }

    [ForeignKey("User")]
    public long? UserId { get; set; }

    [Required]
    [StringLength(50)]
    public string? FullName { get; set; }

    [Required]
    [StringLength(11)]
    [Phone]
    public string? Phone { get; set; }

    [Required]
    [StringLength(1000)]
    public string? Address { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? TotalAmount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? TotalPayment { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? OrderStatus { get; set; }

    [ForeignKey("FeeShip")]
    public long? FeeShipId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User? User { get; set; }

    public virtual FeeShip? FeeShip { get; set; }
}
