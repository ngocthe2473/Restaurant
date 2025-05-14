using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuyTo.Models;

public partial class OrderDetail
{
    [Key]
    public long OrderDetailId { get; set; }

    [ForeignKey("Order")]
    public long? OrderId { get; set; }

    [ForeignKey("Product")]
    public long? ProductId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Price { get; set; }

    [Required]
    public int? Quantity { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
