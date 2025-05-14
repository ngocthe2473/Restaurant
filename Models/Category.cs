using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuyTo.Models;

public partial class Category
{
    [Key]
    public long CategoryId { get; set; }

    [Required]
    [StringLength(500)]
    public string? CategoryName { get; set; }

    [StringLength(500)]
    public string? Alias { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [Column(TypeName = "longtext")]
    public string? Detail { get; set; }

    public int? CategoryType { get; set; }

    [StringLength(500)]
    public string? SeoTitle { get; set; }

    [StringLength(500)]
    public string? SeoKeyword { get; set; }

    [StringLength(500)]
    public string? SeoDescription { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("ParentCateId")]
    public long? ParentCateId { get; set; }

    public int? Levels { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [ForeignKey("ParentCateId")]
    public virtual Category? ParentCategory { get; set; }

    [InverseProperty("ParentCategory")]
    public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();
}
