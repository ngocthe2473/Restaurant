using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuyTo.Models;

public partial class Blog
{
    [Key]
    public long BlogId { get; set; }

    [Required]
    [StringLength(1000)]
    public string? BlogName { get; set; }

    [StringLength(1000)]
    public string? BlogSlug { get; set; }

    [ForeignKey("Category")]
    public long? CategoryId { get; set; }

    [StringLength(1000)]
    public string? BlogDesc { get; set; }

    [Column(TypeName = "longtext")]
    public string? BlogDetail { get; set; }

    [StringLength(1000)]
    public string? BlogImage { get; set; }

    public int? BlogViewCount { get; set; }

    [StringLength(1000)]
    public string? SeoTitle { get; set; }

    [StringLength(1000)]
    public string? SeoKeyword { get; set; }

    [StringLength(1000)]
    public string? SeoDescription { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<BlogComment> BlogComments { get; set; } = new List<BlogComment>();

    public virtual Category? Category { get; set; }
}
