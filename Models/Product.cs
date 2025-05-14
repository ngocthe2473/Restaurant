using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuyTo.Models;

public partial class Product
{
    [Key]
    public long ProductId { get; set; }

    [Required]
    [StringLength(500)]
    public string? ProductName { get; set; }

    [StringLength(500)]
    public string? ProductSlug { get; set; }

    [StringLength(1000)]
    public string? ProductDesc { get; set; }

    [Column(TypeName = "longtext")]
    public string? ProductDetail { get; set; }

    [StringLength(500)]
    public string? ProductImage { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? ProductPrice { get; set; }

    public int? ProductDisCount { get; set; }

    public int? ProductViewCount { get; set; }

    [ForeignKey("Category")]
    public long? CategoryId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsBestSeller { get; set; }

    public bool? IsActive { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
