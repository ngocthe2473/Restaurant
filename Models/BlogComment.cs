using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuyTo.Models;

public partial class BlogComment
{
    [Key]
    public long CommentId { get; set; }

    [ForeignKey("User")]
    public long? UserId { get; set; }

    [ForeignKey("Blog")]
    public long? BlogId { get; set; }

    [Required]
    [StringLength(250)]
    public string? Detail { get; set; }

    [ForeignKey("ParentComment")]
    public long? ParrentId { get; set; }

    public bool? IsActive { get; set; }

    public int? Levels { get; set; }

    public virtual Blog? Blog { get; set; }

    public virtual User? User { get; set; }

    public virtual BlogComment? ParentComment { get; set; }

    [InverseProperty("ParentComment")]
    public virtual ICollection<BlogComment> Replies { get; set; } = new List<BlogComment>();
}
